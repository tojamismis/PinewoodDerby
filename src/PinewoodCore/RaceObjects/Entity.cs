using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinewoodDerby.PinewoodCore
{
  public sealed class Entity
  {
    public string EntityName { get; set; }
    public string EntityId { get; set; }
    public List<Race> Races { get; set; }

    public void AddRace(DateTimeOffset raceDate, string raceLocation, int numberOfTracks)
    {
      if(!Races.Any(d => d.RaceDate == raceDate))
      {
        Races.Add(new Race(numberOfTracks, raceDate, raceLocation));
      }
    }

    public void CloneLastRace(DateTimeOffset newRaceDate)
    {
      var date = Races.Max(r => r.RaceDate);
      CloneRaceFrom(newRaceDate, date);
    }

    public void CloneRaceFrom(DateTimeOffset newRaceDate, DateTimeOffset lastRaceDate)
    {
      var lastRace = Races.Where(r => r.RaceDate == lastRaceDate).FirstOrDefault();
      var newRace = new Race(lastRace.NumberOfTracks, newRaceDate, lastRace.RaceLocation);
      foreach(var group in lastRace.Groups)
      {
        newRace.AddRaceGroup(group.Name);
      }
      Races.Add(newRace);
    }
  }
}
