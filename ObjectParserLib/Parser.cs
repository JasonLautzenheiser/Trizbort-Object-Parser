using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ObjectParserLib.Entities;
using ObjectParserLib.Exceptions;
using ObjectParserLib.Interfaces;
using Container = ObjectParserLib.Entities.Container;

namespace ObjectParserLib
{
  public class Parser
  {
    private Settings Settings { get; set; }
    public string ObjectText { get; private set; }

    public List<IEntity> Objects { get; private set; }

    public Parser()
    {
      init();
    }

    private void init()
    {
      Settings = new Settings();
      Objects = new List<IEntity>();
    }

    public List<IEntity> Parse(string objectString)
    {
      ObjectText = objectString;
      Objects = new List<IEntity>();

      if (objectString == string.Empty)
      {
        return Objects;
      }

      string[] objectArray = objectString.Split(new string[] { Settings.ObjectDelimiter}, StringSplitOptions.RemoveEmptyEntries);

      foreach (var s in objectArray)
      {
        var attributes = getObjectAttributes(s);

        var sName = attributes != string.Empty ? s.Replace(attributes, string.Empty) : s;
        IEntity entity = null;

        if (attributes != string.Empty)
        {
          attributes = attributes.Replace("[", string.Empty).Replace("]", string.Empty);

          if (attributes.IndexOfAny("mM".ToCharArray()) != -1)
          {
            entity = new Person(sName);
            ((Person)entity).Gender = Gender.Male;
          }

          if (attributes.IndexOfAny("fF".ToCharArray()) != -1)
          {
            if (entity != null && entity.IsPerson())
              throw new PersonCannotBeTwoGenders();

            entity = new Person(sName);
            ((Person)entity).Gender = Gender.Female;
          }

          if (attributes.IndexOfAny("pP".ToCharArray()) != -1)
          {
            if (entity != null && entity.IsPerson())
              throw new PersonCannotBeTwoGenders();

            entity = new Person(sName);
            ((Person)entity).Gender = Gender.Neutral;
          }

          if (attributes.IndexOfAny("cC".ToCharArray()) != -1)
          {
            if (entity != null && entity.IsPerson())
              throw new PersonCannotBeContainer();

            entity = new Container(sName);
          }

          if (attributes.IndexOfAny("uU".ToCharArray()) != -1)
          {
            if (entity != null && entity.IsPerson())
              throw new PersonCannotBeSupporter();

            entity = new Supporter(sName);
          }

          if (attributes.IndexOfAny("sS".ToCharArray()) != -1)
          {
            if (entity != null && entity.IsPerson())
            {
              throw new PersonCannotBeScenery();
            }
            entity = new Thing(sName) {Scenery = true};
          }
        }
        else
        {
          entity = new Thing(sName);
        }

        Objects.Add(entity);

      }

      return Objects;
    }

    private string getObjectAttributes(string objectString)
    {
      Regex ex = new Regex(@"\[(.+)\]");
      var match = ex.Match(objectString).Groups[0];
      return match.Value;
    }
  }
}