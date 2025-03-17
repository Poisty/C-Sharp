using BeehiveManagement;

namespace BeeHiveManagement;

public partial class MainPage : ContentPage
{
	
    private Queen queen = new Queen();

	public MainPage()
	{
		InitializeComponent();

        Jobpicker.ItemsSource = new string[]
        {
            "Nectar Collector",
            "Honey Manufacturer",
            "Egg Care",
        };
        Jobpicker.SelectedIndex = 0;

        UpdateStatusAndEnableAssignButton();
	}

    private void UpdateStatusAndEnableAssignButton()
    {
       StatusReport.Text = queen.StatusReport;
       AssignJobButton.IsEnabled = queen.CanAssignWorkers;
    }



    private void AssignJobButton_Clicked(object sender, EventArgs e)
    {
        queen.AssignBee(Jobpicker.SelectedItem.ToString());
        UpdateStatusAndEnableAssignButton();
    }

    private void OutOfHoneyButton_Clicked(object sender, EventArgs e)
    {

        HoneyVault.Reset();
        queen = new Queen();
        WorkShiftButton.IsVisible = true;
        OutOfHoneyButton.IsVisible = false;
        UpdateStatusAndEnableAssignButton();
    }

    private void WorkShiftButton_Clicked(object sender, EventArgs e)
    {
        if (!queen.WorkTheNextShift())
        {
            WorkShiftButton.IsVisible = false;
            OutOfHoneyButton.IsVisible = true;
            SemanticScreenReader.Default.Announce(OutOfHoneyButton.Text);
        }
        UpdateStatusAndEnableAssignButton();
    }
}

