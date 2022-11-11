namespace DateTimeVerticalAxesDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnNumericalAxisLabelCreated(object sender, Syncfusion.Maui.Charts.ChartAxisLabelEventArgs e)
	{
		double value = Convert.ToDouble(e.Label);
		// Converting double value to its respective date time value.
		var date = DateTime.FromOADate(value);

		// formatting date time string to display on the y-axis
		e.Label = String.Format("{0:hh:mm tt }", date);
	}
}

