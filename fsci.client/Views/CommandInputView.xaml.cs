using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsci.client.view;

public partial class CommandInputView : ContentView
{
    public CommandInputView()
    {
        InitializeComponent();
    }

    public Entry InputField => CommandInput;
}