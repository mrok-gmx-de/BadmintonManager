﻿using System;

namespace NetzWerkPlan.BadmintionManager.CrossCutting.DataClasses
{
    public class Player
    {
      public Guid Id { get; set; }
      public int Rating { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
}
