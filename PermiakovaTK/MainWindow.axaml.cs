using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PermiakovaTK;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public double CostCalculate(double lenght, double quantity)
    {
        const int FareRate = 8;
        double baseCost = lenght * quantity * FareRate;
        if (ReservedSeat.IsChecked == true)
        {
            return baseCost * 1;
        }
        else if (Coupe.IsChecked == true)
        {
            return baseCost * 1.1;
        }
        else if (JuniorSuite.IsChecked == true)
        {
            return baseCost * 1.2;
        }
        else if (Luxury.IsChecked == true)
        {
            return baseCost * 1.3;
        }

        return 0;
    }

    private void Calculate_OnClick(object? sender, RoutedEventArgs e)
    {
        if (!double.TryParse(Lenght.Text, out var lDouble) ||
            !double.TryParse(Quantity.Text, out var qDouble))
        {
            return;
        }

        double result = CostCalculate(lDouble, qDouble);
        ResultBox.Text = $"{result} рублей";
    }
}