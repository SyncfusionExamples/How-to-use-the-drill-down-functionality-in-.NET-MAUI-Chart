using Syncfusion.Maui.Charts;
using System.Collections;

namespace MAUIChartDrillDownFunctionality;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnPieSeriesSelectionChanged(object sender, ChartSelectionChangedEventArgs e)
	{
		var series = sender as PieSeries;
		var items = series.ItemsSource as IList;
		int selectedIndex = e.NewIndexes[0];
		// Get selected segment data
		var selectedData = items[selectedIndex] as Model;
		// Navigate to the next page which is representing the chart with details.
		Navigation.PushAsync(new SecondaryPage(selectedData, series.PaletteBrushes[selectedIndex]));
	}
}

