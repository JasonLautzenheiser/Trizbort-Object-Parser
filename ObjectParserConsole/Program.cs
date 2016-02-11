using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectParserLib;

namespace ObjectParserConsole
{
  class Program
  {
    static void Main(string[] args)
    {

      var parser = new Parser();
      var tree = parser.Parse("Lamp [ABC]");
    }
  }
}
