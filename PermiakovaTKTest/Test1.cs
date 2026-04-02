using PermiakovaTK;

namespace PermiakovaTKTest;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void CalculateReservedSeat()
    {
        double result = MainWindow.CostCalculate(150, 3, "ReservedSeat");
        Assert.AreEqual(3600.0, result);
    }
    
    [TestMethod]
    public void CalculateCoupe()
    {
        double result = MainWindow.CostCalculate(200, 1, "Coupe");
        Assert.AreEqual(1760.0, result);
    }
    
    [TestMethod]
    public void CalculateJuniorSuite()
    {
        double result = MainWindow.CostCalculate(100, 2, "JuniorSuite");
        Assert.AreEqual(1920.0, result);
    }
    
    [TestMethod]
    public void CalculateLuxury()
    {
        double result = MainWindow.CostCalculate(400, 1, "Luxury");
        Assert.AreEqual(4160.0, result);
    }
    
    [TestMethod]
    public void CalculateNoComfortClassSelected()
    {
        double result = MainWindow.CostCalculate(100, 2, "");
        Assert.AreEqual(0, result);
    }
    
    [TestMethod]
    public void CalculateInvalidComfortClass()
    {
        double result = MainWindow.CostCalculate(100, 2, "NotKnownClass");
        Assert.AreEqual(0, result);
    }
    
    [TestMethod]
    public void CalculateZeroLength()
    {
        double result = MainWindow.CostCalculate(0, 2, "Luxury");
        Assert.AreEqual(0, result);
    }
}

