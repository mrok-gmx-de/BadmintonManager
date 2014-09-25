using System.Collections;
using System.Collections.Generic;
using NetzWerkPlan.BadmintionManager.Infrastructure.DependencyInjection.CrossCutting;
using Ninject.Modules;

namespace NetzWerkPlan.BadmintionManager.Infrastructure.DependencyInjection
{
  public static class MappingsAggregator
  {
    public static IEnumerable<INinjectModule> Mappings
    {
      get { yield return new LoggingMappings(); }
    }
  }
}