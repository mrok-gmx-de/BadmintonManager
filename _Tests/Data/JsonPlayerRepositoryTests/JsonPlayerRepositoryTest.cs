using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetzWerkPlan.BadmintionManager.CrossCutting.DataClasses;
using NetzWerkPlan.BadmintonManager.CrossCutting.FileStorage.Contracts;
using NetzWerkPlan.BadmintonManager.Data.PlayerRepositoryJson;
using NFluent;
using NSubstitute;
using Xunit;

namespace NetzWerkPlan.BadmintonManager._Tests.Data.JsonPlayerRepositoryTests
{
  public class JsonPlayerRepositoryTest
  {
    public class Constructor
    {
      private readonly IFileStorage _fileStorage;
      private readonly JsonPlayerRepository _target;

      public Constructor()
      {
        _fileStorage = Substitute.For<IFileStorage>();
        _target = new JsonPlayerRepository(_fileStorage);
      }

      [Fact]
      public void GivenNullAsFileStorage_ShouldThrowArgumentNullException()
      {
        Check.ThatCode(() => new JsonPlayerRepository(null)).Throws<ArgumentNullException>();
      }

      [Fact]
      public void ItShouldNotReadAnyFile()
      {
        _fileStorage.DidNotReceive().ReadFileContent(Arg.Any<string>());
      }
    }

    public class GetAll_LoadingAnEmptyFile
    {
      private readonly IFileStorage _fileStorage;
      private readonly JsonPlayerRepository _target;
      private readonly IEnumerable<Player> _actual;

      public GetAll_LoadingAnEmptyFile()
      {
        _fileStorage = Substitute.For<IFileStorage>();
        _fileStorage
          .ReadFileContent(Arg.Any<string>())
          .Returns("");

        _target = new JsonPlayerRepository(_fileStorage);

        _actual = _target.GetAll();
      }

      [Fact]
      public void ItShouldReturnAnEmptyList()
      {
        Check.That(_actual).IsEmpty();
      }

      [Fact]
      public void ItShouldCallReadFilecontentAsyncExcactlyOnce()
      {
        _fileStorage.Received(1).ReadFileContent(Arg.Any<string>());
      }
    }

    public class GetAll_LoadingAFileWithCorrectData
    {
      private readonly IFileStorage _fileStorage;
      private readonly JsonPlayerRepository _target;
      
      public GetAll_LoadingAFileWithCorrectData()
      {
        _fileStorage = Substitute.For<IFileStorage>();

        _target = new JsonPlayerRepository(_fileStorage);

      }

      [Fact]
      public void ItShouldReturnAllPlayers()
      {
        _fileStorage
          .ReadFileContent(Arg.Any<string>())
          .Returns("[{firstName: \"Olli\", lastName: \"Kolligs\", rating: 50, id: \"e30c03ab-7c14-45d5-a61e-bf4df2b8658b\"}]");

        IEnumerable<Player> actual = _target.GetAll();

        Check.That(actual).HasSize(1);
      }

      //[Fact]
      //public void ItShouldCallReadFilecontentAsyncExcactlyOnce()
      //{
      //  _fileStorage.Received(1).ReadFileContentAsync(Arg.Any<string>());
      //}
    }
  }
}
