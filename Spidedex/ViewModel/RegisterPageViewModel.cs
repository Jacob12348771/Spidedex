﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;
using Spidedex.Controls;
using Spidedex.Helper;
using Spidedex.Model;
using Spidedex.View;

namespace Spidedex.ViewModel
{
    public partial class RegisterPageViewModel : BaseViewModel
    {
        public string apiKey = "<<API KEY>>";

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _confirmPassword;

        [ObservableProperty]
        private bool _IsLoading;

        [RelayCommand]
        async void Register()
        {
            if (!NetworkConnectivity.IsConnected())
            {
                await Shell.Current.DisplayAlert("Error", "No internet connection could be made." +
                                           "Please check connectivity settings and try again.", "OK");
                return;
            }
            if (IsLoading)
            {
                return;
            }
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                IsLoading = true;
                if (Password != ConfirmPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                    return;
                }
                try
                {
                    var authenticationProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var auth = await authenticationProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                    string token = auth.FirebaseToken;
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        await App.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    }
                }

                catch (Exception ex)
                {
                    if (ex.Message.Contains("InvalidEmailAddress"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Invalid email address", "OK");
                        return;
                    } 
                    else if (ex.Message.Contains("EmailExists"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Email already exists", "OK");
                        return;
                    } 
                    else if (ex.Message.Contains("WeakPassword")) {
                        await App.Current.MainPage.DisplayAlert("Error", "Password must be over 6 character long", "OK");
                        return;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                        return;
                    }
                }
                finally
                {
                    Email = string.Empty;
                    Password = string.Empty;
                    ConfirmPassword = string.Empty;
                    IsLoading = false;
                }
            }
        }

        [RelayCommand]
        async void NavigateToLogin()
        {
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
