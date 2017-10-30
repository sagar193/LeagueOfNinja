using GalaSoft.MvvmLight;
using LeagueOfNinjaEF.Models;
using LeagueOfNinjaEF.DAL;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Linq;
using System.Windows;

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
            openManageEquipmentsButton = new RelayCommand(openManageEquipments);
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

            if (selectedEquipment.Price > selectedNinja.Money)
            {
                message = "Price is higher then money left on ninja";
                return;
            }

            switch (selectedType)
            {
                case "Head":
                    priceReplace(selectedNinja.Helmet, selectedEquipment);
                    selectedNinja.Helmet = selectedEquipment;
                    break;
                case "Chest":
                    priceReplace(selectedNinja.Chest, selectedEquipment);
                    selectedNinja.Chest = selectedEquipment;
                    break;
                case "Legs":
                    priceReplace(selectedNinja.Legs, selectedEquipment);
                    selectedNinja.Legs = selectedEquipment;
                    break;
                case "Gloves":
                    priceReplace(selectedNinja.Gloves, selectedEquipment);
                    selectedNinja.Gloves = selectedEquipment;
                    break;
                case "Shoes":
                    priceReplace(selectedNinja.Shoes, selectedEquipment);
                    selectedNinja.Shoes = selectedEquipment;
                    break;
                default:
                    break;
            }

            UOW.Save();
            calculateTotalStats();
            differenceEquipment = new Equipment();
            RaisePropertyChanged(selectedNinjaPropertyName);
        }

        private void priceReplace(Equipment oldEquipment, Equipment newEquipment)
        {
            if (oldEquipment != null)
            {
                selectedNinja.Money += oldEquipment.Price;
            }
            selectedNinja.Money -= newEquipment.Price;
        }

        public override void unequipEquipment()
        {
            string selectedType = selectedEquipment.Type.Name;

            switch (selectedType)
            {
                case "Head":
                    selectedNinja.Money += selectedNinja.Helmet.Price;
                    selectedNinja.Helmet = null;
                    break;
                case "Chest":
                    selectedNinja.Money += selectedNinja.Chest.Price;
                    selectedNinja.Chest = null;
                    break;
                case "Legs":
                    selectedNinja.Money += selectedNinja.Legs.Price;
                    selectedNinja.Legs = null;
                    break;
                case "Gloves":
                    selectedNinja.Money += selectedNinja.Gloves.Price;
                    selectedNinja.Gloves = null;
                    break;
                case "Shoes":
                    selectedNinja.Money += selectedNinja.Shoes.Price;
                    selectedNinja.Shoes = null;
                    break;
                default:
                    break;
            }

            UOW.Save();
            calculateTotalStats();
            differenceEquipment = selectedEquipment;
            RaisePropertyChanged(selectedNinjaPropertyName);
        }

        public void openManageEquipments()
        {
            var EV = new Views.CrudEquipmentView();
            App.Current.MainWindow = EV;
            EV.Show();
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
    }
}