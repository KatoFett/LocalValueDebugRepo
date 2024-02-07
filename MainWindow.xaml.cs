namespace LocalValueDebugRepo;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _ = Dispatcher.InvokeAsync(() =>
        {
            // localValue and actualValue will both be {10,10,10,10} (correct).
            CheckButton(normalButton);

            // Get button from ItemsControl
            var container = (ContentPresenter)itemsControl.ItemContainerGenerator.ContainerFromIndex(0);
            var grid = (Grid)VisualTreeHelper.GetChild(container, 0);
            var button = (Button)grid.Children[0];

            // localValue will be Unset, but actualValue will be {10,10,10,10} (incorrect).
            CheckButton(button);

        }, DispatcherPriority.Background);
    }

    void CheckButton(Button button)
    {
        var tag = button.Tag;
        var localValue = button.ReadLocalValue(FrameworkElement.MarginProperty);
        var actualValue = button.GetValue(FrameworkElement.MarginProperty);
        Debugger.Break();
    }
}
