using System.Text;

namespace fsci.engine.Models;

public class VirtualFileSystem : IFileSystem
{
    private readonly Directory _root;
    private Directory _current;

    
    public VirtualFileSystem()
    {
        _root = new Directory(GetSeparator(), null);
        _current = _root;
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
        if (name == GetSeparator())
        {
            return null;
        }
        
        var currentDirectoryChildren = _current.Children.FindAll(e => e is Directory);

        if (currentDirectoryChildren.Find(directory => directory.Name == name) != null)
        {
            return null;
        }

        var newDirectory = new Directory(name, _current);

        _current.Children.Add(newDirectory);

        return newDirectory;
    }

    public List<FileSystemElement> ListContent()
    {
        return _current.Children;
    }

    public string? ChangeCurrentDirectory(string path)
    {
        var element = GetFileSystemElement(path);

        if (element != null && element is Directory)
        {
            _current = (Directory) element;
            
            var absolutePath = GetAbsolutePath(element);
            
            return absolutePath;
        }

        return null;
    }

    public string? RemoveDirectory(string path)
    {
        var element = GetFileSystemElement(path);

        if (element != null && element is Directory && element != _root)
        {
            var elementAbsolutePath = GetAbsolutePath(element);
            var currentAbsolutePath = GetAbsolutePath(_current);

            if (!currentAbsolutePath.StartsWith(elementAbsolutePath))
            {
                var parentElement = element.Parent;
                
                if (parentElement != null)
                {
                    parentElement.Children.Remove(element);
                    element.Parent = null;

                    return elementAbsolutePath;
                }
            }
        }
        
        return null;
    }

    public (string Origin, string Destination)? MoveDirectory(string originPath, string destinationPath)
    {
        var originElement = GetFileSystemElement(originPath);

        if (originElement == null || originElement is not Directory || originElement == _root || originElement.Parent == null)
        {
            return null;
        }
        
        var originElementAbsolutePath = GetAbsolutePath(originElement);
        var currentAbsolutePath = GetAbsolutePath(_current);
        
        if (currentAbsolutePath.StartsWith(originElementAbsolutePath))
        {
            return null;
        }
        
        var destinationElement = GetFileSystemElement(destinationPath);

        if (destinationElement == null || destinationElement is not Directory)
        {
            return null;
        }
        
        var destinationElementAbsolutePath = GetAbsolutePath(destinationElement);

        var originElementParent = originElement.Parent;
        originElementParent.Children.Remove(originElement);
        
        originElement.Parent = (Directory) destinationElement;
        ((Directory) destinationElement).Children.Add(originElement);
        
        return (Origin: originElementAbsolutePath, Destination: destinationElementAbsolutePath);
    }

    private FileSystemElement? GetFileSystemElement(string path)
    {
        if (path == GetSeparator())
        {
            return _root;
        }
        
        Directory current;
        bool found = true;
        
        if (path.StartsWith(GetSeparator()))
        {
            current = _root;
            path = path.Substring(1);
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

    private string GetAbsolutePath(FileSystemElement fileSystemElement)
    {
        if (fileSystemElement == _root)
        {
            return GetSeparator();
        }

        var current = fileSystemElement;
        StringBuilder stringBuilder = new StringBuilder();

        while (current != null && current != _root)
        {
            stringBuilder.Insert(0, current.Name);
            stringBuilder.Insert(0, GetSeparator());

            current = current.Parent;
        }

        return stringBuilder.ToString();
    }
}