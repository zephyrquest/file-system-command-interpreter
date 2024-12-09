using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fsci.client.Models;
using fsci.client.Observers;

namespace fsci.client.view;

public partial class CommandInputView : ContentView, IInputView, ILanguageObserver
{
    private string _commandLabel;
    private string _enterCommandPlaceholder;

    public string CommandLabel
    {
        get => _commandLabel;
        set
        {
            _commandLabel = value;
            OnPropertyChanged();
        }
    }

    public string EnterCommandPlaceholder
    {
        get => _enterCommandPlaceholder;
        set
        {
            _enterCommandPlaceholder = value;
            OnPropertyChanged();
        }
    }
    
    public CommandInputView()
    {
        InitializeComponent();
        BindingContext = this;
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

    public void Translate()
    {
        CommandLabel = LocalizationHandler.GetInstance().GetValue("ui.command");
        EnterCommandPlaceholder = LocalizationHandler.GetInstance().GetValue("ui.enter_command");
    }
}