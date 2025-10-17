using VerdictProject3.Models;
using VerdictProject3.Services;
namespace VerdictProject3;

public partial class PerpetratorsPage : ContentPage
{
	public PerpetratorsPage()
	{
		InitializeComponent();
		//load all the suspects that is arrested
		LoadArrestedSuspects();
	}

	private async void LoadArrestedSuspects()
	{
		//get all suspects where is arrested = true
		var suspects = await SuspectService.GetAllSuspects();
		var arrested = suspects.Where(s => s.IsArrested).ToList();
		PerpListView.ItemsSource = arrested;
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

}