namespace ObjectParserLib.Entities
{
  public class Container :Entity
  {
    public Container(string name) : base(name)
    {
    }

    public override bool IsPerson()
    {
      return false;
    }

    public override bool IsSupporter()
    {
      return false;
    }

    public override bool IsContainer()
    {
      return true;
    }

    public override bool IsThing()
    {
      return false;
    }
  }
}