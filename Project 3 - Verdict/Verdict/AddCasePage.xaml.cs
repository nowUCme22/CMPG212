using VerdictProject3.Models;
using VerdictProject3.Services;
namespace VerdictProject3;


public partial class AddCasePage : ContentPage
{
	public AddCasePage()
	{
		InitializeComponent();
	}

	private async void OnSaveCaseClicked(object sender, EventArgs e)
	{
		//variables for user input
		string caseId = caseId = CaseIdEntry.Text?.Trim();
		string badge = AgentBadgeEntry.Text?.Trim();
		string description = DescriptionEntry.Text?.Trim();
		DateTime date = DateCreatedPicker.Date;

		//validation
		if (string.IsNullOrWhiteSpace(caseId) || string.IsNullOrWhiteSpace(badge) || string.IsNullOrWhiteSpace(description))
		{
			await DisplayAlert("Error", "Please fill in all the fields", "OK");
			return;
		}

		//add new case to the database
		var newCase = new Case
		{
			CaseIdentifier = caseId,
			AgentBadge = badge,
			Description = description,
			DateCreated = date
		};

		await CaseService.AddCase(newCase);
		await DisplayAlert("Success", "Case saved successfully.", "OK");
		
		//go back to navigtion page
		await Navigation.PopAsync();

	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
		//go to dashboard
        await Navigation.PushAsync(new Dashboard());
    }

}