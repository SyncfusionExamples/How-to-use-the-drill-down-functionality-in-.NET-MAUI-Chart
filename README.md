# How-to-use-the-drill-down-functionality-in-.NET-MAUI-Chart
This sample demonstrateshow to use the drill-down functionality in [.Net MAUI Chart.](https://www.syncfusion.com/maui-controls/maui-charts)

The drill-down functionality is used to navigate from one chart to another chart when tapping on a segment. [.Net MAUI Chart](https://www.syncfusion.com/maui-controls/maui-charts) has achieved this functionality by using the [SelectionChanged](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSelectionBehavior.html#Syncfusion_Maui_Charts_ChartSelectionBehavior_SelectionChanged) event.
For example, initially, we displayed the monthly expense of some people in a pie chart. When you tap on a particular segment to know more details, it generates a new chart, which provides further detailed information.

The following steps will guide you on how to achieve this expected functionality.

**Step 1:** On the main page, create a pie chart with generated data and invoke [SelectionChanged](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSelectionBehavior.html#Syncfusion_Maui_Charts_ChartSelectionBehavior_SelectionChanged) event.

**[XAML]**

```
    <chart:SfCircularChart>
        <chart:SfCircularChart.Legend>
            <chart:ChartLegend />
        </chart:SfCircularChart.Legend>
        <chart:PieSeries ItemsSource="{Binding PieData}" 
                         XBindingPath="Type" 
                         YBindingPath="Value"
                         ShowDataLabels="True"
                         PaletteBrushes="{Binding CustomBrushes}">
            <!--To enable the selection support-->
            <chart:PieSeries.SelectionBehavior>
                <chart:DataPointSelectionBehavior SelectionChanged="OnPieSeriesSelectionChanged"/>
            </chart:PieSeries.SelectionBehavior>
        </chart:PieSeries>
    </chart:SfCircularChart>
```
**Step 2:**  Drill-down functionality observed concepts.

**[C#]**

```
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
```

**Step 3:**  Populate selected segment data on the navigated page. 

**[XAML]**

```
<chart:SfCartesianChart x:Name="chart">

    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis />
    </chart:SfCartesianChart.XAxes>
    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.YAxes>

    <chart:ColumnSeries x:Name="series"
                        XBindingPath="Type"
                        YBindingPath="Value"
                        ItemsSource="{Binding Collections}"/>

</chart:SfCartesianChart>
```

**[C#]**

```
public SecondaryPage(Model selectedData, Brush fill)
{
    InitializeComponent();
    this.chart.Title = "Monthly Expense Of " + selectedData.Type;
    this.BindingContext = selectedData;
    series.Fill = fill;
}
```

## Output:
![Initial view of Drilldown  functionality in .NET MAUI Chart](https://user-images.githubusercontent.com/61832185/207515385-b99f6083-0e66-401e-81b0-e2cc66be767b.png)

![Detailed view of Drilldown  functionality in .NET MAUI Chart](https://user-images.githubusercontent.com/61832185/207515391-5882f7cc-d574-431d-b937-02f98b1dae66.png)

## <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

To run the sample demo, refer to [System Requirements for .NET MAUI.](https://help.syncfusion.com/maui/system-requirements)

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

