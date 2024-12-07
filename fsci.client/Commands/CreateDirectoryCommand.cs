using fsci.client.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for creating a directory inside the current working directory
 */
public class CreateDirectoryCommand : Command, IParameterCommand, IOperateOnFileSystem, IOperateOnView,
 IOperationSuccessOutputMessage, IOperationUnSuccessOutputMessage
{
 private IFileSystemHandler? _fileSystemHandler;
 private IOutputHandler? _outputHandler;

 // input and output
 private string _directoryName;
 

 public CreateDirectoryCommand(string acronym) : base(acronym)
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
  
  var directory = _fileSystemHandler.CreateDirectory(_directoryName);

  if (directory == null)
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
  return "mkdir <dir name>";
 }

 public override string GetDescription()
 {
  return "create a new directory in the current working directory";
 }

 public string GetOperationSuccessMessage()
 {
  return $"new directory created: {_directoryName}";
 }

 public string GetOperationUnSuccessMessage()
 {
  return $"Operation failed: could not create directory with name {_directoryName}";
 }

 public void SetFileSystemHandler(IFileSystemHandler fileSystemHandler)
 {
  _fileSystemHandler = fileSystemHandler;
 }

 public void SetOutputHandler(IOutputHandler outputHandler)
 {
  _outputHandler = outputHandler;
 }

 public int GetNumberOfParameters()
 {
  return 1;
 }

 public void SetParameters(string[] parameters)
 {
  _directoryName = parameters[0];
 }
}