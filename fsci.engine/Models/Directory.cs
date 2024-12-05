namespace fsci.engine.Models;

public class Directory : FileSystemElement
{
    public Directory(string name, Directory? parent) : base(name, parent)
    {
    }
}