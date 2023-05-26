using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spidedex.View;

namespace Spidedex.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [RelayCommand]
        void Login()
        {
            Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        }
    }
}
