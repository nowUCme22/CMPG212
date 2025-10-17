using VerdictProject3;
using VerdictProject3.Models;
using VerdictProject3.Services;

namespace VerdictProject3;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		//variables
		string badge = NumberEntry.Text?.Trim();
		string password = PasswordEntry.Text;

		//fake password check for now
		/*if ((badge == "48073253") && (password == "1234"))
		{
			await DisplayAlert("Login Successful", "Welcom, Agent", "OK");

			//request next page
		}
		else
		{
			await DisplayAlert("Login failed", "Invalid credentials", "Try again");
			return;
		}*/

		if (string.IsNullOrEmpty(badge) || string.IsNullOrWhiteSpace(password))
		{
			//validation
			await DisplayAlert("Error", "Please enter both badge number and password", "OK");
			return;
		}

		//see if agent exists and get name
		Agent agent = await DatabaseService.getAgentByInfo(badge, password);

		if (agent != null)
		{
			//save the name of output message and other pages
			Preferences.Set("AgentName", agent.Name);
            Preferences.Set("BadgeNumber", agent.PoliceNumber);

            await DisplayAlert("Login Successful", $"Welcome agent {agent.Name}", "OK");

            //redirect to dashboard
            await Navigation.PushAsync(new Dashboard());

        }
		else
		{
			await DisplayAlert("Login Failed", "Invalid badge number or password", "Try again");
		}
	}

	private async void OnForgotPasswordTapped(object sender, EventArgs e)
	{
		//if forgot password is pressed.. it must ask for the badge number
		string badge = await DisplayPromptAsync("Forgot password", "Enter your badge number:", "Submit", "Cancel");

		if ((string.IsNullOrWhiteSpace(badge)))
        {
			await DisplayAlert("Cancelled", "Password recovery cancelled", "OK");
			return;
        }

		//search for the agent in the database
		var agent = await DatabaseService.GetAgentByBadge(badge.Trim());

		//message showing password
		if (agent != null)
		{
			await DisplayAlert("Password Found", $"Your password is: {agent.Password}", "OK");
		}
		else
		{
			await DisplayAlert("Not Found", "No agent with this badge number.", "OK");
		}
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }
}