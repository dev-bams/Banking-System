using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
  public class Card
  {
    public static long NumberOfCards { get; set; } = 1111111111111111;
    public string CardOwner { get; set; }
    public string CardNumber { get; set; }
    public string CardPin { get; set; }

    public Card()
    {

    }
    public Card(Customer customer, string cardNumber, string cardPin)
    {
      CardOwner = customer.CustomerFullName;
      CardNumber = cardNumber.PadLeft(16, '0'); ;
      CardPin = cardPin;
      NumberOfCards++;
    }
  }
}
