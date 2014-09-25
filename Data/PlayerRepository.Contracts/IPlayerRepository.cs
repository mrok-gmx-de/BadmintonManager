using System;
using System.Collections.Generic;
using NetzWerkPlan.BadmintionManager.CrossCutting.DataClasses;

namespace NetzWerkPlan.BadmintonManager.Data.PlayerRepository.Contracts
{
  public interface IPlayerRepository
  {
    IEnumerable<Player> GetAll();
    void Save(Player player);
    void Remove(Player player);
    void Remove(Guid id);
  }
}