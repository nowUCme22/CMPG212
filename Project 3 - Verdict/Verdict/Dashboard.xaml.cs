using VerdictProject3;
using Microsoft.Maui.Storage;
namespace VerdictProject3;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();

        //show name 
		string name = Preferences.Get("AgentName", "Agent");
		WelcomeLabel.Text = $"Welcome back, Agent {name}";
	}

	//method to add a new case
	private async void OnAddNewCaseTapped(object sender, EventArgs e)
	{ 
		//navigate to the new case page
		await Navigation.PushAsync(new AddCasePage());
	}

    //method to continue case
    private async void OnContinueCaseTapped(object sender, EventArgs e)
    {
        //navigate to the new case page
        await Navigation.PushAsync(new ContinueCasePage());
    }

	//method to see all the users cases
	private async void OnMyCasesTapped(object sender, EventArgs e)
	{
        //navigate to the page to show all the cases of the user
        await Navigation.PushAsync(new MyCases());
    }

	//method to see al the agents
	private async void OnAgentsTapped(object sender, EventArgs e)
	{
        //navigate to the page to show all the agents
        await Navigation.PushAsync(new ShowAgents());
    }
	private async void OnAllCasesTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AllCasesPage());
	}

    private async void OnViewArrestedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PerpetratorsPage());
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        // Clear session (if you're using Preferences for PoliceNumber, for example)
        bool confirm = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "Cancel");
        if (confirm)
        {
            Preferences.Remove("BadgeNumber");
            await Navigation.PushAsync(new WelcomePage());
            Navigation.RemovePage(this);
        }

        
        
        
    }



}