namespace NetzWerkPlan.BadmintonManager.CrossCutting.FileStorage.Contracts
{
    public interface IFileStorage
    {
      string ReadFileContent(string fileName);
    }
}
