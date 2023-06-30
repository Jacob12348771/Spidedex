using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using Spidedex.Model;
using Spidedex.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    public partial class SpiderFactSheetsPageViewModel : BaseViewModel
    {
        IDataAccessService _dataAccessService;
        public ObservableCollection<SpiderFactSheet> SpiderFactSheets { get; } = new();
        public SpiderFactSheetsPageViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetSpiderFactSheets()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;

                if (SpiderFactSheets.Count > 0)
                {
                    SpiderFactSheets.Clear();
                }

                var factSheets = await _dataAccessService.GetSpiderFactSheetsAsync();

                foreach (var factSheet in factSheets)
                {
                    SpiderFactSheets.Add(factSheet);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await AppShell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
