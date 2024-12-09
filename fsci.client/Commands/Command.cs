namespace fsci.client.Commands;

public abstract class Command
{
    private readonly string _acronym;

    public string Acronym => _acronym;


    public Command(string acronym)
    {
        _acronym = acronym;
    }

    public abstract void Execute(string input);
    public abstract string GetSynopsis();
    public abstract string GetDescription();
}