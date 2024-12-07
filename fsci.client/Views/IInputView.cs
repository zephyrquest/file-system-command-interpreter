namespace fsci.client.view;

public interface IInputView
{
    string RetrieveInput();
    void ClearInput();
    void SetEventListener(Action<string> onInputCompleted);
}