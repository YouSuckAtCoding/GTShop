using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class Payment
{
    public Guid Id {get;set;}
    [ForeignKey(nameof(Order))]
    public required Order Order_Id {get;set;}
    public decimal Total {get;set;}
    public int Method {get;set;}
    public DateTime Payment_Date {get;set;}
    public bool Payment_Confirmed {get;set;}
    public required List<Product> Products {get;set;} 
    public int Installments {get;set;}
    public decimal Installments_price {get;set;}

}
