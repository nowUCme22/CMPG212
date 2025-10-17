using VerdictProject3.Models;
using VerdictProject3.Services;
namespace VerdictProject3;

public partial class CaseSuspectsPage : ContentPage
{
	//variables
	private readonly int _caseId;
	private List<Suspect> _allSuspects;
	//main method with parameter
	public CaseSuspectsPage(int caseId)
	{
		InitializeComponent();
		_caseId = caseId;
		//load suspects for case id
		LoadSuspects();
	}

	//method to get suspects for case id
	private async void LoadSuspects()
	{
		_allSuspects = await SuspectService.GetSuspectsByCaseId(_caseId);
        SuspectListView.ItemsSource = _allSuspects;

	}

	//filter by name
	private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
	{
		if (_allSuspects == null)
		{
			return;
		}

		string filter = e.NewTextValue?.ToLower() ?? "";

		var filtered = _allSuspects
			.Where (s => (s.Name?.ToLower().Contains(filter) ?? false) ||
						(s.Surname?.ToLower().Contains(filter) ?? false))
			.ToList();

		SuspectListView.ItemsSource = filtered;
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

}