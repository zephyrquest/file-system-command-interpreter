using System.Text;

namespace fsci.engine.Models;

public class VirtualFileSystem : IFileSystem
{
    private static VirtualFileSystem? _instance;
    
    private readonly Directory _root;
    private Directory _current;

    private VirtualFileSystem()
    {
        _root = new Directory(GetSeparator(), null);
        _current = _root;
    }
    
    public static VirtualFileSystem GetInstance()
    {
        if (_instance == null)
        {
            _instance = new VirtualFileSystem();
        }

        return _instance;
    }

    public string GetSeparator()
    {
        return "/";
    }

    public string PrintCurrentPath()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(_current.Name);

        var current = _current.Parent;

        while (current != null)
        {
            if (current != _root)
            {
                stringBuilder.Insert(0, GetSeparator());
            }
            
            stringBuilder.Insert(0, current.Name);

            current = current.Parent;
        }
        
        return stringBuilder.ToString();
    }

    public Directory? CreateDirectory(string name)
    {
        var currentDirectoryChildren = _current.Children.FindAll(e => e is Directory);

        if (currentDirectoryChildren.Find(directory => directory.Name == name) != null)
        {
            return null;
        }

        var newDirectory = new Directory(name, _current);

        _current.Children.Append(newDirectory);

        return newDirectory;
    }

    public List<FileSystemElement> ListContent()
    {
        return _current.Children;
    }

    public Directory? ChangeCurrentDirectory(string path)
    {
        var element = GetFileSystemElement(path);

        if (element != null && element is Directory)
        {
            _current = (Directory) element;
            
            return _current;
        }

        return null;
    }

    public Directory? RemoveDirectory(string path)
    {
        var element = GetFileSystemElement(path);

        if (element != null && element is Directory && element != _root)
        {
            var parentElement = element.Parent;

            if (parentElement != null)
            {
                parentElement.Children.Remove(element);
                element.Parent = null;

                return (Directory) element;
            }
        }
        
        return null;
    }

    private FileSystemElement? GetFileSystemElement(string path)
    {
        Directory current;
        bool found = true;
        
        if (path.StartsWith(GetSeparator()))
        {
            current = _root;
        }
        else
        {
            current = _current;
        }

        var fileSystemElements = path.Split(GetSeparator());

        for (int i = 0; i < fileSystemElements.Length; i++)
        {
            var child = current.Children.Find(e => e.Name == fileSystemElements[i]);

            if (child == null)
            {
                found = false;
                break;
            }

            if (child is Directory)
            {
                current = (Directory) child;
            }
            else
            {
                if (i != fileSystemElements.Length - 1)
                {
                    found = false;
                    break;
                }
            }
        }

        if (found)
        {
            return current;
        }

        return null;
    }
}