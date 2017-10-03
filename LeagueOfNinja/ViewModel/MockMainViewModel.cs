using LeagueOfNinjaEF.Models;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;

namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MockMainViewModel : IMainViewModel
    {
        ///All Parameters

        ///No observer|observable paramaters(only for mocking)
        public List<Equipment> fullEquipmentList;
        
        /// <summary>
        /// Initializes a new instance of the MockMainViewModel class.
        /// </summary>
        public MockMainViewModel()
        {
            fillTypeList();
            fillEquipmentList();
            fillNinjaList();

            equipButton = new RelayCommand(equipEquipment, canEquipEquipment);
            unequipButton = new RelayCommand(unequipEquipment, canUnequipEquipment);
        }

        /// <summary>
        /// Should do ninjaGetAll
        /// </summary>
        protected override void fillNinjaList()
        {
            ninjaList = new List<Ninja>();

            Ninja ninja1 = new Ninja();
            ninja1.Name = "ninja1";
            ninja1.Helmet = EquipmentList[2];
            ninja1.Chest = EquipmentList[4];
            ninjaList.Add(ninja1);

            Ninja ninja2 = new Ninja();
            ninja2.Name = "ninja2";
            ninjaList.Add(ninja2);
        }

        /// <summary>
        /// should do typeGetAll
        /// </summary>
        protected override void fillTypeList()
        {
            typeList = new List<LeagueOfNinjaEF.Models.Type>();

            #region Create Types
            LeagueOfNinjaEF.Models.Type typeHoofd = new LeagueOfNinjaEF.Models.Type();
            LeagueOfNinjaEF.Models.Type typeChest = new LeagueOfNinjaEF.Models.Type();
            LeagueOfNinjaEF.Models.Type typeLegs = new LeagueOfNinjaEF.Models.Type();
            #endregion

            #region Set Types
            typeHoofd.Name = "Head";
            typeChest.Name = "Chest";
            typeLegs.Name = "Legs";
            #endregion

            #region Add Types
            typeList.Add(typeHoofd);
            typeList.Add(typeChest);
            typeList.Add(typeLegs);
            #endregion
        }

        /// <summary>
        /// should do equipmentGetAll
        /// </summary>
        protected override void fillEquipmentList()
        {
            EquipmentList = new List<Equipment>();

            #region Create Gear
            Equipment headGear1 = new Equipment();
            Equipment headGear2 = new Equipment();
            Equipment headGear3 = new Equipment();

            Equipment chestGear1 = new Equipment();
            Equipment chestGear2 = new Equipment();
            Equipment chestGear3 = new Equipment();

            Equipment legGear1 = new Equipment();
            Equipment legGear2 = new Equipment();
            Equipment legGear3 = new Equipment();
            #endregion

            #region Set Gear
            headGear1.Type = typeList[0];
            headGear1.Name = "Bronze helmet";
            headGear1.Health = 100;
            headGear1.Mana = 10;
            headGear1.Stamina = 10;
            headGear1.Strength = 5;
            headGear1.Intelligence = 2;
            headGear1.Dexterity = 4;
            headGear1.Price = 50;

            headGear2.Type = typeList[0];
            headGear2.Name = "Hide helmet";
            headGear2.Health = 50;
            headGear2.Mana = 10;
            headGear2.Stamina = 50;
            headGear2.Strength = 3;
            headGear2.Intelligence = 2;
            headGear2.Dexterity = 7;
            headGear2.Price = 50;

            headGear3.Type = typeList[0];
            headGear3.Name = "Leather helmet";
            headGear3.Health = 20;
            headGear3.Mana = 100;
            headGear3.Stamina = 4;
            headGear3.Strength = 2;
            headGear3.Intelligence = 1;
            headGear3.Dexterity = 6;
            headGear3.Price = 30;

            chestGear1.Type = typeList[1];
            chestGear1.Name = "Bronze chest";
            chestGear1.Health = 120;
            chestGear1.Mana = 15;
            chestGear1.Stamina = 30;
            chestGear1.Strength = 7;
            chestGear1.Intelligence = 3;
            chestGear1.Dexterity = 6;
            chestGear1.Price = 150;
            chestGear2.Type = typeList[1];
            chestGear2.Name = "Hide chest";
            chestGear2.Health = 50;
            chestGear2.Mana = 10;
            chestGear2.Stamina = 50;
            chestGear2.Strength = 3;
            chestGear2.Intelligence = 2;
            chestGear2.Dexterity = 7;
            chestGear2.Price = 150;
            chestGear3.Type = typeList[1];
            chestGear3.Name = "Leather chest";
            chestGear3.Health = 20;
            chestGear3.Mana = 100;
            chestGear3.Stamina = 4;
            chestGear3.Strength = 2;
            chestGear3.Intelligence = 1;
            chestGear3.Dexterity = 6;
            chestGear3.Price = 130;

            legGear1.Type = typeList[2];
            legGear1.Name = "Bronze legs";
            legGear1.Health = 120;
            legGear1.Mana = 15;
            legGear1.Stamina = 30;
            legGear1.Strength = 7;
            legGear1.Intelligence = 3;
            legGear1.Dexterity = 6;
            legGear1.Price = 80;
            legGear2.Type = typeList[2];
            legGear2.Name = "Hide legs";
            legGear2.Health = 50;
            legGear2.Mana = 10;
            legGear2.Stamina = 50;
            legGear2.Strength = 3;
            legGear2.Intelligence = 2;
            legGear2.Dexterity = 7;
            legGear2.Price = 80;
            legGear3.Type = typeList[2];
            legGear3.Name = "Leather legs";
            legGear3.Health = 20;
            legGear3.Mana = 100;
            legGear3.Stamina = 4;
            legGear3.Strength = 2;
            legGear3.Intelligence = 1;
            legGear3.Dexterity = 6;
            legGear3.Price = 70;
            #endregion

            #region Add Gear
            EquipmentList.Add(headGear1);
            EquipmentList.Add(headGear2);
            EquipmentList.Add(headGear3);
            EquipmentList.Add(chestGear1);
            EquipmentList.Add(chestGear2);
            EquipmentList.Add(chestGear3);
            EquipmentList.Add(legGear1);
            EquipmentList.Add(legGear2);
            EquipmentList.Add(legGear3);
            fullEquipmentList = EquipmentList;
            #endregion

        }

        /// <summary>
        /// Should do database equipmentGetWithType.
        /// Type it should use is var selectedType
        /// </summary>
        protected override void selectedTypeChanged()
        {
            List<LeagueOfNinjaEF.Models.Equipment> filteredEquipmentList = new List<LeagueOfNinjaEF.Models.Equipment>();
            foreach (var equipment in fullEquipmentList)
            {
                if (equipment.Type == selectedType)
                    filteredEquipmentList.Add(equipment);
            }
            EquipmentList = filteredEquipmentList;
        }

        /// <summary>
        /// should do a put with the selected ninja
        /// </summary>
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

            calculateTotalStats();
        }

        /// <summary>
        /// should do a deleteEquipment from ninja
        /// </summary>
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

            calculateTotalStats();
        }
    }
}