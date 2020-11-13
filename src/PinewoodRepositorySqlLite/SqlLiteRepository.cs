using PinewoodDerby.PinewoodCore;
using System;
using System.Collections.Generic;

namespace PinewoodRepository.SqlLite
{
  public sealed class SqlLiteRepository : IRepository
  {
    SqlLiteRepository()
    {
      SQLiteConnection sqlite_conn;
      sqlite_conn = CreateConnection();
      CreateTables(sqlite_conn);
    }

    static SQLiteConnection CreateConnection()
    {
      SQLiteConnection sqlite_conn;
      // Create a new database connection:
      sqlite_conn = new SQLiteConnection("Data Source=pinewood.db; Version = 3; New = True; Compress = True;");
      // Open the connection:
      try
      {
        sqlite_conn.Open();
      }
      catch (Exception ex)
      {

      }
      return sqlite_conn;
    }

    public void DeleteCar(Car car)
    {
      throw new NotImplementedException();
    }

    public void DeleteEntity(Entity entity)
    {
      throw new NotImplementedException();
    }

    public void DeleteHeat(Heat heat)
    {
      throw new NotImplementedException();
    }

    public void DeleteParticipant(Participant participant)
    {
      throw new NotImplementedException();
    }

    public void DeleteRace(Race race)
    {
      throw new NotImplementedException();
    }

    public void DeleteRaceGroup(RaceGroup group)
    {
      throw new NotImplementedException();
    }

    public void DeleteResult(Result result)
    {
      throw new NotImplementedException();
    }

    public void SaveCar(Car car)
    {
      throw new NotImplementedException();
    }

    public void SaveEntity(Entity entity)
    {
      throw new NotImplementedException();
    }

    public void SaveHeat(Heat heat)
    {
      throw new NotImplementedException();
    }

    public void SaveParticipant(Participant participant)
    {
      throw new NotImplementedException();
    }

    public void SaveRace(Race race)
    {
      throw new NotImplementedException();
    }

    public void SaveRaceGroup(RaceGroup group)
    {
      throw new NotImplementedException();
    }

    public void SaveResults(IEnumerable<Result> results)
    {
      throw new NotImplementedException();
    }
  }
}
