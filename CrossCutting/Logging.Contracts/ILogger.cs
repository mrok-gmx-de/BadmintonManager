using System;

namespace NetzWerkPlan.BadmintionManager.CrossCutting.Logging.Contracts
{
  public interface ILogger
  {
    void Information(string message, params object[] arguments);
    void Warning(string message, params object[] arguments);
    void Error(Exception ex, string message, params object[] arguments);
  }
}