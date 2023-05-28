﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Spidedex.Controls;
using Spidedex.Model;
using Spidedex.View;

namespace Spidedex.ViewModel
{
    public partial class RegisterPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _confirmPassword;

        [RelayCommand]
        async void Register()
        {

            var userDetails = new User
            {
                Email = Email,
                //Password = Password
            };

            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                if (Preferences.ContainsKey(nameof(App.UserDetails)))
                {
                     Preferences.Remove(nameof(App.UserDetails));
                }

                string userDetailsString = JsonConvert.SerializeObject(userDetails);

                Preferences.Set(nameof(App.UserDetails), userDetailsString);
                App.UserDetails = userDetails;
                //AppShell.Current.FlyoutHeader = new HeaderControl();
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }   
    }
}
