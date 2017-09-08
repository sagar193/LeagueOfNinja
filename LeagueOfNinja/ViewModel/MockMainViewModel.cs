using LeagueOfNinjaEF.Models;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MockMainViewModel : ViewModelBase, IMainViewModel
    {
        ///All Parameters

        /// <summary>
        /// The <see cref="typeList" /> property's name.
        /// </summary>
        public const string typeListPropertyName = "typeList";

        private List<Type> _typeList = new List<Type>();

        /// <summary>
        /// Sets and gets the typeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<Type> typeList
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
        /// Initializes a new instance of the MockMainViewModel class.
        /// </summary>
        public MockMainViewModel()
        {
            fillTypeList();
            fillEquipmentList();
            
        }

        void fillTypeList()
        {
            typeList = new List<Type>();

            Type typeHoofd = new Type();
            Type typeChest = new Type();
            Type typeLegs = new Type();

            typeHoofd.Name = "Hoofd";
            typeChest.Name = "Chest";
            typeLegs.Name = "Legs";
            typeList.Add(typeHoofd);
            typeList.Add(typeChest);
            typeList.Add(typeLegs);
        }

        void fillEquipmentList()
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
            headGear2.Type = typeList[0];
            headGear2.Name = "Hide helmet";
            headGear3.Type = typeList[0];
            headGear3.Name = "Leather helmet";

            chestGear1.Type = typeList[1];
            chestGear1.Name = "Bronze chest";
            chestGear2.Type = typeList[1];
            chestGear2.Name = "Hide chest";
            chestGear3.Type = typeList[1];
            chestGear3.Name = "Leather chest";

            legGear1.Type = typeList[2];
            legGear1.Name = "Bronze legs";
            legGear2.Type = typeList[2];
            legGear2.Name = "Hide legs";
            legGear3.Type = typeList[2];
            legGear3.Name = "Leather legs";
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
            #endregion

        }
    }
}