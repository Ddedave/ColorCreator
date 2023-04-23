using CommunityToolkit.Maui.Alerts;

namespace ColorCreator;

public partial class MainPage : ContentPage
{
	bool israndom;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		if (!israndom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
		
    }

	private void SetColor(Color color)
	{
		//
		//btn.BackgroundColor = color;
		btnRandoom.BackgroundColor = color;
		Container.BackgroundColor = color;
		hexValue = color.ToHex();
		lblHex.Text = hexValue;
	}

    private void btnRandoom_Clicked(object sender, EventArgs e)
    {
		israndom = true;
		var random = new Random();
		var color = Color.FromRgb(random.Next(0, 256), 
			random.Next(0, 256), 
			random.Next(0, 256));
		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
		israndom = false;

    }

    private async void btn_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color Copiado",
			CommunityToolkit.Maui.Core.ToastDuration.Short,
			12);
		await toast.Show();
    }
}



