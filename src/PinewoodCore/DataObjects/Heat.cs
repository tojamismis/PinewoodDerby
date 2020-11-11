using System;
using System.Collections.Generic;
using System.Linq;

namespace PinewoodDerby.PinewoodCore
{
  public sealed class Heat
  {
    public int Id { get; set; }
    public List<int> Results { get; set; } = new();
    public DateTimeOffset RunTime { get; set; }
    public int Round { get; set; }

    public IEnumerable<Result> GetResults(Race race)
    {
      return race.Results.Where(r => Results.Contains(r.Id));
    }
  }
}

