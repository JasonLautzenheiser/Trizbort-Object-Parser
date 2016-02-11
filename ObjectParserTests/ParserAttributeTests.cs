using System.Linq;
using NUnit.Framework;
using ObjectParserLib;
using ObjectParserLib.Entities;
using ObjectParserLib.Exceptions;

namespace ObjectParserTests
{
  [TestFixture]
  public class ParserAttributeTests
  {
    [Test]
    public void ObjectWithMAttributeIsMalePerson()
    {
      var parser = new Parser();
      parser.Parse("Jason [m]");

      Assert.That(parser.Objects.First().IsPerson() , Is.True);
      Assert.That(((Person)parser.Objects.First()).IsMale() , Is.True);

    }

    [Test]
    public void ObjectWithFAttributeIsFemalePerson()
    {
      var parser = new Parser();
      parser.Parse("Jason [f]");

      Assert.That(parser.Objects.First().IsPerson() , Is.True);
      Assert.That(((Person)parser.Objects.First()).IsFemale() , Is.True);

    }

    [Test]
    public void ObjectWithPAttributeIsNeutralPerson()
    {
      var parser = new Parser();
      parser.Parse("Jason [p]");

      Assert.That(parser.Objects.First().IsPerson() , Is.True);
      Assert.That(((Person)parser.Objects.First()).IsNeutral() , Is.True);

    }


    [Test]
    public void ObjectWithUAttributeIsSupporter()
    {
      var parser = new Parser();
      parser.Parse("Jason [u]");

      Assert.That(parser.Objects.First().IsSupporter, Is.True);

    }

    [Test]
    public void ObjectWithCAttributeIsContainer()
    {
      var parser = new Parser();
      parser.Parse("Jason [c]");

      Assert.That(parser.Objects.First().IsContainer, Is.True);

    }

    [Test]
    public void ObjectWithBothMaleAndFemaleAttributesThrows()
    {
      var parser = new Parser();
      

      var testDel = new TestDelegate(() => parser.Parse("Jason [mf]"));
      Assert.That(testDel, Throws.TypeOf<PersonCannotBeTwoGenders>());

    }

    [Test]
    public void ObjectWithBothMaleAndNeutralAttributesThrows()
    {
      var parser = new Parser();
      

      var testDel = new TestDelegate(() => parser.Parse("Jason [mp]"));
      Assert.That(testDel, Throws.TypeOf<PersonCannotBeTwoGenders>());

    }

    [Test]
    public void ObjectWithPersonAndContainerAttributesThrows()
    {
      var parser = new Parser();
      

      var testDel = new TestDelegate(() => parser.Parse("Jason [cp]"));
      Assert.That(testDel, Throws.TypeOf<PersonCannotBeContainer>());

    }

    [Test]
    public void ObjectWithPersonAndSupporterAttributesThrows()
    {
      var parser = new Parser();
      

      var testDel = new TestDelegate(() => parser.Parse("Jason [up]"));
      Assert.That(testDel, Throws.TypeOf<PersonCannotBeSupporter>());

    }

    [Test]
    public void ObjectWithPersonAndSceneryAttributesThrows()
    {
      var parser = new Parser();
      

      var testDel = new TestDelegate(() => parser.Parse("Jason [sp]"));
      Assert.That(testDel, Throws.TypeOf<PersonCannotBeScenery>());

    }

    [Test]
    public void ObjectWithSAttributeIsASceneryThing()
    {
      var parser = new Parser();
      parser.Parse("Jason [s]");

      Assert.That(parser.Objects.First().IsThing, Is.True);
      Assert.That(((Thing)parser.Objects.First()).IsScenery(), Is.True);

    }
  }
}