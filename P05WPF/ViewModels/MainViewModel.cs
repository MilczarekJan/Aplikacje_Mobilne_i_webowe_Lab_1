using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using P05WPF.Services;
using P06Shop.Shared.Shop;

namespace P05WPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IMyApiService _apiService;

        public MainViewModel(IMyApiService apiService)
        {
            _apiService = apiService;
            // Initialize properties
            ShoeName = string.Empty;
            ShoeSize = 0;
            ShoeDescription = string.Empty;
        }

        [ObservableProperty]
        private ShoeViewModel selectedShoe;

        private int selectedShoeId;
        public int SelectedShoeId
        {
            get => selectedShoeId;
            set => SetProperty(ref selectedShoeId, value);
        }

        private string shoeName;
        public string ShoeName
        {
            get => shoeName;
            set => SetProperty(ref shoeName, value);
        }

        private double shoeSize;
        public double ShoeSize
        {
            get => shoeSize;
            set => SetProperty(ref shoeSize, value);
        }

        private string shoeDescription;
        public string ShoeDescription
        {
            get => shoeDescription;
            set => SetProperty(ref shoeDescription, value);
        }

        [RelayCommand]
        public async void GetShoe()
        {
            try
            {
                Shoe shoe = await _apiService.GetShoeAsync(SelectedShoeId);
                //Shoe shoe = new Shoe(SelectedShoeId, 44.5, "Adidas", "Nike");
                SelectedShoe = new ShoeViewModel(shoe);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
