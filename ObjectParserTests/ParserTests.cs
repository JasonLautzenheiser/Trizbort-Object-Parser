using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using ObjectParserLib;

namespace ObjectParserTests
{
  [TestFixture]
  public class ParserTests
  {
    [Test]
    public void SetObjectTextReturnsObjectText()
    {
      var parser = new Parser();
      parser.Parse("this is a test");
      Assert.That(parser.ObjectText == "this is a test", Is.True);
    }

    [Test]
    public void NewParserHasEmptyObjectList()
    {
      var parser = new Parser();
      Assert.That(parser.Objects.Count == 0, Is.True);

    }

    [Test]
    public void ParseEmptyStringReturnsEmptyObjectList()
    {
      var parser = new Parser();
      parser.Parse(string.Empty);
      Assert.That(parser.Objects.Count, Is.EqualTo(0));
    }

    [Test]
    public void ParseStringWithOneLineReturnsOneObject()
    {
      var parser = new Parser();
      parser.Parse("Lamp");
      Assert.That(parser.Objects.Count, Is.EqualTo(1));
    }

    [Test]
    public void ParseStringWithOneLineEndsInCarriageReturnRetunsOneObject()
    {
      var parser = new Parser();
      parser.Parse("Lamp" + Environment.NewLine);
      Assert.That(parser.Objects.Count, Is.EqualTo(1));
    }

    [Test]
    public void ParseStringWithTwoLinesReturnsTwoObjects()
    {
      var parser = new Parser();
      parser.Parse("Lamp" + Environment.NewLine + "Table");
      Assert.That(parser.Objects.Count, Is.EqualTo(2));
    }

    [Test]
    public void ParseStringWithOneItemReturnsOneWithNameSet()
    {
      var parser = new Parser();
      parser.Parse("Lamp " + Environment.NewLine);
      Assert.That(parser.Objects.First().Name, Is.EqualTo("Lamp"));
    }

    [Test]
    public void ParseStringWithOneItemAndAttributesReturnsOneWithNameSet()
    {
      var parser = new Parser();
      parser.Parse("Lamp [ABC]" + Environment.NewLine);
      Assert.That(parser.Objects.First().Name, Is.EqualTo("Lamp"));
    }
  }
}