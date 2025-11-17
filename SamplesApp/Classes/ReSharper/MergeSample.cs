namespace SamplesApp.Classes.ReSharper;
public class MergeSample
{
    public bool IsBlackFriday { get; set; } = true;
    public bool IsHoliday { get; set; } = true;

    /// <summary>
    /// Merge duplicate conditional fragments
    /// </summary>
    /// <param name="order"></param>
    public void ApplyDiscount(Order order)
    {
        decimal discountRate = 0m;
        if (IsBlackFriday)
        {
            discountRate += 0.30m;
        }
        else if (IsHoliday)
        {
            discountRate += 0.30m;
        }

        foreach (var item in order.Items)
        {
            item.Price -= item.Price * discountRate;
        }
    }
}

public class Order
{
    public int Id { get; set; }
    public required string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public List<Product> Items { get; set; } = [];
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
