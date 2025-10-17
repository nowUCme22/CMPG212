namespace VerdictProject3;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        //go to login page
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        //go to sign up page
        await Navigation.PushAsync(new SignUpPage());
    }
}
