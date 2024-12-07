using System.Text;
using fsci.client.Models;
using fsci.engine.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for listing the content inside the current working directory
 */
public class ListContentCommand : Command, IOperateOnFileSystem, IOperateOnView, IOperationSuccessOutputMessage
{
    private IFileSystemHandler? _fileSystemHandler;
    private IOutputHandler? _outputHandler;

    private List<FileSystemElement> _fileSystemElements;
    
    
    public ListContentCommand(string acronym) : base(acronym)
    {
    }

    public override void Execute()
    {
        if (_fileSystemHandler == null)
        {
            throw new InvalidOperationException("File System Handler has not been set.");
        }

        if (_outputHandler == null)
        {
            throw new InvalidOperationException("Output Handler has not been set");
        }

        _fileSystemElements = _fileSystemHandler.ListContent();
        
        _outputHandler.AddSuccessOperationMessage(this);
    }

    public override string GetSynopsis()
    {
        return "ls";
    }

    public override string GetDescription()
    {
        return "list the content inside the current working directory";
    }

    public void SetFileSystemHandler(IFileSystemHandler fileSystemHandler)
    {
        _fileSystemHandler = fileSystemHandler;
    }

    public void SetOutputHandler(IOutputHandler outputHandler)
    {
        _outputHandler = outputHandler;
    }

    public string GetOperationSuccessMessage()
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        foreach(var fileSystemElement in _fileSystemElements)
        {
            stringBuilder.Append(fileSystemElement.Name).Append(" ");
        }
        
        return stringBuilder.ToString();
    }
}