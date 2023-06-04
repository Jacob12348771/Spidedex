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

namespace Spidedex.ViewModel
{
    public partial class MySpidersPageViewModel : BaseViewModel
    {
        DataAccessService _dataAccessService;
        public ObservableCollection<Spider> Spiders { get; } = new();

        [ObservableProperty]
        bool isRefreshing;

        public MySpidersPageViewModel(DataAccessService dataAccessService)
        {
            //Title = "Welcome!";
            this._dataAccessService = dataAccessService; 
            GetSpidersCommand.ExecuteAsync(null);
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
    }
}
