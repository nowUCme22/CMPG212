using VerdictProject3.Models;
using VerdictProject3.Services;
using Microsoft.Maui.Storage;

namespace VerdictProject3;

public partial class ContinueCasePage : ContentPage
{

	private List<Case> _caseList;
	private int _selectedCaseId;
	public ContinueCasePage()
	{
		InitializeComponent();
        //load all open cases
		LoadCases();

        //choose what type of entry to add
		EntryTypePicker.ItemsSource = new List<string>
		{
			"Interview",
			"Surveillance",
			"Arrest",
			"Suspect",
			"Evidence"
		};
	}

	private async void LoadCases()
	{
        //get only open cases
		var allCases = await CaseService.GetAllCases();
        _caseList = allCases.Where(c => !c.IsClosed).ToList();
		CasePicker.ItemsSource = _caseList.Select(c => c.CaseIdentifier).ToList();

        if (_caseList.Count == 0)
        {
            //error
            await DisplayAlert("No open cases", "There are no open cases available to continue", "OK");
        }
	}

	private async void OnCaseSelected(object sender, EventArgs e)
	{
        if (CasePicker.SelectedIndex == -1)
            return;

        //select case
        var selectedCase = _caseList[CasePicker.SelectedIndex];
        _selectedCaseId = selectedCase.ID;

        // Show case details
        CaseDetailsPanel.IsVisible = true;
        CaseIdLabel.Text = $"Case ID: {selectedCase.CaseIdentifier}";
        AgentLabel.Text = $"Agent: {selectedCase.AgentBadge}";
        DescriptionLabel.Text = $"Description: {selectedCase.Description}";

        // Load existing entries
        var entries = await CaseEntryService.GetEntriesByCaseId(_selectedCaseId);
        EntryListView.ItemsSource = entries;
    }

    private async void OnEntryTypeChanged(object sender, EventArgs e)

    {
        var type = EntryTypePicker.SelectedItem as string;

        // Show extra fields if needed
        SuspectFields.IsVisible = type == "Suspect";
        EvidenceFields.IsVisible = type == "Evidence";
        CloseCasePanel.IsVisible = type == "Arrest";
        ArrestSuspectPanel.IsVisible = type == "Arrest";

        // Load suspect list for Arrest type
        if (type == "Arrest" && _selectedCaseId > 0)
        {
            var suspects = await SuspectService.GetSuspectsByCaseId(_selectedCaseId);
            ArrestedSuspectPicker.ItemsSource = suspects;
        }
    }

	private async void OnSaveEntryClicked(object sender, EventArgs e)
	{
        //validations
        if (_selectedCaseId == 0)
        {
            await DisplayAlert("Error", "Please select a case first.", "OK");
            return;
        }

        if (EntryTypePicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select an entry type.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(SummaryEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a summary.", "OK");
            return;
        }

        var entryType = EntryTypePicker.SelectedItem.ToString();
        //add data into case entry database

        var newEntry = new CaseEntry
        {
            CaseID = _selectedCaseId,
            EntryType = entryType,
            Summary = SummaryEntry.Text?.Trim(),
            Details = DetailsEntry.Text?.Trim(),
            Date = EntryDatePicker.Date
        };

        await CaseEntryService.AddEntry(newEntry);

        // Handle additional storage
        if (entryType == "Suspect")
        {
            if (string.IsNullOrWhiteSpace(SuspectNameEntry.Text) ||
                string.IsNullOrWhiteSpace(SuspectSurnameEntry.Text) ||
                SuspectRolePicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Please complete all suspect fields.", "OK");
                return;
            }

            //add data into suspect database
            var newSuspect = new Suspect
            {
                CaseID = _selectedCaseId,
                Name = SuspectNameEntry.Text?.Trim(),
                Surname = SuspectSurnameEntry.Text?.Trim(),
                Role = SuspectRolePicker.SelectedItem.ToString()
            };

            await SuspectService.AddSuspect(newSuspect);
        }
        else if (entryType == "Evidence")
        {
            if (string.IsNullOrWhiteSpace(EvidenceTypeEntry.Text))
            {
                await DisplayAlert("Error", "Please enter evidence type.", "OK");
                return;
            }

            //add data into evidence database
            var newEvidence = new CaseEvidence
            {
                CaseID = _selectedCaseId,
                Type = EvidenceTypeEntry.Text?.Trim(),
                Description = SummaryEntry.Text?.Trim(),
                SuspectLinked = EvidenceLinkedSuspectEntry.Text?.Trim(),
                FilePath = FilePathEntry.Text?.Trim(),
                DateCollected = EntryDatePicker.Date
            };

            await EvidenceService.AddEvidence(newEvidence);
        }

        

        await DisplayAlert("Success", "Entry saved successfully.", "OK");

        if (entryType == "Arrest")
        {
            //if type is arrested -> role must be quilty
            if (ArrestedSuspectPicker.SelectedItem is Suspect arrestedSuspect)
            {
                arrestedSuspect.IsArrested = true;
                arrestedSuspect.Role = "Guilty"; //  Set role to "Guilty"
                await SuspectService.UpdateSuspect(arrestedSuspect);
            }

            if (CloseCaseSwitch.IsToggled)
            {
                var selectedCase = _caseList.FirstOrDefault(c => c.ID == _selectedCaseId);
                if (selectedCase != null)
                {
                    selectedCase.IsClosed = true;
                    selectedCase.DateClosed = DateTime.Now;
                    await CaseService.UpdateCase(selectedCase);
                    await DisplayAlert("Case Closed", "This case has been marked as resolved.", "OK");
                }
            }
        }

        // Reload updated list
        var entries = await CaseEntryService.GetEntriesByCaseId(_selectedCaseId);
        EntryListView.ItemsSource = entries;

        // Reset form
        EntryTypePicker.SelectedIndex = -1;
        SummaryEntry.Text = "";
        DetailsEntry.Text = "";
        SuspectNameEntry.Text = "";
        SuspectSurnameEntry.Text = "";
        SuspectRolePicker.SelectedIndex = -1;
        EvidenceTypeEntry.Text = "";
        EvidenceLinkedSuspectEntry.Text = "";
        FilePathEntry.Text = "";
        SuspectFields.IsVisible = false;
        EvidenceFields.IsVisible = false;
    }

    //method to show all suspects for case
    private async void OnViewSuspectsClicked(object sender, EventArgs e)
    {
        if (_selectedCaseId == 0)
        {
            await DisplayAlert("Error", "PLease choose a case first", "OK");
            return;
        }

        await Navigation.PushAsync(new CaseSuspectsPage(_selectedCaseId));
    }

    //method to show all suspects for case
    private async void OnViewEvidenceClicked(object sender, EventArgs e)
    {
        if (_selectedCaseId == 0)
        {
            await DisplayAlert("Error", "PLease choose a case first", "OK");
            return;
        }

        await Navigation.PushAsync(new CaseEvidencePage(_selectedCaseId));
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

}
