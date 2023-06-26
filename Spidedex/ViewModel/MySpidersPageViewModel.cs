using Spidedex.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spidedex.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Spidedex.View;
using Spidedex.Helper;

namespace Spidedex.ViewModel
{
    public partial class MySpidersPageViewModel : BaseViewModel
    {
        IDataAccessService _dataAccessService;
        public ObservableCollection<Spider> Spiders { get; } = new();

        [ObservableProperty]
        bool isRefreshing;

        public MySpidersPageViewModel(IDataAccessService dataAccessService)
        {
            this._dataAccessService = dataAccessService;

            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                GetSpidersCommand.ExecuteAsync(null);
            }
        }

        [RelayCommand]
        async Task GetSpidersAsync()
        {
            if (!NetworkConnectivity.IsConnected())
            {
                await AppShell.Current.DisplayAlert("Error", "No internet connection could be made." +
                                           "Unfortunately Spidedex needs network access. Please check connectivity settings and try again.", "OK");
                return;
            }
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var spiders = await _dataAccessService.GetSpidersAsync(App.UserDetails.Email);
                if (Spiders.Count != 0)
                {
                    Spiders.Clear();
                }
                foreach (var spider in spiders)
                {
                    Spiders.Add(spider);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "No internet connection could be made." +
                    "Unfortunately Spidedex needs network access. Please check connectivity settings and try again.", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task AddUpdateMySpider()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateMySpidersPage));
        }

        [RelayCommand]
        async Task EditSpider(Spider spider)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "SpiderContents", spider }
            };
            await AppShell.Current.GoToAsync($"{nameof(AddUpdateMySpidersPage)}", navigationParameter);
        }
    }
}
