using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectParserLib.Interfaces
{
  public interface IEntity
  {
    Guid ID { get; }
    string Name { get; }
    bool Worn { get; }
    bool Part { get; }

    IEntity AddChild(IEntity child);
    IList<IEntity> GetChildren();
    bool HasChildren();

    IEntity AddPart(IEntity child);
    IList<IEntity> GetParts();
    bool HasParts();

    bool SameIdentityAs(IEntity other);
    IEntity WearItem(IEntity item);
  }
}