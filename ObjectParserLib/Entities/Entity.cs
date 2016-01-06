using System;
using System.Collections.Generic;
using ObjectParserLib.Exceptions;
using ObjectParserLib.Interfaces;

namespace ObjectParserLib.Entities
{
  public abstract class Entity :IEntity
  {
    private readonly List<IEntity> children;
    private readonly List<IEntity> parts;

    protected Entity(string name)
    {
      Name = name;
      ID = Guid.NewGuid();
      children = new List<IEntity>();
      parts = new List<IEntity>();
    }

    public Guid ID { get; }
    public string Name { get; }
    public bool Worn { get; protected set; }
    public bool Part { get; protected set; }

    public virtual IEntity WearItem(IEntity item)
    {
      throw new CanNotWearItemsException();
    }

    public virtual IEntity AddChild(IEntity child)
    {
      if (child == null) return null;
      children.Add(child);
      return child;
    }

    public virtual IList<IEntity> GetChildren()
    {
      return children;
    }

    public virtual bool HasChildren()
    {
      return children.Count > 0;
    }

    public IEntity AddPart(IEntity child)
    {
      if (child == null) return null;
      parts.Add(child);
      return child;
    }

    public IList<IEntity> GetParts()
    {
      return parts;
    }

    public bool HasParts()
    {
      return parts.Count > 0;
    }

    public bool SameIdentityAs(IEntity other)
    {
      return other != null && Name.Equals(other.Name);
    }

    public abstract bool IsPerson();
    public abstract bool IsSupporter();
    public abstract bool IsContainer();
    public abstract bool IsThing();
  }
}