namespace fsci.engine.Models;

public abstract class FileSystemElement
{
    private readonly string _name;
    private readonly Directory? _parent;

    public string Name => _name;

    
    protected FileSystemElement(string name, Directory? parent)
    {
        _name = name;
        _parent = parent;
    }
}