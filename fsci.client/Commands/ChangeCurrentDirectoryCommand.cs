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
        return LocalizationHandler.GetInstance().GetValue("command.cd.synopsis");
    }

    public override string GetDescription()
    {
        return LocalizationHandler.GetInstance().GetValue("command.cd.description");
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
        return string.Format(LocalizationHandler.GetInstance().GetValue("command.cd.success"), _directoryAbsolutePath);
    }

    public string GetOperationUnSuccessMessage()
    {
        return string.Format(LocalizationHandler.GetInstance().GetValue("command.cd.unsuccess"), _path);

    }
}