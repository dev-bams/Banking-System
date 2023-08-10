using System.Collections.Generic;
using System;
using System.Threading;

namespace BankingSystem
{
  internal class LoginScreen
  {
    public static int MAXTRIES = 3;
    public List<Customer> Customers;

    public LoginScreen(List<Customer> customers)
    {
      Customers = customers;
    }

    public bool DisplayLoginScreen()
    {
      int tries = 0;
      bool loggedIn = false;

      while (tries < MAXTRIES && !loggedIn)
      {
        Console.Write("Insert Card: ");
        string userCard = Console.ReadLine();
        Console.Write("Insert Pin: ");
        string userPin = Console.ReadLine();

        loggedIn = ValidateLogin(userCard, userPin);

        if (loggedIn)
        {
          Console.WriteLine("Login successful!");
        }
        else
        {
          Console.WriteLine("Invalid credentials, try again.");
          tries++;
          Thread.Sleep(1000);
          Console.Clear();
        }
      }

      if (!loggedIn)
      {
        Console.WriteLine("Maximum login attempts reached. Please contact customer support.");
      }
      return loggedIn;
    }

    public bool ValidateLogin(string userCard, string userPin)
    {
      foreach (var customer in Customers)
      {
        foreach (var card in customer.CustomerCards)
        {
          if (userCard == card.CardNumber && userPin == card.CardPin)
          {
            return true;
          }
        }
      }
      return false;
    }
  }
}
