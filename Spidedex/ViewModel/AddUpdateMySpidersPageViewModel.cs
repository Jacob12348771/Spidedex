using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spidedex.Model;
using Spidedex.Services;
using Spidedex.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    [QueryProperty(nameof(SpiderContents), "SpiderContents")]
    public partial class AddUpdateMySpidersPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Spider _spiderContents;

        IDataAccessService _dataAccessService;
        public AddUpdateMySpidersPageViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        [RelayCommand]
        public async void AddUpdateMySpider()
        {
            try
            {
                var response = await _dataAccessService.AddUpdateSpiderAsync(new Model.Spider
                {
                    Name = SpiderContents.Name,
                    Species = SpiderContents.Species,
                    Description = SpiderContents.Description,
                    Size = SpiderContents.Size,
                    Diet = SpiderContents.Diet,
                    //Temperament = (Model.Spider.Tempereament)Enum.Parse(typeof(Model.Spider.Tempereament), SpiderContents.Temperament),
                    UserInfo = App.UserDetails.Email
                });

                await AppShell.Current.DisplayAlert("Success", "Spider added/updated successfully", "Ok");
                await AppShell.Current.GoToAsync($"//{nameof(MySpidersPage)}");
            }
            catch (Exception ex)
            {
                await AppShell.Current.DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
    }
}
