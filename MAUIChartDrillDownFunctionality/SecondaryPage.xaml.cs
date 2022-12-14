using Syncfusion.Maui.Charts;

namespace MAUIChartDrillDownFunctionality;

public partial class SecondaryPage : ContentPage
{
    public SecondaryPage(Model selectedData, Brush fill)
    {
        InitializeComponent();
        this.chart.Title = "Monthly Expense Of " + selectedData.Type;
        this.BindingContext = selectedData;
        series.Fill = fill;
    }
}