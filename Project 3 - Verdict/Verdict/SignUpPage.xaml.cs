using VerdictProject3;
using VerdictProject3.Services;
namespace VerdictProject3;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

    private async void OnSignUpClicked(object sender, EventArgs e)
    {

        //get the user input
        string name = NameEntry.Text?.Trim();
        string badge = NumberEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        //validation
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(badge) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please fill in all the fields.", "OK");
            return;
        }

        //add to the database agent
        await DatabaseService.AddAgent(name, badge, password);

        //save the name to use on multiple pages
        Preferences.Set("NameSurname", name);

        //await Navigation.PushAsync(new SignUpPage());
        await DisplayAlert("Your are signed up", $"Thank you Agent {name}.", "OK");
        //redirect to login page to login
        await Navigation.PushAsync(new LoginPage());
    }
}