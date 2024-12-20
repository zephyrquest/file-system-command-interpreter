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

  _currentPath = _fileSystemHandler.PrintCurrentPath();
  
  _outputHandler.AddSuccessOperationMessage(this, input);
 }

 public override string GetSynopsis()
 {
  return LocalizationHandler.GetInstance().GetValue("command.pwd.synopsis");
 }

 public override string GetDescription()
 {
  return LocalizationHandler.GetInstance().GetValue("command.pwd.description");
 }

 public string GetOperationSuccessMessage()
 {
  return string.Format(LocalizationHandler.GetInstance().GetValue("command.pwd.success"), _currentPath);
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