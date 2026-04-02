using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PermiakovaTK;

/// <summary>
/// Главное окно приложения для расчёта стоимости железнодорожных билетов.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Инициализирует компоненты главного окна.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Рассчитывает стоимость билетов с учётом расстояния, количества и класса комфортабельности.
    /// </summary>
    /// <param name="length">Расстояние в километрах.</param>
    /// <param name="quantity">Количество билетов.</param>
    /// <param name="comfortClass">
    /// Класс комфортабельности: <c>ReservedSeat</c>, <c>Coupe</c>, <c>JuniorSuite</c>, <c>Luxury</c>.
    /// </param>
    /// <returns>Итоговая стоимость билетов в рублях, или <c>0</c> если класс не распознан.</returns>
    public static double CostCalculate(double length, double quantity, string comfortClass)
    {
        const int FareRate = 8;
        double baseCost = length * quantity * FareRate;

        return comfortClass switch
        {
            "ReservedSeat" => Math.Round(baseCost * 1.0),
            "Coupe"        => Math.Round(baseCost * 1.1),
            "JuniorSuite"  => Math.Round(baseCost * 1.2),
            "Luxury"       => Math.Round(baseCost * 1.3),
            _              => 0
        };
    }

    /// <summary>
    /// Обработчик нажатия кнопки «Вычислить». Считывает поля ввода и выводит результат.
    /// </summary>
    private void Calculate_OnClick(object? sender, RoutedEventArgs e)
    {
        if (!double.TryParse(Lenght.Text, out var lDouble) ||
            !double.TryParse(Quantity.Text, out var qDouble))
        {
            return;
        }

        string comfortClass = ReservedSeat.IsChecked == true ? "ReservedSeat" :
            Coupe.IsChecked == true        ? "Coupe" :
            JuniorSuite.IsChecked == true  ? "JuniorSuite" :
            Luxury.IsChecked == true        ? "Luxury" : "";

        double result = CostCalculate(lDouble, qDouble, comfortClass);
        ResultBox.Text = $"{result} рублей";
    }
}