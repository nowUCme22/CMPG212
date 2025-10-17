using VerdictProject3.Models;
using VerdictProject3.Services;
using Microsoft.Maui.Storage;

namespace VerdictProject3;

public partial class MyCases : ContentPage
{
	public MyCases()
	{
		InitializeComponent();
		//load all cases of agent badge number
		LoadAgentCases();
	}

	//method to load the cases of the agent
	private async void LoadAgentCases()
	{
		string badge = Preferences.Get("BadgeNumber", "");

		if (string.IsNullOrWhiteSpace(badge))
		{
			await DisplayAlert("Error", "No agent badge found in session", "OK");
			return;
		}

		//get the cases
		var allCases = await CaseService.GetAllCases();
		var agentCases = allCases
			.Where(c => c.AgentBadge == badge)
			.OrderByDescending(c => c.DateCreated)
			.ToList();
		CasesListView.ItemsSource = agentCases;
		CaseCountLabel.Text = $"Total Cases: {agentCases.Count}";
	}

    private async void OnViewTimelineClicked(object sender, EventArgs e)
    {
		//validation
        var button = sender as Button;

        if (button?.CommandParameter is not int caseId)
        {
            await DisplayAlert("Error", "Invalid case ID.", "OK");
            return;
        }

        await Navigation.PushAsync(new CaseTimelinePage(caseId)); 
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }



}