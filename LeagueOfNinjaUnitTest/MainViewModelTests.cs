using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LeagueOfNinjaEF.DAL;
using LeagueOfNinjaEF.Models;
using System.Collections.Generic;
using LeagueOfNinja.ViewModel;
using FluentAssertions;

namespace LeagueOfNinjaUnitTest
{
    [TestClass]
    public class MainViewModelTests
    {
        List<Ninja> ninjaList = new List<Ninja>();
        List<Equipment> equipmentList = new List<Equipment>();
        List<LeagueOfNinjaEF.Models.Type> typeList = new List<LeagueOfNinjaEF.Models.Type>();
        Mock<IUnitOfWork> mockUnitOfWork;
        IMainViewModel mainViewModel;

        public MainViewModelTests()
        {
            setup();
        }

        private void setup()
        {
            fillTypeList();
            fillEquipmentList();
            fillNinjaList();

            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.NinjaRepository.Get(null, null, "")).Returns(ninjaList);
            mockUnitOfWork.Setup(x => x.EquipmentRepository.Get(null, null, "")).Returns(equipmentList);
            mockUnitOfWork.Setup(x => x.TypeRepository.Get(null, null, "")).Returns(typeList);

            mainViewModel = new MainViewModel(mockUnitOfWork.Object);
        }

        [TestMethod]
        public void fillingSuccessfull()
        {
            mainViewModel.ninjaList.Should().Equal(ninjaList);
            mainViewModel.EquipmentList.Should().Equal(equipmentList);
            mainViewModel.typeList.Should().Equal(typeList);
        }

        [TestMethod]
        public void selectNinja()
        {
            mainViewModel.selectedNinja = mainViewModel.ninjaList[1];
            mainViewModel.totalEquipment.Health.Should().Be(0);
            mainViewModel.totalEquipment.Dexterity.Should().Be(0);
            mainViewModel.totalEquipment.Intelligence.Should().Be(0);
            mainViewModel.totalEquipment.Mana.Should().Be(0);
            mainViewModel.totalEquipment.Price.Should().Be(0);
            mainViewModel.totalEquipment.Stamina.Should().Be(0);
            mainViewModel.totalEquipment.Strength.Should().Be(0);
        }

        [TestMethod]
        public void equipAndUnequipEquipment()
        {
            mainViewModel.selectedNinja = mainViewModel.ninjaList[1];
            #region equiping the item
            var equipedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.selectedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.equipEquipment();
            #endregion

            #region testing if calculation works
            statCalculation(mainViewModel.totalEquipment, equipedEquipment);
            #endregion
            
            #region unequiping the equipment
            mainViewModel.selectedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.unequipEquipment();
            #endregion

            #region testing if equipment is removed by calculating
            statCalculation(mainViewModel.totalEquipment, new Equipment());
            #endregion
            
        }

        [TestMethod]
        public void equipAndUnequip2EquipmentDifferentType()
        {
            mainViewModel.selectedNinja = mainViewModel.ninjaList[1];
            #region equiping the item
            var equipedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.selectedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.equipEquipment();
            #endregion

            #region equiping the second item
            var secondequipedEquipment = mainViewModel.EquipmentList[4];
            mainViewModel.selectedEquipment = mainViewModel.EquipmentList[4];
            mainViewModel.equipEquipment();
            #endregion

            #region adding both stats
            var totalEquipment = addEquipmentTot(equipedEquipment, secondequipedEquipment);
            #endregion

            #region testing by calculating
            statCalculation(mainViewModel.totalEquipment, totalEquipment);
            #endregion
        }

        [TestMethod]
        public void equipAndUnequip2EquipmentSameType()
        {
            mainViewModel.selectedNinja = mainViewModel.ninjaList[1];
            ///equiping the item
            var equipedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.selectedEquipment = mainViewModel.EquipmentList[0];
            mainViewModel.equipEquipment();

            ///selecting the second item
            var secondequipedEquipment = mainViewModel.EquipmentList[2];
            mainViewModel.selectedEquipment = mainViewModel.EquipmentList[2];

            ///test difference Equipment
            var differenceEquipment = substractEquipmentTot(secondequipedEquipment, equipedEquipment);
            statCalculation(mainViewModel.differenceEquipment, differenceEquipment);
            
            ///equiping the item
            mainViewModel.equipEquipment();

            ///testing by calculating
            statCalculation(mainViewModel.totalEquipment, secondequipedEquipment);
        }

        Equipment substractEquipmentTot(Equipment firstEquipment, Equipment secondEquipment)
        {
            Equipment newEquipment = new Equipment();

            newEquipment.Health = firstEquipment.Health - secondEquipment.Health;
            newEquipment.Dexterity = firstEquipment.Dexterity - secondEquipment.Dexterity;
            newEquipment.Intelligence = firstEquipment.Intelligence - secondEquipment.Intelligence;
            newEquipment.Mana = firstEquipment.Mana - secondEquipment.Mana;
            newEquipment.Price = firstEquipment.Price - secondEquipment.Price;
            newEquipment.Stamina = firstEquipment.Stamina - secondEquipment.Stamina;
            newEquipment.Strength = firstEquipment.Strength - secondEquipment.Strength;

            return newEquipment;
        }

        Equipment addEquipmentTot(Equipment firstEquipment, Equipment secondEquipment)
        {
            Equipment newEquipment = new Equipment();

            newEquipment.Health = firstEquipment.Health + secondEquipment.Health;
            newEquipment.Dexterity = firstEquipment.Dexterity + secondEquipment.Dexterity;
            newEquipment.Intelligence = firstEquipment.Intelligence + secondEquipment.Intelligence;
            newEquipment.Mana = firstEquipment.Mana + secondEquipment.Mana;
            newEquipment.Price = firstEquipment.Price + secondEquipment.Price;
            newEquipment.Stamina = firstEquipment.Stamina + secondEquipment.Stamina;
            newEquipment.Strength = firstEquipment.Strength + secondEquipment.Strength;

            return newEquipment;
        }

        void statCalculation(Equipment firstEquipment, Equipment secondEquipment)
        {
            firstEquipment.Health.Should().Be(secondEquipment.Health);
            firstEquipment.Dexterity.Should().Be(secondEquipment.Dexterity);
            firstEquipment.Intelligence.Should().Be(secondEquipment.Intelligence);
            firstEquipment.Mana.Should().Be(secondEquipment.Mana);
            firstEquipment.Price.Should().Be(secondEquipment.Price);
            firstEquipment.Stamina.Should().Be(secondEquipment.Stamina);
            firstEquipment.Strength.Should().Be(secondEquipment.Strength);
        }

        void fillNinjaList()
        {
            ninjaList = new List<Ninja>();

            Ninja ninja1 = new Ninja();
            ninja1.Name = "ninja1";
            ninja1.Helmet = equipmentList[2];
            ninja1.Chest = equipmentList[4];
            ninja1.Money = 200;
            ninjaList.Add(ninja1);

            Ninja ninja2 = new Ninja();
            ninja2.Name = "ninja2";
            ninja2.Money = 200;
            ninjaList.Add(ninja2);
        }

        void fillTypeList()
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

        void fillEquipmentList()
        {
            equipmentList = new List<Equipment>();

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
            equipmentList.Add(headGear1);
            equipmentList.Add(headGear2);
            equipmentList.Add(headGear3);
            equipmentList.Add(chestGear1);
            equipmentList.Add(chestGear2);
            equipmentList.Add(chestGear3);
            equipmentList.Add(legGear1);
            equipmentList.Add(legGear2);
            equipmentList.Add(legGear3);
            #endregion

        }
        
    }
}
