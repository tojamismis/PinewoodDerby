using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinewoodDerby.PinewoodCore
{
  public sealed class RaceRunner
  {
    private readonly Race race;

    public RaceRunner(Race race, int runsPerCar)
    {
      this.race = race;
      race.TotalRunsPerCar = runsPerCar;
    }

    public IList<Result> GetNextHeat()
    {
      
    }

    public Heat GetHeat(int heatId)
    {
      return race.Heats.Where(h => h.Id == heatId).FirstOrDefault();
    }

    public void SaveHeat(IList<Result> results)
    {

    }

    private List<Result> CalculateNextHeat()
    {
      var group = race.CurrentRaceGroup;
      var cars = CalculateCarList(group);
      var results = race.Results.Where(r => cars.Contains(r.CarId));
    }

    private List<int> CalculateCarList(int currentGroup)
    {
      var raceGroup = race.Groups.Where(g => g.Id == currentGroup).FirstOrDefault();

      List<int> carIds = new();

      foreach(var p in race.Participants.Where(p => raceGroup.Participants.Contains(p.Id)))
      {
        foreach(int id in p.Cars)
        {
          if(!carIds.Contains(id))
          {
            carIds.Add(id);
          }
        }
      }
      return carIds;
    }
  }
}
