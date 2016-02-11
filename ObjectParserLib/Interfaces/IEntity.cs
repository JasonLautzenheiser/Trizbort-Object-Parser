using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectParserLib.Interfaces
{
  public interface IEntity
  {
    string Name { get; }
    bool Scenery { get; set; }

    IEntity AddChild(IEntity child);
    IList<IEntity> GetChildren();
    bool HasChildren();

    IEntity AddPart(IEntity child);
    IList<IEntity> GetParts();
    bool HasParts();

    bool SameIdentityAs(IEntity other);
    IEntity WearItem(IEntity item);

    bool IsPerson();
    bool IsSupporter();
    bool IsContainer();
    bool IsThing();

  }
}