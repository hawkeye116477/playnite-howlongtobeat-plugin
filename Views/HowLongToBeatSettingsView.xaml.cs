﻿using HowLongToBeat.Services;
using Playnite.SDK;
using Playnite.SDK.Models;
using System;
using System.Windows;
using System.Windows.Controls;


namespace HowLongToBeat.Views
{
    public partial class HowLongToBeatSettingsView : UserControl
    {
        private IPlayniteAPI PlayniteApi;
        private string PluginUserDataPath;

        public HowLongToBeatSettingsView(IPlayniteAPI PlayniteApi, string PluginUserDataPath)
        {
            this.PlayniteApi = PlayniteApi;
            this.PluginUserDataPath = PluginUserDataPath;
            InitializeComponent();
        }

        private void Checkbox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if ((cb.Name == "HltB_IntegrationInDescription") && (bool)cb.IsChecked)
            {
                HltB_IntegrationInCustomTheme.IsChecked = false;
            }

            if ((cb.Name == "HltB_IntegrationInCustomTheme") && (bool)cb.IsChecked)
            {
                HltB_IntegrationInDescription.IsChecked = false;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach(Game game in PlayniteApi.Database.Games)
            {
                try
                {
                    HowLongToBeatData data = new HowLongToBeatData(game, PluginUserDataPath, PlayniteApi, true, false);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (Game game in PlayniteApi.Database.Games)
            {
                try
                {
                    HowLongToBeatData data = new HowLongToBeatData(game, PluginUserDataPath, PlayniteApi, false, false);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}