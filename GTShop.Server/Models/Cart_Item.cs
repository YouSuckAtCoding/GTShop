using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class Cart_Item
{
    public int Id { get; set; }
    public required Cart Cart_ { get; set; }
    public required Product Product_ { get; set; }
}
