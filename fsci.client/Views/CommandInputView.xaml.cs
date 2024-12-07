using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsci.client.view;

public partial class CommandInputView : ContentView, IInputView
{
    public CommandInputView()
    {
        InitializeComponent();
    }

    public string RetrieveInput()
    {
        return CommandInput.Text;
    }

    public void ClearInput()
    {
        CommandInput.Text = string.Empty;
    }

    public void SetEventListener(Action<string> onInputCompleted)
    {
        CommandInput.Completed += (sender, args) =>
        {
            var input = RetrieveInput();
            onInputCompleted?.Invoke(input);
        };
    }
}