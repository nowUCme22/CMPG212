using VerdictProject3.Models;
using VerdictProject3.Services;

namespace VerdictProject3;

public partial class CaseEvidencePage : ContentPage
{
	//variables
	private readonly int _caseId;
	private List<CaseEvidence> _allEvidence;
	//main method with parameter to get case id
	public CaseEvidencePage(int caseId)
	{
		InitializeComponent();
		_caseId = caseId;
		//load evidence for case id
		LoadEvidence();
	}

	//method to load evidence
	private async void LoadEvidence()
	{
		_allEvidence = await EvidenceService.GetEvidenceByCaseId(_caseId);
		EvidenceListView.ItemsSource = _allEvidence;

	}

	//filter evidence
	private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
	{
		if (_allEvidence != null)
		{
			return;
		}

		string filter = e.NewTextValue?.ToLower() ?? "";

		var filtered = _allEvidence
			.Where(ev => (ev.Type?.ToLower().Contains(filter) ?? false) ||
			(ev.SuspectLinked?.ToLower().Contains(filter) ?? false))
			.ToList();
		EvidenceListView.ItemsSource = filtered;
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

}