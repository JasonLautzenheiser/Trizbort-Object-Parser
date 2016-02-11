using System;

namespace ObjectParserLib
{
  public class Settings
  {
    public string ObjectDelimiter { get; private set; } = Environment.NewLine;
    public string ChildIndicator { get; private set; } = "+";
    public string Attributes { get; private set; } = "[*]";
  }
}