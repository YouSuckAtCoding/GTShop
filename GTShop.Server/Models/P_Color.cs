using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class P_Color
{
    public int Id { get; set; }
    public Product Product_Id { get; set; }
    public string Hex { get; set; } = "";
}
