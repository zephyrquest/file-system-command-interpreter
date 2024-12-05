using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsci.client.view;

public partial class OutputAreaView : ContentView
{
    public OutputAreaView()
    {
        InitializeComponent();
    }
    
    public Editor OutputArea => OutputTextArea;
}