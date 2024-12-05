namespace fsci.engine.Models;

public class VirtualFileSystem : IFileSystem
{
    private static VirtualFileSystem? _instance = null;
    
    private Directory _root;

    private VirtualFileSystem()
    {
        _root = new Directory("/", null);
    }

    public static VirtualFileSystem GetInstance()
    {
        if (_instance == null)
        {
            _instance = new VirtualFileSystem();
        }

        return _instance;
    }
    
    public string PrintCurrentPath()
    {
        throw new NotImplementedException();
    }

    public Directory CreateDirectory(string name)
    {
        throw new NotImplementedException();
    }

    public List<FileSystemElement> ListContent()
    {
        throw new NotImplementedException();
    }

    public Directory ChangeCurrentDirectory(string path)
    {
        throw new NotImplementedException();
    }

    public Directory RemoveDirectory(string path)
    {
        throw new NotImplementedException();
    }
}