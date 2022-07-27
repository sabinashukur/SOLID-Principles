namespace SingleResponsibility;


//public class BankAccount
//{
//    public BankAccount() { }

//    public string AccountNumber { get; set; }
//    public decimal AccountBalance { get; set; }

//    public decimal CalculateInterest()
//    {
//        // Code to calculate Interest
//    }
//}




//This is a bad example. 
//Imagine we have a change request we received from business:

//1)Please add a new Property AccountHolderName.
//2)Some new rule has been introduced to calculate interest.

//This are totally different type of change request.
//One is changing on features; but the other one is impacting the functionality.

//We have 2 different types of reason to change one class. 
//It violates Single Responsibility principle.




public interface IBankAccount
{
    string AccountNumber { get; set; }
    decimal AccountBalance { get; set; }
}

public interface IInterestCalculator
{
    decimal CalculateInterest(IBankAccount account);
}

public class BankAccount : IBankAccount
{
    public string AccountNumber { get; set; }
    public decimal AccountBalance { get; set; }
}

public class InterestCalculator : IInterestCalculator
{
    public decimal CalculateInterest(IBankAccount account)
    {
        // Write your logic here
        return 1000;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}

//Now our BankAccount class is just responsible for properties of the bank account.
//If we want to add any new business rule for the Calculation of Interest, we don't need to change BankAccount class.

//And also InterestCalculator class requires no changes, in case we need to add a new Property AccountHolderName.
