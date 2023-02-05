namespace Factory;

public abstract class Notification
{
    public abstract string Name { get; set; }

    public override string ToString() => $"type: {this.Name}";
}

public class Email : Notification
{
    public override string Name { get; set; } = "Email";
}

public class Phone : Notification
{
    public override string Name { get; set; } = "Sms";
}

public abstract class SendNotify
{
    public abstract Notification Notification { get; }

    public void Send(string message)
    {
        Console.WriteLine($"send {this.Notification} message: {message}");
    }
}

public class SendEmailNotify : SendNotify
{
    public override Notification Notification
    {
        get => new Email();
    }
}

public class SendPhoneNotify : SendNotify
{
    public override Notification Notification
    {
        get => new Phone();
    }
}

public class User
{
    public string Name;

    public event DelNotify Notify;

    public delegate void DelNotify(string message);

    public void SendNotify()
    {
        this.Notify.Invoke(this.Name);
    }
}