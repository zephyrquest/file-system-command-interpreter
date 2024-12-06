namespace fsci.engine.Models;

public abstract class FileSystemElement
{
    private readonly string _name;
    private Directory? _parent;

    public string Name => _name;

    public Directory? Parent
    {
        get => _parent;
        set => _parent = value;
    }


    protected FileSystemElement(string name, Directory? parent)
    {
        _name = name;
        _parent = parent;
    }
}