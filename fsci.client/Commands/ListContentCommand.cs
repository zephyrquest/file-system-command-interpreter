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

    // output
    private List<FileSystemElement> _fileSystemElements;
    
    
    public ListContentCommand(string acronym) : base(acronym)
    {
    }

    public override void Execute(string input)
    {
        if (_fileSystemHandler == null)
        {
            throw new InvalidOperationException("File System Handler has not been set.");
        }

        if (_outputHandler == null)
        {
            throw new InvalidOperationException("Output Handler has not been set.");
        }

        _fileSystemElements = _fileSystemHandler.ListContent();
        
        _outputHandler.AddSuccessOperationMessage(this, input);
    }

    public override string GetSynopsis()
    {
        return LocalizationHandler.GetInstance().GetValue("command.ls.synopsis");
    }

    public override string GetDescription()
    {
        return LocalizationHandler.GetInstance().GetValue("command.ls.description");
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