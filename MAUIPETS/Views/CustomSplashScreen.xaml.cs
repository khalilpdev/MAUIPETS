namespace MAUIPETS.Views;

public partial class CustomSplashScreen : ContentPage
{
	public CustomSplashScreen()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(1000);

        var anim1 = pets.TranslateToAsync(400, 0, 3000, Easing.Linear);
        var anim2 = pets.ScaleToAsync(1.5, 3000, Easing.Linear);

        await Task.WhenAll(anim1, anim2);

        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new AppShell();
        }
    }
}
