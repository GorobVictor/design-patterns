using Factory;
using Singleton;
using Prototype;

namespace Test;

public abstract class Test
{
    public static async Task Main()
    {
        // await TestSingleton();
        // TestPrototype();
        TestFactory();
    }

    static async Task TestSingleton()
    {
        var tasks = new List<Task>();

        for (var i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                var cons = Constant.GetInstance();
                Console.WriteLine(cons.GetHashCode());
            }));
        }

        await Task.WhenAny(tasks.ToArray());
    }

    static void TestPrototype()
    {
        var prot = new Prototype.User(1, "name", "description");
        var prot1 = prot;
        var prot2 = prot.Clone() as Prototype.User;
        Console.WriteLine($"prot: {prot.GetHashCode()}, {prot}");
        Console.WriteLine($"prot1: {prot1.GetHashCode()}, {prot1}"); // prot.GetHashCode() == prot1.GetHashCode()
        Console.WriteLine($"prot2: {prot2.GetHashCode()}, {prot2}");

        prot1.Name = "name after";
        prot2.Name = "name after two";
        prot2.Id.Id = 55;

        Console.WriteLine($"prot: {prot.GetHashCode()}, {prot}");
        Console.WriteLine($"prot1: {prot1.GetHashCode()}, {prot1}");
        Console.WriteLine($"prot2: {prot2.GetHashCode()}, {prot2}");
    }

    static void TestFactory()
    {
        var user = new Factory.User() { Name = "James" };

        user.Notify += new SendEmailNotify().Send;
        user.Notify += new SendPhoneNotify().Send;

        user.SendNotify();
    }
}