using System;
using System.Linq;
using NUnit.Framework;
using ObjectParserLib.Entities;
using ObjectParserLib.Exceptions;
using ObjectParserLib.Interfaces;

namespace ObjectParserTests
{
  [TestFixture]
  public class ThingTests
  {
    [Test]
    public void testThingIsNotPersonType()
    {
      Thing thing = new Thing("lantern");
      Assert.That(thing.IsPerson, Is.False);
    }

    [Test]
    public void testThingIsNotSupporterType()
    {
      Thing thing = new Thing("lantern");
      Assert.That(thing.IsSupporter, Is.False);
    }

    [Test]
    public void testThingIsNotContainerType()
    {
      Thing thing = new Thing("lantern");
      Assert.That(thing.IsContainer, Is.False);
    }

    [Test]
    public void testThingIsThingType()
    {
      Thing thing = new Thing("lantern");
      Assert.That(thing.IsThing, Is.True);
    }

    [Test]
    public void createEmptyThingReturnsAUniqueThing()
    {
      Thing thing = new Thing("book");
      Assert.That(thing.SameIdentityAs(new Thing("book")), Is.True);
    }

    [Test]
    public void hasChildrenOnReturnsFalseOnEmptyThing()
    {
      Thing thing = new Thing("Lantern");
      Assert.That(thing.HasChildren, Is.False);
    }


    [Test]
    public void addChildToThingThrowsException()
    {
      Thing thing = new Thing("lantern");

      var testDel = new TestDelegate(() => thing.AddChild(new Thing("fork")));
      Assert.That(testDel, Throws.TypeOf<NoChildrenForThingsException>());
    }

    [Test]
    public void getChildrenOfThingReturnsNull()
    {
      Thing thing = new Thing("lantern");
      var children = thing.GetChildren();

      Assert.That(children, Is.Null);
    }

    [Test]
    public void thingCanNotWearItems()
    {
      Thing thing = new Thing("hat");
      var testDel = new TestDelegate(() => thing.WearItem(new Thing("hatband")));
      Assert.That(testDel, Throws.TypeOf<CanNotWearItemsException>());
    }

    [Test]
    public void addPartOfReturnsHasPartTrue()
    {
      Thing thing = new Thing("hat");
      thing.AddPart(new Thing("hatband"));
      Assert.That(thing.HasParts,Is.True);
    }

    [Test]
    public void addPartOfReturnsTheAddedPart()
    {
      Thing thing = new Thing("hat");
      var thing2 = thing.AddPart(new Thing("hatband"));
      Assert.That(thing.HasParts,Is.True);
    }

    [Test]
    public void addNullPartReturnsNull()
    {
      Thing thing = new Thing("hat");
      var thing2 = thing.AddPart(null);
      Assert.That(thing2, Is.Null);
    }

    [Test]
    public void thingIsPartOf()
    {
      Thing thing = new Thing("hat");
      var thing2 = new Thing("hatband");

      thing.AddPart(thing2);
      Assert.That(thing2.IsPartOf, Is.True);

    }

    [Test]
    public void getPartsReturnsPartsofThing()
    {
      Thing thing = new Thing("hat");
      var thing2 = thing.AddPart(new Thing("hatband"));
      Assert.That(thing.GetParts().First().SameIdentityAs(thing2), Is.True);

    }

    [Test]
    public void thingIsWorn()
    {
      Person person = new Person("Jason");
      Thing thing = new Thing("hat");

      person.WearItem(thing);
      Assert.That(thing.IsWorn, Is.True);
    }

  }
}
