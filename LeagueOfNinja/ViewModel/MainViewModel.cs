using GalaSoft.MvvmLight;
using LeagueOfNinjaEF.Models;
using LeagueOfNinjaEF.DAL;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Linq;

namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : IMainViewModel
    {
        private IUnitOfWork UOW;

        private static IMainViewModel instance;

        public MainViewModel(IUnitOfWork UOW = null)
        {
            if (UOW == null)
                UOW = new UnitOfWork();
            else
                this.UOW = UOW;
            fillTypeList();
            fillEquipmentList();
            fillNinjaList();
            
            equipButton = new RelayCommand(equipEquipment, canEquipEquipment);
            unequipButton = new RelayCommand(unequipEquipment, canUnequipEquipment);
            instance = this;
        }

        public static IMainViewModel Instance
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

        public override void equipEquipment()
        {
            string selectedType = selectedEquipment.Type.Name;

            switch (selectedType)
            {
                case "Head":
                    selectedNinja.Helmet = selectedEquipment;
                    break;
                case "Chest":
                    selectedNinja.Chest = selectedEquipment;
                    break;
                case "Legs":
                    selectedNinja.Legs = selectedEquipment;
                    break;
                case "Gloves":
                    selectedNinja.Gloves = selectedEquipment;
                    break;
                case "Shoes":
                    selectedNinja.Shoes = selectedEquipment;
                    break;
                default:
                    break;
            }

            UOW.Save();
            calculateTotalStats();
            RaisePropertyChanged(selectedNinjaPropertyName);
        }

        public override void unequipEquipment()
        {
            string selectedType = selectedEquipment.Type.Name;

            switch (selectedType)
            {
                case "Head":
                    selectedNinja.Helmet = null;
                    break;
                case "Chest":
                    selectedNinja.Chest = null;
                    break;
                case "Legs":
                    selectedNinja.Legs = null;
                    break;
                case "Gloves":
                    selectedNinja.Gloves = null;
                    break;
                case "Shoes":
                    selectedNinja.Shoes = null;
                    break;
                default:
                    break;
            }

            UOW.Save();
            calculateTotalStats();
        }

        protected override void fillEquipmentList()
        {
            EquipmentList = UOW.EquipmentRepository.Get().ToList();
        }

        protected override void fillNinjaList()
        {
            ninjaList = UOW.NinjaRepository.Get().ToList();
        }

        protected override void fillTypeList()
        {
            typeList = UOW.TypeRepository.Get().ToList();
        }

        protected override void selectedTypeChanged()
        {
            IEnumerable<Equipment> fullEquipmentList = UOW.EquipmentRepository.Get();
            List<Equipment> filteredEquipmentList = new List<Equipment>();
            
            foreach(var equipment in fullEquipmentList)
            {
                if (equipment.Type == selectedType)
                    filteredEquipmentList.Add(equipment);
            }
            EquipmentList = filteredEquipmentList;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        ///All Parameters


    }
}