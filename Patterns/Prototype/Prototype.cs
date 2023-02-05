using Newtonsoft.Json;

namespace Prototype;

public class User : ICloneable
{
    public User()
    {
    }

    public User(int id, string name, string description)
    {
        this.Id = new IdInfo(id);
        this.Name = name;
        this.Description = description;
    }

    public IdInfo? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);

    public object Clone()
    {
        var result = this.MemberwiseClone() as User;

        result.Id = result.Id.Clone() as IdInfo;
        
        return result;
    }
}

public class IdInfo : ICloneable
{
    public IdInfo()
    {
    }

    public IdInfo(int? id)
    {
        Id = id;
    }

    public int? Id { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}