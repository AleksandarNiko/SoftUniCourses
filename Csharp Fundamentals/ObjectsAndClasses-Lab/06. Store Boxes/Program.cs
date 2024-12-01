
List<Box> boxes = new List<Box>();

string input = Console.ReadLine();
while (input != "end")
{
    string[] lineToken = input.Split();
    string serialNumber = lineToken[0];
    string itemName = lineToken[1];
    int itemQuantity = int.Parse(lineToken[2]);
    decimal itemPrice = decimal.Parse(lineToken[3]);
    Box box = new Box();
        box.SerialNumber = serialNumber;
        box.Item = itemName;
        box.ItemQuantity = itemQuantity;
        box.PriceForBox = itemPrice;
        box.TotalPrice = itemQuantity * itemPrice;
        boxes.Add(box);
    input = Console.ReadLine();
}
   List<Box> sortedBoxes = boxes.OrderByDescending(boxes => boxes.TotalPrice).ToList();

foreach(Box box in sortedBoxes)
{
    Console.WriteLine(box.SerialNumber);
    Console.WriteLine($"-- {box.Item} - ${box.PriceForBox:f2}: {box.ItemQuantity}");
    Console.WriteLine($"-- ${box.TotalPrice:f2}");
}

class Box
{
    public string SerialNumber { get; set; }
    public string Item { get; set; }    
    public decimal PriceForBox { get; set; }
    public int ItemQuantity { get; set; }
    public decimal TotalPrice { get; set; }
}
 