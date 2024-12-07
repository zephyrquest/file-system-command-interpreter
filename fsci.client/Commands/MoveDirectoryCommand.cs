using fsci.client.Models;

namespace fsci.client.Commands;

public class MoveDirectoryCommand : Command, IParameterCommand, IOperateOnFileSystem, IOperateOnView,
    IOperationSuccessOutputMessage, IOperationUnSuccessOutputMessage
{
    private IFileSystemHandler? _fileSystemHandler;
    private IOutputHandler? _outputHandler;

    // input
    private string _originPath;
    private string _destinationPath;
    
    // output
    private string _originAbsolutePath;
    private string _destinationAbsolutePath;
    
    
    public MoveDirectoryCommand(string acronym) : base(acronym)
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

        var tuple = _fileSystemHandler.MoveDirectory(_originPath, _destinationPath);

        if (tuple == null)
        {
            _outputHandler.AddUnSuccessOperationMessage(this);
        }
        else
        {
            _originAbsolutePath = tuple.Value.Origin;
            _destinationAbsolutePath = tuple.Value.Destination;
            
            _outputHandler.AddSuccessOperationMessage(this);
        }
    }

    public override string GetSynopsis()
    {
        return "mv <origin> <path>";
    }

    public override string GetDescription()
    {
        return "move a directory and its content inside another directory";
    }

    public int GetNumberOfParameters()
    {
        return 2;
    }

    public void SetParameters(string[] parameters)
    {
        _originPath = parameters[0];
        _destinationPath = parameters[1];
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
        return $"moved directory {_originAbsolutePath} to {_destinationAbsolutePath}";
    }

    public string GetOperationUnSuccessMessage()
    {
        return $"Operation failed: could not move directory {_originPath} to {_destinationPath}";
    }
}