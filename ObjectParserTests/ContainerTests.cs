using System.Linq;
using NUnit.Framework;
using ObjectParserLib.Entities;
using ObjectParserLib.Exceptions;

namespace ObjectParserTests
{
  public class ContainerTests
  {
    [Test]
    public void testContainerIsNotPersonType()
    {
      Container container = new Container("chest");
      Assert.That(container.IsPerson, Is.False);
    }

    [Test]
    public void testContainerIsNotSupporterType()
    {
      Container container = new Container("chest");
      Assert.That(container.IsSupporter, Is.False);
    }

    [Test]
    public void testContainerIsContainerType()
    {
      Container container = new Container("chest");
      Assert.That(container.IsContainer, Is.True);
    }

    [Test]
    public void testContainerIsNotThingType()
    {
      Container container = new Container("chest");
      Assert.That(container.IsThing, Is.False);
    }

    [Test]
    public void containerCanNotWearItems()
    {
      Container container = new Container("chest");
      var testDel = new TestDelegate(() => container.WearItem(new Thing("hatband")));
      Assert.That(testDel, Throws.TypeOf<CanNotWearItemsException>());
    }

    [Test]
    public void containerAddChildReturnsChild()
    {
      Container container = new Container("chest");
      var entity = new Thing("cup");
      var item = container.AddChild(entity);

      Assert.That(item.SameIdentityAs(entity), Is.True);
    }

    [Test]
    public void containerAddNullChildReturnsNull()
    {
      Container container = new Container("chest");
      var item = container.AddChild(null);

      Assert.That(item, Is.Null);
    }

    [Test]
    public void containerGetChildrenReturnsChildren()
    {
      Container container = new Container("chest");
      var entity = new Thing("cup");
      var item = container.AddChild(entity);

      var children = container.GetChildren();
      Assert.That(children.First().SameIdentityAs(item), Is.True);
    }

    [Test]
    public void containerHasChildrenReturnsTrueIfChildren()
    {
      Container container = new Container("chest");
      var entity = new Thing("cup");
      var item = container.AddChild(entity);

      Assert.That(container.HasChildren(), Is.True);
    }

    [Test]
    public void supporterHasChildrenReturnsFalseIfNoChildren()
    {
      Container container = new Container("chest");

      Assert.That(container.HasChildren(), Is.False);
    }
  }
}