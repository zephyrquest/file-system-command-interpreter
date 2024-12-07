using fsci.engine.Models;
using Directory = fsci.engine.Models.Directory;
using IFileSystem = fsci.engine.Models.IFileSystem;

namespace fsci.client.Models;

public class FileSystemHandler : IFileSystemHandler
{
    private readonly IFileSystem _fileSystem;


    public FileSystemHandler()
    {
        _fileSystem = new VirtualFileSystem();
    }
    
    public Directory? CreateDirectory(string name)
    {
        return _fileSystem.CreateDirectory(name);
    }

    public string PrintCurrentPath()
    {
        return _fileSystem.PrintCurrentPath();
    }

    public List<FileSystemElement> ListContent()
    {
        return _fileSystem.ListContent();
    }

    public string? ChangeCurrentDirectory(string path)
    {
        return _fileSystem.ChangeCurrentDirectory(path);
    }

    public string? RemoveDirectory(string path)
    {
        return _fileSystem.RemoveDirectory(path);
    }

    public (string Origin, string Destination)? MoveDirectory(string originPath, string destinationPath)
    {
        return _fileSystem.MoveDirectory(originPath, destinationPath);
    }
}