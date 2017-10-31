using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using LeagueOfNinjaEF.Models;
using GalaSoft.MvvmLight.CommandWpf;

namespace LeagueOfNinja.ViewModel
{
    public abstract class IMainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="typeList" /> property's name.
        /// </summary>
        public const string typeListPropertyName = "typeList";

        private List<LeagueOfNinjaEF.Models.Type> _typeList = new List<LeagueOfNinjaEF.Models.Type>();

        /// <summary>
        /// Sets and gets the typeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<LeagueOfNinjaEF.Models.Type> typeList
        {
            get
            {
                return _typeList;
            }

            set
            {
                if (_typeList == value)
                {
                    return;
                }

                _typeList = value;
                RaisePropertyChanged(typeListPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="EquipmentList" /> property's name.
        /// </summary>
        public const string EquipmentListPropertyName = "EquipmentList";

        private List<Equipment> _EquipmentList = new List<Equipment>();

        /// <summary>
        /// Sets and gets the EquipmentList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<Equipment> EquipmentList
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
                RaisePropertyChanged(EquipmentListPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ninjaList" /> property's name.
        /// </summary>
        public const string ninjaListPropertyName = "ninjaList";

        private List<Ninja> _ninjaList = new List<Ninja>();

        /// <summary>
        /// Sets and gets the ninjaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<Ninja> ninjaList
        {
            get
            {
                return _ninjaList;
            }

            set
            {
                if (_ninjaList == value)
                {
                    return;
                }

                _ninjaList = value;
                RaisePropertyChanged(ninjaListPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedType" /> property's name.
        /// </summary>
        public const string selectedTypePropertyName = "selectedType";

        private LeagueOfNinjaEF.Models.Type _selectedType = new LeagueOfNinjaEF.Models.Type();

        /// <summary>
        /// Sets and gets the selectedType property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LeagueOfNinjaEF.Models.Type selectedType
        {
            get
            {
                return _selectedType;
            }

            set
            {
                if (_selectedType == value)
                {
                    return;
                }

                _selectedType = value;
                RaisePropertyChanged(selectedTypePropertyName);
                selectedTypeChanged();
            }
        }

        /// <summary>
        /// The <see cref="selectedNinja" /> property's name.
        /// </summary>
        public const string selectedNinjaPropertyName = "selectedNinja";

        private Ninja _selectedNinja = new Ninja();

        /// <summary>
        /// Sets and gets the selectedNinja property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Ninja selectedNinja
        {
            get
            {
                return _selectedNinja;
            }

            set
            {
                if (_selectedNinja == value)
                {
                    return;
                }

                _selectedNinja = value;
                calculateTotalStats();
                RaisePropertyChanged(selectedNinjaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedEquipment" /> property's name.
        /// </summary>
        public const string selectedEquipmentPropertyName = "selectedEquipment";

        private Equipment _SelectedEquipment = null;

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
                selectedEquipmentChanged();
                RaisePropertyChanged(selectedEquipmentPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="differenceEquipment" /> property's name.
        /// </summary>
        public const string differenceEquipmentPropertyName = "differenceEquipment";

        private Equipment _differenceEquipment = null;

        /// <summary>
        /// Sets and gets the differenceEquipment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Equipment differenceEquipment
        {
            get
            {
                return _differenceEquipment;
            }

            set
            {
                if (_differenceEquipment == value)
                {
                    return;
                }

                _differenceEquipment = value;
                RaisePropertyChanged(differenceEquipmentPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="totalEquipment" /> property's name.
        /// </summary>
        public const string totalEquipmentPropertyName = "totalEquipment";

        private Equipment _totalEquipment = null;

        /// <summary>
        /// Sets and gets the totalEquipment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Equipment totalEquipment
        {
            get
            {
                return _totalEquipment;
            }

            set
            {
                if (_totalEquipment == value)
                {
                    return;
                }

                _totalEquipment = value;
                RaisePropertyChanged(totalEquipmentPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="message" /> property's name.
        /// </summary>
        public const string messagePropertyName = "message";

        private string _message= "";

        /// <summary>
        /// Sets and gets the message property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string message
        {
            get
            {
                return _message;
            }

            set
            {
                if (_message == value)
                {
                    return;
                }

                _message = value;
                RaisePropertyChanged(messagePropertyName);
            }
        }

        public RelayCommand equipButton { get; protected set; }
        public RelayCommand unequipButton { get; protected set; }
        public RelayCommand openManageEquipmentsButton { get; protected set; }
        public RelayCommand emptyNinjaButton { get; protected set; }

        abstract public void refreshNinjaList();

        abstract public void refreshTypeList();

        abstract public void refreshEquipmentList();

        abstract protected void selectedTypeChanged();

        /// <summary>
        /// is being executed everytime the selected equipment is changed
        /// </summary>
        protected void selectedEquipmentChanged()
        {
            message = "";
            if (selectedEquipment == null)
            {
                setDifferenceEquipment(null);
                return;
            }

            Equipment equipedEquipment = getEquipedEquipmentOfSelectedType();

            setDifferenceEquipment(equipedEquipment);

        }

        ///<summary/>
        /// <returns>equipment which is equiped in the currently selected slot</returns>
        protected Equipment getEquipedEquipmentOfSelectedType()
        {
            string selectedType = selectedEquipment.Type.Name;
            Equipment equipedEquipment = null;

            switch (selectedType)
            {
                case "Head":
                    equipedEquipment = selectedNinja.Helmet;
                    break;
                case "Chest":
                    equipedEquipment = selectedNinja.Chest;
                    break;
                case "Legs":
                    equipedEquipment = selectedNinja.Legs;
                    break;
                case "Gloves":
                    equipedEquipment = selectedNinja.Gloves;
                    break;
                case "Shoes":
                    equipedEquipment = selectedNinja.Shoes;
                    break;
                default:
                    break;
            }

            return equipedEquipment;
        }

        /// <summary>
        /// used to calculate the difference in equipment
        /// between the equiped item and the selected item
        /// </summary>
        /// <param name="equipedEquipment"></param>
        protected void setDifferenceEquipment(Equipment equipedEquipment)
        {
            Equipment test = new Equipment();

            if (equipedEquipment == null)
            {
                differenceEquipment = selectedEquipment;
                return;
            }

            test.Health = selectedEquipment.Health - equipedEquipment.Health;
            test.Mana = selectedEquipment.Mana - equipedEquipment.Mana;
            test.Stamina = selectedEquipment.Stamina - equipedEquipment.Stamina;
            test.Strength = selectedEquipment.Strength - equipedEquipment.Strength;
            test.Intelligence = selectedEquipment.Intelligence - equipedEquipment.Intelligence;
            test.Dexterity = selectedEquipment.Dexterity - equipedEquipment.Dexterity;
            test.Price = selectedEquipment.Price - equipedEquipment.Price;
            differenceEquipment = test;
        }

        /// <summary>
        /// calculate the sum off all the equipment same, as nonmock
        /// </summary>
        protected void calculateTotalStats()
        {
            Equipment total = new Equipment();

            if (selectedNinja == null)
                return;
            if (selectedNinja.Chest != null)
                addEquipmentTo(total, selectedNinja.Chest);
            if (selectedNinja.Helmet != null)
                addEquipmentTo(total, selectedNinja.Helmet);
            if (selectedNinja.Legs != null)
                addEquipmentTo(total, selectedNinja.Legs);
            if (selectedNinja.Gloves != null)
                addEquipmentTo(total, selectedNinja.Gloves);
            if (selectedNinja.Shoes != null)
                addEquipmentTo(total, selectedNinja.Shoes);

            totalEquipment = total;
        }

        /// <summary>
        /// used to calculate the sum off all the equipment, same as nonmock
        /// </summary>
        /// <param name="total">the eventually sum of the equipment</param>
        /// <param name="toAdd">equipment which stats should be added to the sum</param>
        /// <returns></returns>
        protected Equipment addEquipmentTo(Equipment total, Equipment toAdd)
        {
            total.Health += toAdd.Health;
            total.Mana += toAdd.Mana;
            total.Stamina += toAdd.Stamina;
            total.Strength += toAdd.Strength;
            total.Intelligence += toAdd.Intelligence;
            total.Dexterity += toAdd.Dexterity;
            total.Price += toAdd.Price;

            return total;
        }

        abstract public void equipEquipment();

        abstract public void unequipEquipment();

        /// <summary>
        /// view things, same as nonmock
        /// </summary>
        /// <returns>if you can equip the selected item</returns>
        public bool canEquipEquipment()
        {
            if (selectedEquipment == null)
                return false;

            if (selectedEquipment == getEquipedEquipmentOfSelectedType())
                return false;

            return true;
        }

        /// <summary>
        /// view things, same as nonmock
        /// </summary>
        /// <returns>if you can unequip the selected item</returns>
        public bool canUnequipEquipment()
        {
            if (selectedEquipment == null)
                return false;

            if (selectedEquipment == getEquipedEquipmentOfSelectedType())
                return true;

            return false;
        }

        abstract public void setNinja(int id);
    }
}
