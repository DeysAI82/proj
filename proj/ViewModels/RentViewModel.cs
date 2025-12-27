using proj.Commands;
using proj.Models.Entities;
using proj.Repositories;
using proj.Services;
using System.Collections.ObjectModel;

namespace proj.ViewModels
{
    public class RentViewModel : PropertyChangedBase
    {
        private readonly RentalRequestRepository _rentalRepository = new();

        public ObservableCollection<RentalRequest> Rentals { get; set; }

        private RentalRequest _selectedRental;
        public RentalRequest SelectedRental
        {
            get => _selectedRental;
            set { _selectedRental = value; OnPropertyChanged(); }
        }

        public MyCommand DeleteCommand { get; }

        public RentViewModel()
        {
            Load();

            DeleteCommand = new MyCommand(
                _ => Delete(),
                _ => SelectedRental != null
            );
        }

        private void Load()
        {
            if (Session.HasRole("Administrator"))
                Rentals = new ObservableCollection<RentalRequest>(_rentalRepository.GetAll());
            else
                Rentals = new ObservableCollection<RentalRequest>(
                    _rentalRepository.GetByUser(Session.CurrentUser.UserId)
                );

            OnPropertyChanged(nameof(Rentals));
        }

        private void Delete()
        {
            if (SelectedRental == null) return;

            _rentalRepository.Delete(SelectedRental.RequestId);
            Rentals.Remove(SelectedRental);
        }
    }
}
