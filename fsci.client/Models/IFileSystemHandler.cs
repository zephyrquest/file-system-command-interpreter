using fsci.engine.Models;
using Directory = fsci.engine.Models.Directory;

namespace fsci.client.Models;

public interface IFileSystemHandler
{
    Directory? CreateDirectory(string name);
    string PrintCurrentPath();
    List<FileSystemElement> ListContent();
    string? ChangeCurrentDirectory(string path);
    string? RemoveDirectory(string path);
    (string Origin, string Destination)? MoveDirectory(string originPath, string destinationPath);
}