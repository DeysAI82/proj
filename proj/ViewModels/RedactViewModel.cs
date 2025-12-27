using proj.Commands;
using proj.Models.Entities;
using proj.Repositories;
using proj.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace proj.ViewModels
{
    public class RedactViewModel : PropertyChangedBase
    {
        private readonly EquipmentRepository _equipmentRepository;

        private readonly RentalRequestRepository _rentalRepository;


        public ObservableCollection<Equipment> Equipments { get; set; }

        private Equipment _selectedEquipment;
        public Equipment SelectedEquipment
        {
            get => _selectedEquipment;
            set { _selectedEquipment = value; OnPropertyChanged(); }
        }
        public bool IsAdmin => Session.HasRole("Administrator");
        public bool IsWorker => Session.HasRole("Worker");
        public bool IsClient => Session.HasRole("Client");

        public MyCommand RentCommand { get; }

        public RedactViewModel()
        {

            _equipmentRepository = new EquipmentRepository();

            _rentalRepository = new RentalRequestRepository();

            Equipments = new ObservableCollection<Equipment>(_equipmentRepository.GetAll());

            RentCommand = new MyCommand(_ => RentEquipment(), _ => SelectedEquipment != null);
        }

        private void RentEquipment()
        {
            var request = new RentalRequest
            {
                ClientId = Session.CurrentUser.UserId,
                EquipmentId = SelectedEquipment.EquipmentId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RentalType = "Daily",
                Status = "Active",
                CreatedDate = DateTime.Now
            };

            _rentalRepository?.Add(request);

            MessageBox.Show("Техника успешно арендована!");
        }

    }

}

