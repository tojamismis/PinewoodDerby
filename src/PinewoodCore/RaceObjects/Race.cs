using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace PinewoodDerby.PinewoodCore
{
  public class Race
  {
    public List<RaceGroup> Groups { get; set; } = new();
    public List<Participant> Participants { get; set; } = new();
    public List<Car> Cars { get; set; } = new();
    public List<Result> Results { get; set; } = new();
    public List<Heat> Heats { get; set; } = new();
    public int NumberOfTracks { get; set; }
    public DateTimeOffset RaceDate { get; set; }
    public int RaceId { get; set; }
    public string RaceLocation { get; set; }
    public int CurrentRaceGroup { get; set; }
    public int CurrentHeat { get; set; }
    public int CurrentRound { get; set; }
    public int TotalRunsPerCar { get; set; }

    public Race()
    {
    }

    internal Race(int tracks, DateTimeOffset raceDate, string raceLocation)
    {
      NumberOfTracks = tracks;
      RaceDate = raceDate;
      RaceLocation = raceLocation;
    }

    public void LoadRace(int RaceId)
    {

    }

    public void AddParticipant(string name, int raceGroupId)
    {
      lock(Participants)
      {
        var id = Participants.Count;
        Participants.Add(new Participant() { Id = id, Name = name });
        Groups.Where(g => g.Id == raceGroupId).FirstOrDefault().AddParticipant(id);
      }
    }

    public void DeleteParticipant(int participantId)
    {
      lock(Participants)
      {
        var participant = Participants.Where(p => p.Id == participantId).FirstOrDefault();
        foreach(var carId in participant.Cars)
        {
          if(!Participants.Any(p => p.Cars.Contains(carId)))
          {
            DeleteCar(carId);
          }
        }
        Participants.Remove(participant);
      }
    }

    public void AddRaceGroup(string name)
    {
      lock(Groups)
      {
        var id = Groups.Count;
        Groups.Add(new RaceGroup() { Id = id, Name = name, RaceId = this.RaceId });
      }
    }

    public void DeleteRaceGroup(string name)
    {
      lock(Groups)
      {
        var group = Groups.Where(g => g.Name == name).FirstOrDefault();
        Groups.Remove(group);
      }
    }

    public void AddCar(string name, double weight, IList<int> participantIds)
    {
      lock (Cars)
      {
        var id = Cars.Count;
        Cars.Add(new Car() { Id = Cars.Count, Name = name, Weight = weight });
        foreach(var p in Participants.Where(p => participantIds.Contains(p.Id)))
        {
          p.AddCar(id);
        }
      }
    }

    public void DeleteCar(int carId)
    {
      lock (Cars)
      {
        var car = Cars.Where(c => c.Id == carId).FirstOrDefault();
        Cars.Remove(car);
        lock(Participants)
        {
          foreach(var p in Participants.Where(p => p.Cars.Contains(carId)))
          {
            p.Cars.Remove(carId);
          }
        }
      }
    }

    public List<Result> CreateNewHeat(IList<int> carIds)
    {
      lock (Heats)
      {
        var newHeatId = Heats.Count;
        Heat newHeat = new Heat() { Id = newHeatId };

        lock (Results)
        {
          foreach (var carId in carIds)
          {
            var result = new Result()
            {
              CarId = carId,
              Heat = newHeatId,
              Id = Results.Count,
              RaceId = this.RaceId
            };
            newHeat.Results.Add(result.Id);
            Results.Add(result);
          }
        }
      }
      return Results.Where(r => r.Track == -1).ToList();
    }
  }
}

