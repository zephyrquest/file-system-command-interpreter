namespace fsci.client.Commands;

public abstract class Command
{
    private readonly string _acronym;
    private string[]? _arguments;

    public string Acronym => _acronym;

    public string[]? Arguments
    {
        get => _arguments;
        set => _arguments = value;
    }


    public Command(string acronym)
    {
        _acronym = acronym;
    }

    public abstract int GetNumberOfArguments();
    public abstract void Execute();
    public abstract string GetSyntaxErrorMessage(string userInput);
}