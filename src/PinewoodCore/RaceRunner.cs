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
      var results = race.Results.Where(r => cars.Contains(r.CarId))
        .GroupBy(c => c.CarId)
        .Select(r => new { CarId = r.Key, Count = r.Count() });
      var max = results.Max(c => c.Count);
      IEnumerable<int> carIds;
      if (max < race.CurrentHeat)
      {
        carIds = cars.Take(race.NumberOfTracks);
      }
      else
      {
        carIds = results.Where(c => c.Count < max).Take(race.NumberOfTracks).Select(c => c.CarId);
      }
      if(carIds.Count() == 0)
      {
        var nextGroup = 
      }

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
