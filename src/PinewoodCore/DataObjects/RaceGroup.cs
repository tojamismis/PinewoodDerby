using System;
using System.Collections.Generic;
using System.Linq;

namespace PinewoodDerby.PinewoodCore
{
  public class RaceGroup
  {
    public int RaceId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Participants { get; set; } = new();

    public void AddParticipant(int participantId)
    {
      Participants.Add(participantId);
    }
  }
}

