using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using ObjectParserLib.Entities;
using ObjectParserLib.Exceptions;

namespace ObjectParserTests
{
  [TestFixture]
  public class SupporterTests
  {
    [Test]
    public void testPersonIsPersonType()
    {
      Supporter supporter = new Supporter("table");
      Assert.That(supporter.IsPerson, Is.False);
    }

    [Test]
    public void testPersonIsNotSupporterType()
    {
      Supporter supporter = new Supporter("table");
      Assert.That(supporter.IsSupporter, Is.True);
    }

    [Test]
    public void testPersonIsNotContainerType()
    {
      Supporter supporter = new Supporter("table");
      Assert.That(supporter.IsContainer, Is.False);
    }

    [Test]
    public void testPersonIsNotThingType()
    {
      Supporter supporter = new Supporter("table");
      Assert.That(supporter.IsThing, Is.False);
    }

    [Test]
    public void supporterCanNotWearItems()
    {
      Supporter supporter = new Supporter("table");
      var testDel = new TestDelegate(() => supporter.WearItem(new Thing("hatband")));
      Assert.That(testDel, Throws.TypeOf<CanNotWearItemsException>());
    }

    [Test]
    public void supporterAddChildReturnsChild()
    {
      Supporter supporter = new Supporter("table");
      var entity = new Thing("cup");
      var item = supporter.AddChild(entity);

      Assert.That(item.SameIdentityAs(entity), Is.True);
    }

    [Test]
    public void supporterAddNullChildReturnsNull()
    {
      Supporter supporter = new Supporter("table");
      var item = supporter.AddChild(null);

      Assert.That(item, Is.Null);
    }

    [Test]
    public void supporterGetChildrenReturnsChildren()
    {
      Supporter supporter = new Supporter("table");
      var entity = new Thing("cup");
      var item = supporter.AddChild(entity);

      var children = supporter.GetChildren();
      Assert.That(children.First().SameIdentityAs(item), Is.True);
    }

    [Test]
    public void supporterHasChildrenReturnsTrueIfChildren()
    {
      Supporter supporter = new Supporter("table");
      var entity = new Thing("cup");
      var item = supporter.AddChild(entity);

      Assert.That(supporter.HasChildren(), Is.True);
    }

    [Test]
    public void supporterHasChildrenReturnsFalseIfNoChildren()
    {
      Supporter supporter = new Supporter("table");

      Assert.That(supporter.HasChildren(), Is.False);
    }
  }
}