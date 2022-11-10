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
		var date = DateTime.FromOADate(value);
		e.Label = String.Format("{0:hh:mm tt }", date);
	}
}

