namespace fsci.engine.Models;

public class Directory : FileSystemElement
{
    private readonly List<FileSystemElement> _children;

    public List<FileSystemElement> Children => _children;

    public Directory(string name, Directory? parent) : base(name, parent)
    {
        _children = new List<FileSystemElement>();
    }
}