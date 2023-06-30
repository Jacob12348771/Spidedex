using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spidedex.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    [QueryProperty(nameof(SpiderFactSheet), "SpiderFactSheet")]
    public partial class IndividualSpiderFactSheetPageViewModel : BaseViewModel
    {
        IMap map;
        public IndividualSpiderFactSheetPageViewModel(IMap map)
        {
            this.map = map;
        }

        [ObservableProperty]
        private SpiderFactSheet _spiderFactSheet = new SpiderFactSheet();

        [RelayCommand]
        async Task ShowSpiderLocation()
        {
            try
            {
                await map.OpenAsync(SpiderFactSheet.Lat, SpiderFactSheet.Long,
                    new MapLaunchOptions
                    {
                        Name = SpiderFactSheet.Name,
                        NavigationMode = NavigationMode.None
                    });
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Oops, something went wrong. Error opening map. Please try again later.", "Ok");

            }
        }
    }
}
