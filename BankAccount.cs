using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
  public class BankAccount
  {
    /* -------------------------------------------------------------------------- */
    /*                                   FIELDS                                   */
    /* -------------------------------------------------------------------------- */
    public static int NumberOfAccounts { get; set; } = 1;
    public string AccountFirstName { get; set; }
    public string AccountLastName { get; set; }
    public string AccountFullName { get => $"{AccountFirstName} {AccountLastName}"; }
    public string AccountNumber { get; set; }
    public int AccountBalance { get; set; }

    /* -------------------------------------------------------------------------- */
    /*                                 CONSTRUCTOR                                */
    /* -------------------------------------------------------------------------- */
    public BankAccount()
    {

    }
    public BankAccount(Customer customer, string accountNumber, int accountBalance = 0)
    {
      AccountFirstName = customer.CustomerFirstName;
      AccountLastName = customer.CustomerLastName;
      //if AccountNumber length is less than 9 pad start with zeros
      AccountNumber = accountNumber.PadLeft(9, '0');
      AccountBalance = accountBalance;
      NumberOfAccounts++;
    }

    /* -------------------------------------------------------------------------- */
    /*                               TOSTRING METHOD                              */
    /* -------------------------------------------------------------------------- */
    public override string ToString()
    {
      return $"_________________________\nAccount-name: {AccountFullName}\nAccount-number: {AccountNumber}\nAccount-balance: ${AccountBalance}\n_________________________";
    }

    /* -------------------------------------------------------------------------- */
    /*                                   METHODS                                  */
    /* -------------------------------------------------------------------------- */
    //Method for adding to balance
    public void AddToBalance(int amount)
    {
      AccountBalance += amount;
    }

    //Method for removing from balance
    public Enum RemoveFromBalance(int amount)
    {
      if (amount > AccountBalance)
      {
        return ErrorCodes.lowBalance /*"Balance is too low for this transaction"*/;
      }
      AccountBalance -= amount;
      return SuccessCodes.transactionSuccessful;
    }
  }
}
