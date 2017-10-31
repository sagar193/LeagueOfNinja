using GalaSoft.MvvmLight.CommandWpf;
using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeagueOfNinja.ViewModel
{
    public interface ISelectNinjaViewModel
    {
        Ninja selectedNinja { get; set; }
        RelayCommand<Window> okButton { get; set; }

        void refreshNinjaList();
    }
}
