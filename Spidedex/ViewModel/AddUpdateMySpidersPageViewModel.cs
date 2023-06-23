using Android.OS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spidedex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    public partial class AddUpdateMySpidersPageViewModel : BaseViewModel
    {
        IDataAccessService _dataAccessService;
        public AddUpdateMySpidersPageViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _species;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _size;

        [ObservableProperty]
        private string _food;

        [ObservableProperty]
        private string _temperament;

        [RelayCommand]
        public async void AddUpdateMySpider()
        {
            /*
            try
            {
                var response = await _dataAccessService.AddUpdateSpiderAsync(new Model.Spider
                {
                    Name = Name,
                    Species = Species,
                    Description = Description,
                    Size = Size,
                    Diet = Food,
                    Temperament = Temperament
                });
            }
            catch (Exception)
            {

                throw;
            }
            */
        }
    }
}
