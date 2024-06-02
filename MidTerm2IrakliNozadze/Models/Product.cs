public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ProductData Data { get; set; }
}

public class ProductData
{
    public string Color { get; set; }
    public string Capacity { get; set; }
    public decimal? Price { get; set; }
    public string Generation { get; set; }
    public int? Year { get; set; }
    public string CPUModel { get; set; }
    public string HardDiskSize { get; set; }
    public string StrapColour { get; set; }
    public string CaseSize { get; set; }
    public string Description { get; set; }
    public string ScreenSize { get; set; }
}