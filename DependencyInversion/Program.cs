namespace DependencyInversion;

//This is a bad example


//Notice that the Notification class, a higher-level class, has a dependency on both the Email class and the SMS class, which are lower-level classes
// In other words, Notification is depending on the concrete implementation of both Email and SMS, not an abstraction of said implementation.
// So we are currently violating the Dependency Inversion Principle.



//public class Email
//{
//    public string ToAddress { get; set; }
//    public string Subject { get; set; }
//    public string Content { get; set; }
//    public void SendEmail()
//    {
//        Console.WriteLine("Send email");
//    }
//}

//public class SMS
//{
//    public string PhoneNumber { get; set; }
//    public string Message { get; set; }
//    public void SendSMS()
//    {
//        Console.WriteLine("Send SMS");

//    }
//}

//public class Notification
//{
//    private Email _email;
//    private SMS _sms;
//    public Notification()
//    {
//        _email = new Email();
//        _sms = new SMS();
//    }

//    public void Send()
//    {
//        _email.SendEmail();
//        _sms.SendSMS();
//    }
//}

public interface IMessage
{
    void SendMessage();
}

public class Email : IMessage
{
    public string ToAddress { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public void SendMessage()
    {
        Console.WriteLine("Send email");
    }
}

public class SMS : IMessage
{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public void SendMessage()
    {
        Console.WriteLine("Send SMS");

    }
}
public class Notification
{
    private ICollection<IMessage> _messages;
    public Notification(ICollection<IMessage> messages)
    {
        this._messages = messages;
    }
    public void Send()
    {
        foreach (var message in _messages)
        {
            message.SendMessage();
        }
    }
}
//With this example, all Notification cares about is that there's an abstraction (the interface IMessage) that can actually send the notification
//So it just calls that 

//In short, we have allowed both high-level and low-level classes to rely on abstractions.