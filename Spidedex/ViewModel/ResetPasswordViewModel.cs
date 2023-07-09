using System;
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
    public partial class ResetPasswordPageViewModel : BaseViewModel
    {
        public string apiKey = "AIzaSyBxH3egBwl1T5ukQhRHga7OerGPc-2lCDA ";

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private bool _IsLoading;

        [RelayCommand]
        async void ResetPassword()
        {
            if (!NetworkConnectivity.IsConnected())
            {
                await Shell.Current.DisplayAlert("Error", "No internet connection could be made." +
                                           "Please check connectivity settings and try again.", "OK");
                return;
            }
            if (!string.IsNullOrWhiteSpace(Email))
            {
                if (IsLoading)
                {
                    return;
                }
                IsLoading = true;
                try
                {
                    var authenticationProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    await authenticationProvider.SendPasswordResetEmailAsync(Email);
                    await App.Current.MainPage.DisplayAlert("Success", "Password reset email sent", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UnknownEmailAddress"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "User does not exist", "OK");
                        return;
                    }
                    else if (ex.Message.Contains("InvalidEmailAddress"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Invalid email address", "OK");
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
                    IsLoading = false;
                    Email = string.Empty;
                }
            }
        }

        [RelayCommand]
        async void NavigateToLogin()
        {
            Email = string.Empty;
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}
