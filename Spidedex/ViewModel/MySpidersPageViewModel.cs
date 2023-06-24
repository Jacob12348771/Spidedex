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
                await Shell.Current.DisplayAlert("Error", ex.ToString(), "OK");
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
