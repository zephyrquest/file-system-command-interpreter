using fsci.client.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for printing the full filename of the current working directory
 */
public class PrintCurrentPathCommand : Command, IOperateOnFileSystem, IOperateOnView, IOperationSuccessOutputMessage
{
 private IFileSystemHandler? _fileSystemHandler;
 private IOutputHandler? _outputHandler;

 // output
 private string _currentPath;
 
 public PrintCurrentPathCommand(string acronym) : base(acronym)
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

  _currentPath = _fileSystemHandler.PrintCurrentPath();
  
  _outputHandler.AddSuccessOperationMessage(this);
 }

 public override string GetSynopsis()
 {
  return "pwd";
 }

 public override string GetDescription()
 {
  return "print the path of the current working directory";
 }

 public string GetOperationSuccessMessage()
 {
  return $"current working dir: {_currentPath}";
 }

 public void SetFileSystemHandler(IFileSystemHandler fileSystemHandler)
 {
  _fileSystemHandler = fileSystemHandler;
 }

 public void SetOutputHandler(IOutputHandler outputHandler)
 {
  _outputHandler = outputHandler;
 }
}