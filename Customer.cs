using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
  public class Customer
  {
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public DateTime CustomerDOB { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerAddress { get; set; }
    public List<BankAccount> CustomerBankAccounts { get; set; }
    public List<Card> CustomerCards { get; set; }
    public string UserID { get; set; } = null;
    public string UserPassword { get; set; } = null;
    public string CustomerFullName { get => $"{CustomerFirstName} {CustomerLastName}"; }
    public string AllCustomerAccounts
    {
      get
      {
        string newLine = "\n";
        string userAccountList = "";
        for (int i = 0; i < CustomerBankAccounts.Count; i++)
        {
          userAccountList += $"Account Number: {CustomerBankAccounts[i].AccountNumber}\tBalance: {CustomerBankAccounts[i].AccountBalance}";
          if (i != CustomerBankAccounts.Count - 1)
          {
            userAccountList += newLine;
          }
        }
        return userAccountList;
      }
    }
    public string AllCustomerCards
    {
      get
      {
        string newLine = "\n";
        string userCardList = "";
        for (int i = 0; i < CustomerCards.Count; i++)
        {
          userCardList += $"Card Number: {CustomerCards[i].CardNumber}";
          if (i != CustomerCards.Count - 1)
          {
            userCardList += newLine;
          }
        }
        return userCardList;
      }
    }

    public Customer()
    {

    }
    public Customer(string customerFirstName, DateTime customerDOB, string customerPhoneNumber, string customerAddress, string customerLastName = null)
    {
      CustomerFirstName = customerFirstName;
      CustomerDOB = customerDOB;
      CustomerPhoneNumber = customerPhoneNumber;
      CustomerAddress = customerAddress;
      CustomerLastName = customerLastName;
      CustomerBankAccounts = new List<BankAccount>();
      CustomerCards = new List<Card>();
    }

    public override string ToString()
    {
      return "======================================\n" +
             $"First Name: {CustomerFirstName}\n" +
             $"Last Name: {CustomerLastName}\n" +
             $"DOB: {CustomerDOB}\n" +
             $"Phone Number: {CustomerPhoneNumber}\n" +
             $"Address: {CustomerAddress}\n" +
             $"Bank Accounts:\n{AllCustomerAccounts}\n" +
             $"Cards: \n{AllCustomerCards}";
    }

    public void OpenAccount(BankAccount bankAccount)
    {
      CustomerBankAccounts.Add(bankAccount);
    }
    public void CloseAccount(BankAccount bankAccount)
    {
      CustomerBankAccounts.Remove(bankAccount);
    }
    public void RegisterForCard(Card card)
    {
      CustomerCards.Add(card);
    }
    public void RegisterForOnLineBanking(string password)
    {
      UserID = CustomerBankAccounts[0].AccountNumber;
      UserPassword = password;
    }
  }
}
