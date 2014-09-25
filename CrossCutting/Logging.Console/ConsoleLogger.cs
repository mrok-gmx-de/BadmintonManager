using System;
using NetzWerkPlan.BadmintionManager.CrossCutting.Logging.Contracts;

namespace NetzWerkPlan.BadmintionManager.CrossCutting.Logging.Console
{
  public class ConsoleLogger : ILogger
  {
    private readonly DateTime _created = DateTime.UtcNow;
    
    public void Information(string message, params object[] arguments)
    {
      System.Console.WriteLine(_created + " " + message, arguments);
    }

    public void Warning(string message, params object[] arguments)
    {
      System.Console.WriteLine(_created + " " + message, arguments);
    }

    public void Error(Exception ex, string message, params object[] arguments)
    {
      System.Console.WriteLine(_created + " " + ex + message, arguments);
    }
  }
}