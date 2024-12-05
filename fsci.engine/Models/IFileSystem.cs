namespace fsci.engine.Models;

public interface IFileSystem
{
    string PrintCurrentPath();
    Directory CreateDirectory(string name);
    List<FileSystemElement> ListContent();
    Directory ChangeCurrentDirectory(string path);
    Directory RemoveDirectory(string path);
}