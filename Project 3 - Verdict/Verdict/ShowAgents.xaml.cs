using VerdictProject3.Models;
using VerdictProject3.Services;

namespace VerdictProject3;

public partial class ShowAgents : ContentPage
{
	public ShowAgents()
	{
		InitializeComponent();
        //load all the existing agents
		LoadAgents();
	}

    private async Task LoadAgents()
    {
        var allAgents = await DatabaseService.getAllAgents();
        var sortedAgents = allAgents.OrderBy(a => a.Name).ToList();
        AgentListView.ItemsSource = sortedAgents;
    }

    //edit agents info 
    private async void OnEditAgentClicked(object sender, EventArgs e)
    {
        var agent = (sender as Button)?.CommandParameter as Agent;
        if (agent == null) return;

        string newName = await DisplayPromptAsync("Edit Agent Name", "Enter new name:", initialValue: agent.Name);
        string newBadge = await DisplayPromptAsync("Edit Badge Number", "Enter new badge number:", initialValue: agent.PoliceNumber);
        string newPassword = await DisplayPromptAsync("Edit Password", "Enter new password:", initialValue: agent.Password, maxLength: 100, keyboard: Keyboard.Text);

        if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newBadge) && !string.IsNullOrWhiteSpace(newPassword))
        {
            string oldBadge = agent.PoliceNumber;

            agent.Name = newName.Trim();
            agent.PoliceNumber = newBadge.Trim();
            agent.Password = newPassword.Trim();

            //update info in database
            await AgentService.UpdateAgent(agent);
            await CaseService.UpdateBadgeNumberForCases(oldBadge, agent.PoliceNumber);

            await DisplayAlert("Success", "Agent, password and related cases updated.", "OK");
            await LoadAgents();
        }
    }

    //delete agent
    private async void OnDeleteAgentClicked(object sender, EventArgs e)
    {
        var agent = (sender as Button)?.CommandParameter as Agent;
        if (agent == null) return;

        //confirmation to delete agent
        bool deleteAgent = await DisplayAlert("Delete Agent", $"Delete {agent.Name}?", "Yes", "No");
        if (!deleteAgent) return;

        //delete related cases and entries? 
        bool deleteCases = await DisplayAlert("Also Delete Cases?", $"Delete all cases linked to badge {agent.PoliceNumber}?", "Yes - Delete All", "No - Keep Cases");

        if (deleteCases)
        {
            var agentCases = await CaseService.GetCasesByAgentBadge(agent.PoliceNumber);
            foreach (var c in agentCases)
            {
                await CaseService.DeleteCaseAndRelatedData(c.ID);
            }
        }

        await AgentService.DeleteAgent(agent);
        await DisplayAlert("Success", "Agent deleted.", "OK");
        await LoadAgents(); // refresh
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }



}