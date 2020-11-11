using System;
using System.Collections.Generic;
using System.Linq;

namespace PinewoodDerby.PinewoodCore
{
  public sealed class Participant
  {
    public string Name { get; set; }
    public int Id { get; set; } 
    public List<int> Cars { get; set; } = new();

    public void AddCar(int carId)
    {
      Cars.Add(carId);
    }
  }
}

