using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsci.client.view;

public partial class OutputAreaView : ContentView, IOutputView
{
    public OutputAreaView()
    {
        InitializeComponent();
    }
    
    public void SetOutput(string output)
    {
        OutputTextArea.Text = output;
    }

    public void AppendOutput(string output)
    {
        OutputTextArea.Text += output;
    }

    public void ClearOutput()
    {
        OutputTextArea.Text = string.Empty;
    }
}