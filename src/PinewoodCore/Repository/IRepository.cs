using System.Collections.Generic;

namespace PinewoodDerby.PinewoodCore
{
  public interface IRepository
  {
    public void SaveCar(Car car);
    public void DeleteCar(Car car);
    public void SaveParticipant(Participant participant);
    public void DeleteParticipant(Participant participant);
    public void SaveHeat(Heat heat);
    public void DeleteHeat(Heat heat);
    public void SaveRaceGroup(RaceGroup group);
    public void DeleteRaceGroup(RaceGroup group);
    public void SaveResults(IEnumerable<Result> results);
    public void DeleteResult(Result result);
    public void SaveEntity(Entity entity);
    public void DeleteEntity(Entity entity);
    public void SaveRace(Race race);
    public void DeleteRace(Race race);
  }
}
