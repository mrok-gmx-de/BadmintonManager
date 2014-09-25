using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetzWerkPlan.BadmintionManager.CrossCutting.DataClasses;
using NetzWerkPlan.BadmintonManager.CrossCutting.FileStorage.Contracts;
using NetzWerkPlan.BadmintonManager.Data.PlayerRepository.Contracts;
using Newtonsoft.Json;

namespace NetzWerkPlan.BadmintonManager.Data.PlayerRepositoryJson
{
  public class JsonPlayerRepository : IPlayerRepository
  {
    private readonly IFileStorage _fileStorage;
    private const string DataFile = @"players.json";

    public JsonPlayerRepository(IFileStorage fileStorage)
    {
      if (fileStorage == null) throw new ArgumentNullException("fileStorage");
      _fileStorage = fileStorage;
    }

    public IEnumerable<Player> GetAll()
    {
      string fileContent = _fileStorage.ReadFileContent(DataFile);
      if (fileContent == "")
      {
        return Enumerable.Empty<Player>();        
      }
      var listOfPlayers = JsonConvert.DeserializeObject<IEnumerable<Player>>(fileContent);
      return listOfPlayers;
    }

    public void Remove(Guid id)
    {
      throw new NotImplementedException();
    }

    public void Remove(Player player)
    {
      throw new NotImplementedException();
    }

    public void Save(Player player)
    {
      throw new NotImplementedException();
    }
  }
}
