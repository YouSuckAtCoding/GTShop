namespace GTShop.Server.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Msrp { get; set; }
    public int Type { get; set; }
    public string Description { get; set; } = "";
    public string Description_2 { get; set; }  = "";
    public string Description_3 { get; set; } = "";
    public int Power { get; set; }
    public int Torque { get; set; }
    public List<P_Color> Colors { get; set; } = new List<P_Color>();
    public string Image_1 { get; set; } = "";
    public string Image_2 { get; set; }  = "";
    public string Image_3 { get; set; }  = "";
    public string Image_4 { get; set; }  = "";
    public string Image_5 { get; set; }  = "";

}
