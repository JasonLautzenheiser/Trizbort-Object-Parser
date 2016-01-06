using System;
using System.Collections.Generic;
using ObjectParserLib.Interfaces;

namespace ObjectParserLib.Entities
{
  public class Person : Entity
  {
    private IList<IEntity> clothing;
    public Person(string name) : base(name)
    {
      clothing = new List<IEntity>();
      Worn = false;
      Part = false;
      
    }

    public IEntity CarryItem(IEntity item)
    {
      if (item == null) return null;
      var carried = this.AddChild(item);
      return carried;
    }

    public override IEntity WearItem(IEntity item)
    {
      if (item == null) return null;
      clothing.Add(item);
      return item;
    }

    public IList<IEntity> GetClothing()
    {
      return clothing;
    }

    public override bool IsPerson()
    {
      return true;
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
      return false;
    }
  }
}