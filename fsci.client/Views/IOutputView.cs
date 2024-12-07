namespace fsci.client.view;

public interface IOutputView
{
    void SetOutput(string output);
    void AppendOutput(string output);
    void ClearOutput();
}