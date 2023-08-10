using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankingSystem
{
  internal class Program
  {
    static void Main()
    {
      const string filePath = @"C:\Users\khale\OneDrive\Desktop\code\Projects\c#\BankingSystem\customers.xml";
      List<Customer> customers = new List<Customer>();

      //Loads objects from the file if it exists
      if (File.Exists(filePath))
      {
        DeserializeCustomerObjects(filePath, ref customers);
      }
      //else create new objects
      else
      {
        customers.Add(new Customer("Khaleed", new DateTime(2005, 6, 18), "4373665404", "100 brickyard way", "Opeloyeru"));
        customers.Add(new Customer("Ayobami", new DateTime(2006, 6, 18), "4373665403", "101 brickyard way"));

        customers[0].OpenAccount(new BankAccount(customers[0], $"{BankAccount.NumberOfAccounts}"));
        customers[0].RegisterForCard(new Card(customers[0], $"{Card.NumberOfCards}", "1111"));
        customers[0].RegisterForOnLineBanking("1111");
      }

      //Creating an ATM
      ATM ATM = new ATM(customers, "Brampton", 100000);
      bool isLoggedIn = ATM.LoginScreen.DisplayLoginScreen();
      /*      SerializeCustomerObjects(filePath, customers);*/
    }
    //This method takes in path and the list variable as an argument
    //it then loads from the path and assigns to the list variable
    static void DeserializeCustomerObjects(string filePath, ref List<Customer> customers)
    {
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        using (StreamReader reader = new StreamReader(filePath))
        {
          customers = (List<Customer>)serializer.Deserialize(reader);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    static void SerializeCustomerObjects(string filePath, List<Customer> customers)
    {
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        using (TextWriter writer = new StreamWriter(filePath))
        {
          serializer.Serialize(writer, customers);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
  enum SuccessCodes : short
  {
    transactionSuccessful = 201
  }
  enum ErrorCodes : short
  {
    lowBalance = 101
  }
}
