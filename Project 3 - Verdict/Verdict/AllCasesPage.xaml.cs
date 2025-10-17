using VerdictProject3.Models;
using VerdictProject3.Services;

namespace VerdictProject3;

public partial class AllCasesPage : ContentPage
{
	private List<Case> _allCases;
	public AllCasesPage()
	{
		InitializeComponent();
        //call method to load all the cases
		LoadAllCases();
	}

    //method to load all cases
	private async void LoadAllCases()
	{
		_allCases = await CaseService.GetAllCases();
		AllCasesListView.ItemsSource = _allCases.OrderByDescending(c => c.DateCreated).ToList();
	}

    //show the open cases
	private void ShowOpenCases(object sender, EventArgs e)
	{ 
		var open = _allCases.Where(c => !c.IsClosed).OrderByDescending(c => c.DateCreated).ToList();
		AllCasesListView.ItemsSource = open;
	}

    //show the closed cases
    private void ShowClosedCases(object sender, EventArgs e)
    {
        var closed = _allCases.Where(c => c.IsClosed).OrderByDescending(c => c.DateCreated).ToList();
        AllCasesListView.ItemsSource = closed;
    }

    //show all the cases open and closed
    private void ShowAllCases(object sender, EventArgs e)
    {
        AllCasesListView.ItemsSource = _allCases.OrderByDescending(c => c.DateCreated).ToList();
         
    }

    //when edit is clicked
	private async void OnEditCaseClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var selectedCase = button?.CommandParameter as Case;

        //if selected case not 0, get case id
		if (selectedCase != null)
		{
			await DisplayAlert("Test", $"Editing: {selectedCase.CaseIdentifier}", "OK");
			//return;
		}

        //option to choosewhat to edit 
		var options = new List<string> { "Case Identifier", "Description", "Agent Badge" };
		if (selectedCase.IsClosed)
		{
			options.Add("Date Closed");
		}

		string action = await DisplayActionSheet("Edit case", "Cancel", null, options.ToArray());
		if (action == "Case Identifier")
		{
			string newId = await DisplayPromptAsync("Edit Case Identifier", "Enter new case ID: ", initialValue: selectedCase.CaseIdentifier);
			if (!string.IsNullOrWhiteSpace(newId))
			{ 
				selectedCase.CaseIdentifier = newId.Trim();
			}
		}
		else if (action == "Description")
        {
            string newDescription = await DisplayPromptAsync("Edit Description", "Enter new Description: ", initialValue: selectedCase.Description);
            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                selectedCase.Description = newDescription.Trim();
            }
        }
        else if (action == "Agent Badge")
        {
            string newBadge = await DisplayPromptAsync("Edit Agent Badge", "Enter new Agent Badge: ", initialValue: selectedCase.AgentBadge);
            if (!string.IsNullOrWhiteSpace(newBadge))
            {
                selectedCase.AgentBadge = newBadge.Trim();
            }
        }
        else if (action == "Date Closed")
        {
            bool confirm = await DisplayAlert("Edit Date Closed", "Set Date Closed to today's date?", "Yes", "Cancel");
            if (confirm)
            {
                selectedCase.DateClosed = DateTime.Now;
            }
        }

        //update 
		await CaseService.UpdateCase(selectedCase);
		LoadAllCases();
    }

	private async void OnDeleteCaseClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
        var selectedCase = button?.CommandParameter as Case;

        if (selectedCase != null)
        {
			//get the case to delete
            await DisplayAlert("Test", $"Deleting: {selectedCase.CaseIdentifier}", "OK");
            //return;
        }

        //ask to make sure you want to delete
		bool confirm = await DisplayAlert("Delete Case", $"Are you sure you want to delete case '{selectedCase.CaseIdentifier}'?", "Delete", "Cancel");
        if (confirm)
        {
            IsBusy = true;
            await CaseService.DeleteCaseAndRelatedData(selectedCase.ID);
            IsBusy = false;

            await DisplayAlert("Deleted", "Case and all related data removed.", "OK");
            LoadAllCases();
        }


    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

}