using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Singleton;

public class Constant
{
    private Constant()
    {
        if (!File.Exists("constant.json"))
            throw new Exception("constant.json not found");

        var cons = JObject.Parse(File.ReadAllText("constant.json"));

        if (cons == null)
            throw new Exception("cons == null");

        this.Domain = cons.Value<string>("domain")!;
        this.ConnectionString = cons.Value<string>("connectionString")!;
    }

    private static Constant? _instance { get; set; }

    private static readonly object _lock = new object();

    public static Constant GetInstance()
    {
        if (_instance != null) return _instance;

        lock (_lock)
        {
            _instance ??= new Constant();
        }

        return _instance;
    }

    public string Domain { get; set; }

    public string ConnectionString { get; set; }

    public override string ToString() => $"{this.Domain}:{this.ConnectionString}";
}