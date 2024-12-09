using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fsci.client.Models;
using fsci.client.Observers;

namespace fsci.client.Views;

public partial class ConfigurationView : ContentView, IConfigurationView, ILanguageObserver
{
    private string _titleLabel;
    private string _languageLabel;

    public string TitleLabel
    {
        get => _titleLabel;
        set
        {
            _titleLabel = value;
            OnPropertyChanged();
        }
    }

    public string LanguageLabel
    {
        get => _languageLabel;
        set
        {
            _languageLabel = value;
            OnPropertyChanged();
        }
    }

    public ConfigurationView()
    {
        InitializeComponent();
        BindingContext = this;
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

    public void Translate()
    {
        TitleLabel = LocalizationHandler.GetInstance().GetValue("ui.title");
        LanguageLabel = LocalizationHandler.GetInstance().GetValue("ui.language");
    }
}