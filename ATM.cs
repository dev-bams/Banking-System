using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankingSystem
{
  internal class ATM
  {
    public List<Customer> Customers { get; set; }
    public string Location { get; set; }
    public decimal ATMBalance { get; set; }
    public bool IsLoggedIn { get; set; } = false;
    public Customer CurrentCustomer { get; set; }
    public LoginScreen LoginScreen { get; set; }

    public ATM(List<Customer> customers, string location, decimal ATMBalance)
    {
      Customers = customers;
      Location = location;
      this.ATMBalance = ATMBalance;
      LoginScreen = new LoginScreen(customers);
    }
    public void DisplayMenu()
    {
      Console.WriteLine("Hi there ");
    }
  }
}
