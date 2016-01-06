using System.Linq;
using NUnit.Framework;
using ObjectParserLib.Entities;

namespace ObjectParserTests
{
  [TestFixture]
  public class PeopleTests
  {
    [Test]
    public void testPersonIsPersonType()
    {
      Person person = new Person("Jason");
      Assert.That(person.IsPerson, Is.True);
    }

    [Test]
    public void testPersonIsNotSupporterType()
    {
      Person person = new Person("Jason");
      Assert.That(person.IsSupporter, Is.False);
    }

    [Test]
    public void testPersonIsNotContainerType()
    {
      Person person = new Person("Jason");
      Assert.That(person.IsContainer, Is.False);
    }

    [Test]
    public void testPersonIsNotThingType()
    {
      Person person = new Person("Jason");
      Assert.That(person.IsThing, Is.False);
    }

    [Test]
    public void createPersonCreatesTwoObjectsSameName()
    {
      Person person = new Person("Jason");
      Assert.That(person.SameIdentityAs(new Person("Jason")), Is.True);
    }

    [Test]
    public void personWearsItemItIsWorn()
    {
      Person person = new Person("John");
      Thing thing = new Thing("Hat");

      person.WearItem(thing);
      var clothes = person.GetClothing();

      Assert.That(clothes.First().SameIdentityAs(thing));
    }

    [Test]
    public void personWearsNullItemReturnsNull()
    {
      Person person = new Person("John");
      var item = person.WearItem(null);

      Assert.That(item, Is.Null);
    }

    [Test]
    public void personCarriesThingReturnsCarriedThing()
    {
      Person person = new Person("John");
      Thing thing = new Thing("Hat");

      var item = person.CarryItem(thing);
      Assert.That(item, Is.EqualTo(thing));
    }

    [Test]
    public void personCarriesNullItemReturnsNull()
    {
      Person person = new Person("John");
      Assert.That(person.CarryItem(null), Is.Null);
    }
  }
}