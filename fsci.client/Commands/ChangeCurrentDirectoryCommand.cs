using fsci.client.Models;

namespace fsci.client.Commands;

public class ChangeCurrentDirectoryCommand : Command, IParameterCommand, IOperateOnFileSystem, IOperateOnView,
    IOperationSuccessOutputMessage, IOperationUnSuccessOutputMessage
{
    private IFileSystemHandler? _fileSystemHandler;
    private IOutputHandler? _outputHandler;

    // input
    private string _path;
    // output
    private string? _directoryAbsolutePath;
    
    public ChangeCurrentDirectoryCommand(string acronym) : base(acronym)
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

        _directoryAbsolutePath = _fileSystemHandler.ChangeCurrentDirectory(_path);

        if (_directoryAbsolutePath == null)
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
        return "cd <path>";
    }

    public override string GetDescription()
    {
        return "change the current working directory";
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
        return $"change current working directory to: {_directoryAbsolutePath}";
    }

    public string GetOperationUnSuccessMessage()
    {
        return $"Operation failed: could not change current working directory to {_path}";
    }
}