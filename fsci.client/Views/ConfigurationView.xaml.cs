using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsci.client.Views;

public partial class ConfigurationView : ContentView, IConfigurationView
{
    public ConfigurationView()
    {
        InitializeComponent();
    }
    
    public void SetLanguage(string languageCode)
    {
        var picker = this.FindByName<Picker>("LanguagePicker");

        if (picker == null)
            return;

        var index = picker.Items.IndexOf(languageCode);
        if (index != -1)
        {
            picker.SelectedIndex = index;
        }
        else
        {
            picker.SelectedIndex = -1;
        }
    }

    public void SetEventListener(Action<string> languageSelected)
    {
        LanguagePicker.SelectedIndexChanged += (sender, args) =>
        {
            if (LanguagePicker.SelectedIndex != -1)
            {
                var selectedLanguage = LanguagePicker.Items[LanguagePicker.SelectedIndex];
                languageSelected?.Invoke(selectedLanguage);
            }
        };
    }
}