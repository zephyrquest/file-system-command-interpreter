namespace fsci.client.command;

public abstract class Command
{
    private readonly string _acronym;
    private readonly List<string> _arguments;

    public List<string> Arguments => _arguments;

    
    public Command(string acronym)
    {
        _acronym = acronym;
        _arguments = new List<string>();
    }

    public abstract int GetNumberOfArguments();
    public abstract void Execute();
    public abstract string GetSyntaxErrorMessage(string userInput);
}