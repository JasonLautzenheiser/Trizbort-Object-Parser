using System.Collections.Generic;
using ObjectParserLib.Exceptions;
using ObjectParserLib.Interfaces;

namespace ObjectParserLib.Entities
{
  public class Thing : Entity
  {

    public Thing(string name) : base(name)
    {
    }

    public override IEntity AddChild(IEntity child)
    {
      throw new NoChildrenForThingsException();
    }

    public override IList<IEntity> GetChildren()
    {
      return null;
    }

    public override bool HasChildren()
    {
      return false;
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
      return false;
    }

    public override bool IsThing()
    {
      return true;
    }

    public bool IsScenery()
    {
      return Scenery;
    }
  }
}