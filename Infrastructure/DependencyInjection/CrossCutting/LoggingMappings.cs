using NetzWerkPlan.BadmintionManager.CrossCutting.Logging.Console;
using NetzWerkPlan.BadmintionManager.CrossCutting.Logging.Contracts;
using Ninject.Modules;

namespace NetzWerkPlan.BadmintionManager.Infrastructure.DependencyInjection.CrossCutting
{
  public class LoggingMappings : NinjectModule
  {
    public override void Load()
    {
      Bind<ILogger>().To<ConsoleLogger>();
    }
  }
}