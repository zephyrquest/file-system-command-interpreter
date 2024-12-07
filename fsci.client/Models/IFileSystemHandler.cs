using fsci.engine.Models;
using Directory = fsci.engine.Models.Directory;

namespace fsci.client.Models;

public interface IFileSystemHandler
{
    Directory? CreateDirectory(string name);
    string PrintCurrentPath();
    List<FileSystemElement> ListContent();
}