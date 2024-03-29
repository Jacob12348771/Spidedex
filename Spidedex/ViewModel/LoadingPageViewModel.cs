﻿using Newtonsoft.Json;
using Spidedex.Controls;
using Spidedex.Model;
using Spidedex.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    public partial class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            checkLoginDetails();
        }

        private async void checkLoginDetails()
        {
            string userDetailsString = Preferences.Get(nameof(App.UserDetails), "");

            if (string.IsNullOrWhiteSpace(userDetailsString))
            {
                if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Task.Delay(200);
                        await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
                    });
                }
                else
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
            }
            else
            {
                var userDetails = JsonConvert.DeserializeObject<User>(userDetailsString);
                App.UserDetails = userDetails;
                Shell.Current.FlyoutHeader = new HeaderControl();
                await Shell.Current.GoToAsync($"//{nameof(MySpidersPage)}");
            }
        }
    }
}
