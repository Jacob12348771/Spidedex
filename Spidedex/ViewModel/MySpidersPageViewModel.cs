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
using Newtonsoft.Json;

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
        }

        [RelayCommand]
        async Task GetSpidersAsync()
        {
            if (!NetworkConnectivity.IsConnected())
            {
                // Check if spiders are saved locally.
                var savedSpiders = Preferences.Get("SavedSpiders", string.Empty);
                if (savedSpiders != string.Empty && Spiders.Count == 0)
                {
                    var spiders = JsonConvert.DeserializeObject<List<Spider>>(savedSpiders);
                    foreach (var spider in spiders)
                    {
                        Spiders.Add(spider);
                    }
                }
                await Shell.Current.DisplayAlert("Error", "No internet connection could be made." +
                                           "Please check connectivity settings and try again.", "OK");
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

                var serializedSpiders = JsonConvert.SerializeObject(Spiders.ToList());
                Preferences.Set("SavedSpiders", serializedSpiders);

            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Oops, something went wrong. Please try again later.", "Ok");
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
            await Shell.Current.GoToAsync(nameof(AddUpdateMySpidersPage));
        }

        [RelayCommand]
        async Task EditSpider(Spider spider)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "SpiderContents", spider }
            };
            await Shell.Current.GoToAsync($"{nameof(AddUpdateMySpidersPage)}", navigationParameter);
        }
    }
}
