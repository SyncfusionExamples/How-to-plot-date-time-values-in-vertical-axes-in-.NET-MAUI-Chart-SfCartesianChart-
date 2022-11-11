# How to plot date-time values in vertical axes in .NET MAUI Chart (SfCartesianChart)

[.Net MAUI Chart](https://www.syncfusion.com/maui-controls/maui-charts) supports plotting date-time values in the y-axis, convert the date-time values to double while populating the items source for MAUI chart, and reverse the conversion (double to date-time) in the [LabelCreated](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_LabelCreated) event of [ChartAxis](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html). By using the [NumericalAxis](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.NumericalAxis.html) with above conversions, you can display the date-time values in y-axis.

This article explains how to plot date-time values in the y-axis to the .Net MAUI Chart with the following steps.

### Initialize model
 Create a data model class that represents a data point for the chart.

**[C#]**

```
public class Model
{
	private DateTime checkInTime;
	public string Name { get; set; }
	public double CheckIn { get; set; }
	public DateTime CheckInTime
	{
		get { return checkInTime; }
		set
		{
			checkInTime = value;
			CheckIn = value.ToOADate();
		}
	}
}
```
### Initialize view model
 Create a ViewModel class with a Data Collection property using the above model and initialize a list of objects as shown in the following code sample.

**[C#]**

```
public class ViewModel
{
	public ObservableCollection<Model> Data { get; set; }

	public double Minimum { get; set; }

	public ViewModel()
	{
		// Converting date time value to its respective double value.
		Data = new ObservableCollection<Model>()
		{
			new Model(){Name = "Jack", CheckInTime = new DateTime(2022, 11, 8, 14, 30, 0)},
			new Model(){Name = "Drake", CheckInTime = new DateTime(2022, 11, 8, 10, 0, 0)},
			new Model(){Name = "Aron", CheckInTime = new DateTime(2022, 11, 8, 15, 45, 0)},
			new Model(){Name="John", CheckInTime = new DateTime(2022, 11, 8, 11, 25, 0)},
			new Model(){Name = "Shawn", CheckInTime = new DateTime(2022, 11, 8, 13, 10, 0)},
		};

		Minimum = new DateTime(2022, 11, 8).ToOADate();
	}
}
```

### How to display the date-time values in the y-axis
To display the date-time values in the y-axis, add [NumericalAxis](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.NumericalAxis.html) in the [YAxes](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_YAxes) collection and convert the double values to the date-time in the [LabelCreated](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_LabelCreated) event of [ChartAxis](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html).

**[XAML]**

```
<chart:SfCartesianChart Title="Check-in time Nov-8-2022" Margin="20">
    <chart:SfCartesianChart.BindingContext>
        <local:ViewModel />
    </chart:SfCartesianChart.BindingContext>

    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis>
            <chart:CategoryAxis.Title>
                <chart:ChartAxisTitle Text="Name"/>
            </chart:CategoryAxis.Title>
        </chart:CategoryAxis>
    </chart:SfCartesianChart.XAxes>

    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis LabelCreated="OnNumericalAxisLabelCreated"
                             Minimum="{Binding Minimum}">
            <chart:NumericalAxis.Title>
                <chart:ChartAxisTitle Text="Check-in time (hh mm)"/>
            </chart:NumericalAxis.Title>
        </chart:NumericalAxis>
   </chart:SfCartesianChart.YAxes>

    <chart:ColumnSeries ItemsSource="{Binding Data}"
                        XBindingPath="Name"
                        YBindingPath="CheckIn"/>
</chart:SfCartesianChart>
```

**[C#]**

```
private void OnNumericalAxisLabelCreated(object sender, ChartAxisLabelEventArgs e)
{
	double value = Convert.ToDouble(e.Label);
	// Converting double value to its respective date time value.
	var date = DateTime.FromOADate(value);

	// formatting date time string to display on the y-axis
	e.Label = String.Format("{0:hh:mm tt }", date);

}
```

![Date time in vertical axis](https://user-images.githubusercontent.com/61832185/201354745-f849df7c-0f6e-4caa-977a-37dc8b274629.png)

