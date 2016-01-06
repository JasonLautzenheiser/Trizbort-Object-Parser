namespace ObjectParserLib.Entities
{
  public class Supporter :Entity
  {
    public Supporter(string name) : base(name)
    {
    }

    public override bool IsPerson()
    {
      return false;
    }

    public override bool IsSupporter()
    {
      return true;
    }

    public override bool IsContainer()
    {
      return false;
    }

    public override bool IsThing()
    {
      return false;
    }
  }
}