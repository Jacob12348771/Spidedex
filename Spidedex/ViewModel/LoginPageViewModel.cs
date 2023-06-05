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
using Spidedex.Model;
using Spidedex.View;

namespace Spidedex.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {

        private MySpidersPageViewModel spidersPageViewModel;

        public LoginPageViewModel(MySpidersPageViewModel spidersPageViewModel)
        {
            this.spidersPageViewModel = spidersPageViewModel;
        }

        public string apiKey = "AIzaSyBxH3egBwl1T5ukQhRHga7OerGPc-2lCDA ";

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private bool _IsLoading;

        [RelayCommand]
        async void Login()
        {

            if (IsLoading)
            {
                return;
            }

            // Disable the login button
            IsLoading = true;

            var userDetails = new Model.User
            {
                Email = Email,
            };

            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                try
                {
                    var authenticationProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var response = await authenticationProvider.SignInWithEmailAndPasswordAsync(Email, Password);
                    var serializedContent = JsonConvert.SerializeObject(response);
                    Preferences.Set(("token"), serializedContent);
                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }

                    string userDetailsString = JsonConvert.SerializeObject(userDetails);

                    Preferences.Set(nameof(App.UserDetails), userDetailsString);
                    App.UserDetails = userDetails;
                    AppShell.Current.FlyoutHeader = new HeaderControl();
                    await spidersPageViewModel.GetSpidersCommand.ExecuteAsync(null);
                    await Shell.Current.GoToAsync($"//{nameof(MySpidersPage)}");

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UnkownEmailAddress"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "User does not exist", "OK");
                        return;
                    }
                    else if (ex.Message.Contains("WrongPassword"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Invalid password", "OK");
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
                    IsLoading = false;
                }
            }
        }

        [RelayCommand]
        async void NavigateToRegister()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}
