using VerdictProject3.Models;
using VerdictProject3.Services;

namespace VerdictProject3;

public partial class CaseTimelinePage : ContentPage
{
    private int _caseId;

    public CaseTimelinePage(int caseId)
    {
        InitializeComponent();
        _caseId = caseId;
        //load entries for case id
        LoadTimeline();
    }

    private async void LoadTimeline()
    {
        try
        {
            //get all the entries
            var allEntries = await CaseEntryService.GetAllEntries();
            //all entries where case if == case id
            var entries = allEntries
                .Where(e => e.CaseID == _caseId)
                .OrderBy(e => e.Date)
                .ToList();

            TimelineGrid.ColumnDefinitions.Clear();
            TimelineGrid.Children.Clear();
            TimelineGrid.RowDefinitions.Clear();

            // add 3 rows: top (card), middle (line), bottom (card)
            TimelineGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // row 0
            TimelineGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // row 1
            TimelineGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // row 2


            //add line
            var horizontalLine = new BoxView
            {
                HeightRequest = 2,
                BackgroundColor = Colors.Gray,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };

            // span the horizontal line across all timeline columns
            TimelineGrid.Children.Add(horizontalLine);
            Grid.SetRow(horizontalLine, 1);
            Grid.SetColumnSpan(horizontalLine, entries.Count);

            for (int i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                var isEven = i % 2 == 0;

                // add a column for each entry
                TimelineGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                // --- Vertical Line ---
                var line = new BoxView
                {
                    WidthRequest = 2,
                    HeightRequest = 80,
                    Color = Colors.Gray,
                    HorizontalOptions = LayoutOptions.Center
                };
                TimelineGrid.Children.Add(line);
                Grid.SetColumn(line, i);
                Grid.SetRow(line, 1); // center row

                // --- Dot on timeline ---
                var dot = new BoxView
                {
                    WidthRequest = 12,
                    HeightRequest = 12,
                    CornerRadius = 6,
                    Color = Colors.Red,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                TimelineGrid.Children.Add(dot);
                Grid.SetColumn(dot, i);
                Grid.SetRow(dot, 1); // same as line

                // --- Entry Card ---
                var entryCard = new Frame
                {
                    BackgroundColor = Color.FromArgb("#F0F0F0"),
                    CornerRadius = 10,
                    BorderColor = Colors.Gray,
                    Padding = 10,
                    Content = new VerticalStackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = $"{entry.Date:dd MMM yyyy} - {entry.EntryType}",
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.Black,
                                FontSize = 14
                            },
                            new Label
                            {
                                Text = entry.Summary,
                                FontSize = 13,
                                TextColor = Colors.Black
                            },
                            new Label
                            {
                                Text = entry.Details,
                                FontSize = 12,
                                TextColor = Colors.Gray
                            }
                        }
                    }
                };

                int cardRow = isEven ? 0 : 2; // top or bottom
                TimelineGrid.Children.Add(entryCard);
                Grid.SetColumn(entryCard, i);
                Grid.SetRow(entryCard, cardRow);
            }
        }
        catch (Exception ex)
        {
            //error message
            await DisplayAlert("Error", $"Failed to load timeline: {ex.Message}", "OK");
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyCases());
    }

}
