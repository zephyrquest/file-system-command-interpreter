﻿using fsci.client.Controllers;
using fsci.client.Models;

namespace fsci.client;

public partial class MainPage : ContentPage
{
    private readonly CommandController _commandController;
    private readonly CommandManager _commandManager = new CommandManager();
    
    
    public MainPage()
    {
        InitializeComponent();

        _commandController = new CommandController(CommandInputView, OutputAreaView, _commandManager);
    }
}