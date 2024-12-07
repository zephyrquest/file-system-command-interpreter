namespace fsci.client.Commands;

public interface IParameterCommand
{
    int GetNumberOfParameters();
    void SetParameters(string[] parameters);
}