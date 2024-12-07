using fsci.client.Models;

namespace fsci.client.Commands;

public class RemoveDirectoryCommand : Command, IParameterCommand, IOperateOnFileSystem, IOperateOnView,
    IOperationSuccessOutputMessage, IOperationUnSuccessOutputMessage
{
    private IFileSystemHandler? _fileSystemHandler;
    private IOutputHandler? _outputHandler;

    // input
    private string _path;
    // output
    private string? _absoluteDirectoryPath;
    
    public RemoveDirectoryCommand(string acronym) : base(acronym)
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
            throw new InvalidOperationException("Output Handler has not been set.");
        }

        _absoluteDirectoryPath = _fileSystemHandler.RemoveDirectory(_path);

        if (_absoluteDirectoryPath == null)
        {
            _outputHandler.AddUnSuccessOperationMessage(this);
        }
        else
        {
            _outputHandler.AddSuccessOperationMessage(this);
        }
    }

    public override string GetSynopsis()
    {
        return "rm <path>";
    }

    public override string GetDescription()
    {
        return "remove a directory and its content";
    }

    public int GetNumberOfParameters()
    {
        return 1;
    }

    public void SetParameters(string[] parameters)
    {
        _path = parameters[0];
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
        return $"removed directory: {_absoluteDirectoryPath}";
    }

    public string GetOperationUnSuccessMessage()
    {
        return $"Operation failed: could not remove directory with path {_path}";
    }
}