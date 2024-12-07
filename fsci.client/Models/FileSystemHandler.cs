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
}