namespace MAUIPETS;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window(new Views.CustomSplashScreen());
		return window;
	}
}

