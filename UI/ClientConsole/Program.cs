using System;
using System.Collections.Generic;
using System.Linq;
using NetzWerkPlan.BadmintionManager.CrossCutting.DataClasses;
using NetzWerkPlan.BadmintionManager.CrossCutting.Logging.Contracts;
using NetzWerkPlan.BadmintionManager.Infrastructure.DependencyInjection;
using NetzWerkPlan.BadmintonManager.Data.PlayerRepository.Contracts;
using Ninject;

namespace NetzWerkPlan.BadmintionManager.UI.ClientConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      var kernel = new StandardKernel(MappingsAggregator.Mappings.ToArray());
      var logger = kernel.Get<ILogger>();

      var repo = kernel.Get<IPlayerRepository>();

      IEnumerable<Player> players = repo.GetAll().Where(player => player.FirstName == "Olli" && player.LastName == "Kolligs");

      players = players.Where(p => p.Rating > 20);
      var x = players.Select(p => new {p.LastName, p.Rating});

      Console.WriteLine(x.First());
      Console.ReadKey();
    }
  }
}
