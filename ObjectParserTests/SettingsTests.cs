using System;
using NUnit.Framework;
using ObjectParserLib;

namespace ObjectParserTests
{
  [TestFixture]
  public class SettingsTests
  {

    [Test]
    public void DefaultConstructorSetsDefaultSettings()
    {
      var settings = new Settings();

      Assert.That(settings.Attributes == "[*]" && settings.ChildIndicator == "+" && settings.ObjectDelimiter == Environment.NewLine, Is.True);
    }

    [Test]
    public void ConstructorSetsValues()
    {
      var settings = new Settings("|", "-", "A");
      Assert.That(settings.Attributes == "A" && settings.ChildIndicator == "-" && settings.ObjectDelimiter == "|", Is.True);
    }
  }
}