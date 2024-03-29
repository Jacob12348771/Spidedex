﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Spidedex.Helper;
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
        private Spider _spiderContents = new Spider();

        [ObservableProperty]
        private bool _IsLoading;

        [ObservableProperty]
        private bool _EntryExists;

        IDataAccessService _dataAccessService;
        public AddUpdateMySpidersPageViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await QuerySpiderContentsExist();
        }

        private async Task QuerySpiderContentsExist()
        {
            // before load, do a quick check to see if the spider exists.
            await Task.Delay(100);

            if (SpiderContents.Id > 0)
            {
                EntryExists = true;
            }
            else
            {
                EntryExists = false;
            }
        }

        [RelayCommand]
        public async void AddUpdateMySpider()
        {
            try
            {
                if (!NetworkConnectivity.IsConnected())
                {
                    await Shell.Current.DisplayAlert("Error", "No internet connection could be made." +
                                               "Please check connectivity settings and try again.", "OK");
                    return;
                }
                if (IsLoading)
                {
                    return;
                }

                if (SpiderContents.Name != null && SpiderContents.Species != null)
                {
                    IsLoading = true;
                    bool response;
                    if (SpiderContents.Id > 0)
                    {
                        response = await _dataAccessService.AddUpdateSpiderAsync(SpiderContents);
                    }
                    else
                    {
                        response = await _dataAccessService.AddUpdateSpiderAsync(new Model.Spider
                        {
                            Name = SpiderContents.Name,
                            Species = SpiderContents.Species,
                            Description = SpiderContents.Description,
                            Size = SpiderContents.Size,
                            Diet = SpiderContents.Diet,
                            DateObtained = SpiderContents.DateObtained,
                            // Convert the string to enum for the temperament
                            Temperament = (Model.Spider.Tempereament)Enum.Parse(typeof(Model.Spider.Tempereament), SpiderContents.Temperament.ToString()),
                            UserInfo = App.UserDetails.Email
                        });
                    }

                    await Shell.Current.DisplayAlert("Success", "Spider added/updated successfully", "Ok");
                    await Shell.Current.GoToAsync($"//{nameof(MySpidersPage)}");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Please fill out name and species", "Ok");
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Oops, something went wrong. Please try again later.", "Ok");
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        public async void DeleteSpider(Spider spider)
        {
            try
            {
                if (!NetworkConnectivity.IsConnected())
                {
                    await Shell.Current.DisplayAlert("Error", "No internet connection could be made." +
                                               "Unfortunately Spidedex needs network access. Please check connectivity settings and try again.", "OK");
                    return;
                }
                if (IsLoading)
                {
                    return;
                }

                var userChoice = await Shell.Current.DisplayAlert("Delete Spider", "Are you sure you want to delete this spider?", "Yes", "No");

                if (!userChoice)
                {
                    IsLoading = false;
                    return;
                }
                else
                {
                    IsLoading = true;
                    bool response = await _dataAccessService.DeleteSpiderAsync(spider.Id);

                    await Shell.Current.DisplayAlert("Success", "Spider has been successfully deleted", "Ok");
                    await Shell.Current.GoToAsync($"//{nameof(MySpidersPage)}");
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Oops, something went wrong. Please try again later.", "Ok");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
