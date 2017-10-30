using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LeagueOfNinjaEF.DAL;
using LeagueOfNinjaEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CrudEquipmentViewModel : ViewModelBase, ICrudEquipmentViewModel
    {

        private IUnitOfWork UOW;

        private static ICrudEquipmentViewModel instance;
        public RelayCommand saveButton { get; set; }
        public RelayCommand clearButton { get; set; }
        public RelayCommand deleteButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the CrudEquipmentViewModel class.
        /// </summary>
        public CrudEquipmentViewModel(IUnitOfWork UOW = null)
        {
            if (UOW == null)
                UOW = new UnitOfWork();
            else
                this.UOW = UOW;

            equipmentList = UOW.EquipmentRepository.Get().ToList();
            typeList = UOW.TypeRepository.Get().ToList();
            selectedEquipment = new Equipment();

            saveButton = new RelayCommand(saveEquipment, canSaveEquipment);
            clearButton = new RelayCommand(clearSelectedEquipment);
            deleteButton = new RelayCommand(deleteEquipment, canDeleteEquipment);

            instance = this;
        }

        public static ICrudEquipmentViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    return null;
                }
                return instance;
            }
        }

        /// <summary>
        /// The <see cref="equipmentList" /> property's name.
        /// </summary>
        public const string equipmentListPropertyName = "equipmentList";

        private List<Equipment> _EquipmentList = null;

        /// <summary>
        /// Sets and gets the equipmentList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<Equipment> equipmentList
        {
            get
            {
                return _EquipmentList;
            }

            set
            {
                if (_EquipmentList == value)
                {
                    return;
                }

                _EquipmentList = value;
                RaisePropertyChanged(equipmentListPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="typeList" /> property's name.
        /// </summary>
        public const string typeListPropertyName = "typeList";

        private List<Type> _TypeList = null;

        /// <summary>
        /// Sets and gets the typeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<Type> typeList
        {
            get
            {
                return _TypeList;
            }

            set
            {
                if (_TypeList == value)
                {
                    return;
                }

                _TypeList = value;
                RaisePropertyChanged(typeListPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedType" /> property's name.
        /// </summary>
        public const string selectedTypePropertyName = "selectedType";

        private Type _SelectedType = null;

        /// <summary>
        /// Sets and gets the selectedType property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Type selectedType
        {
            get
            {
                return _SelectedType;
            }

            set
            {
                if (_SelectedType == value)
                {
                    return;
                }

                _SelectedType = value;
                RaisePropertyChanged(selectedTypePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedEquipment" /> property's name.
        /// </summary>
        public const string selectedEquipmentPropertyName = "selectedEquipment";

        private Equipment _SelectedEquipment = new Equipment();

        /// <summary>
        /// Sets and gets the selectedEquipment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Equipment selectedEquipment
        {
            get
            {
                return _SelectedEquipment;
            }

            set
            {
                if (_SelectedEquipment == value)
                {
                    return;
                }

                _SelectedEquipment = value;
                RaisePropertyChanged(selectedEquipmentPropertyName);
            }
        }

        void ICrudEquipmentViewModel.selectedTypeChanged()
        {
            IEnumerable<Equipment> fullEquipmentList = UOW.EquipmentRepository.Get();
            List<Equipment> filteredEquipmentList = new List<Equipment>();

            foreach (var equipment in fullEquipmentList)
            {
                if (equipment.Type == selectedType)
                    filteredEquipmentList.Add(equipment);
            }
            equipmentList = filteredEquipmentList;
        }

        public void saveEquipment()
        {
            if (selectedEquipment.EquipmentId == 0)
            {
                UOW.EquipmentRepository.Insert(new Equipment {
                    Dexterity = selectedEquipment.Dexterity,
                    Health = selectedEquipment.Health,
                    Intelligence = selectedEquipment.Intelligence,
                    Mana = selectedEquipment.Mana,
                    Name = selectedEquipment.Name,
                    Price = selectedEquipment.Price,
                    Stamina = selectedEquipment.Stamina,
                    Strength = selectedEquipment.Strength,
                    Type = selectedEquipment.Type
                });
                UOW.Save();
            }
            else
            {
                UOW.Save();
            }
            clearSelectedEquipment();
            equipmentList = UOW.EquipmentRepository.Get().ToList();
        }

        public void clearSelectedEquipment()
        {
            selectedEquipment = new Equipment();
        }

        public void deleteEquipment()
        {
            UOW.EquipmentRepository.Delete(selectedEquipment);
            UOW.Save();

            clearSelectedEquipment();
            equipmentList = UOW.EquipmentRepository.Get().ToList();
        }

        public bool canSaveEquipment()
        {
            return everyFieldFilled();
        } 

        public bool canDeleteEquipment()
        {
            if (selectedEquipment == null)
                return false;
            if (selectedEquipment.EquipmentId == 0)
                return false;
            return true;
        }

        private bool everyFieldFilled()
        {
            if (selectedEquipment == null)
                return false;
            if (selectedEquipment.Dexterity == 0)
                return false;
            if (selectedEquipment.Health == 0)
                return false;
            if (selectedEquipment.Intelligence == 0)
                return false;
            if (selectedEquipment.Mana == 0)
                return false;
            if (selectedEquipment.Name == "")
                return false;
            if (selectedEquipment.Price == 0)
                return false;
            if (selectedEquipment.Stamina == 0)
                return false;
            if (selectedEquipment.Strength == 0)
                return false;
            if (selectedEquipment.Type == null)
                return false;
            return true;
        }
    }
}