namespace DisplayViewDelay.Pages.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class OverviewView : ContentView
{
	public OverviewView()
	{
		InitializeComponent();
	}

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height < 0)
        {
            return;
        }

        if (height > width)
        {
            BackgroundImage.HeightRequest = height * 0.7;
        }
        else
        {
            BackgroundImage.HeightRequest = height;
        }

        OverviewBorder.HeightRequest = height;
    }
}