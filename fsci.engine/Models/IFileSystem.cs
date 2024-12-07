namespace fsci.engine.Models;

public interface IFileSystem
{
    string GetSeparator();
    string PrintCurrentPath();
    Directory? CreateDirectory(string name);
    List<FileSystemElement> ListContent();
    string? ChangeCurrentDirectory(string path);
    string? RemoveDirectory(string path);
    (string Origin, string Destination)? MoveDirectory(string originPath, string destinationPath);
}