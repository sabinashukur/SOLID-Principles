namespace OpenClosed;

//This is a bad example.

//if we want to add another new invoice type,
//then we need to add one more “else if” condition in the same “GetInvoiceDiscount” method.
//in other words, we need to modify the Invoice class.



//public class Invoice
//{
//    public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
//    {
//        double finalAmount = 0;
//        if (invoiceType == InvoiceType.FinalInvoice)
//        {
//            finalAmount = amount - 100;
//        }
//        else if (invoiceType == InvoiceType.ProposedInvoice)
//        {
//            finalAmount = amount - 50;
//        }
//        return finalAmount;
//    }
//}
//public enum InvoiceType
//{
//    FinalInvoice,
//    ProposedInvoice
//};


public class Invoice
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

public class FinalInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}
public class ProposedInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 40;
    }
}
public class RecurringInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 30;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Invoice FInvoice = new FinalInvoice();
        Invoice PInvoice = new ProposedInvoice();
        Invoice RInvoice = new RecurringInvoice();

        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
        double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);

        Console.WriteLine(FInvoiceAmount);
        Console.WriteLine(PInvoiceAmount);
        Console.WriteLine(RInvoiceAmount);
    }
}

//Now, the Invoice class is closed for modification.
//But it is open for the extension as it allows creating new classes deriving from the Invoice class.
//So if another Invoice Type needs to be added then we just need to create a new class by inheriting it from the Invoice class.
//The point that we need to keep the focus on is we are not changing the code of the Invoice class.