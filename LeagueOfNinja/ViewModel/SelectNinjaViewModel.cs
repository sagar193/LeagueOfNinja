using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LeagueOfNinjaEF.DAL;
using LeagueOfNinjaEF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SelectNinjaViewModel : ViewModelBase, ISelectNinjaViewModel
    {
        private static ISelectNinjaViewModel instance;
        IUnitOfWork UOW;
        public RelayCommand<Window> okButton { get; set; }

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
                RaisePropertyChanged(selectedNinjaPropertyName);
            }
        }

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
        /// Initializes a new instance of the SelectNinjaViewModel class.
        /// </summary>
        public SelectNinjaViewModel(IUnitOfWork UOW)
        {
            this.UOW = UOW;
            instance = this;
            okButton = new RelayCommand<Window>(acceptNinja, canAcceptNinja);
            ninjaList = UOW.NinjaRepository.Get().ToList();
        }

        private bool canAcceptNinja(Window selectNinjaView)
        {
            if (_selectedNinja == null)
                return false;
            else
                return true;
        }

        private void acceptNinja(Window selectNinjaView)
        {
            if (_selectedNinja == null)
                return;
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            main.Show();
            MainViewModel.Instance.setNinja(selectedNinja.NinjaId);
            if (selectNinjaView != null)
                selectNinjaView.Close();
        }

        public static ISelectNinjaViewModel Instance
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


        public void refreshNinjaList()
        {
            ninjaList = UOW.NinjaRepository.Get().ToList();
        }
    }
}