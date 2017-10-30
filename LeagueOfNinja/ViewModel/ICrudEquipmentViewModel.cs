using GalaSoft.MvvmLight.CommandWpf;
using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel
{
    public interface ICrudEquipmentViewModel
    {
        List<Equipment> equipmentList { get; set; }
        List<LeagueOfNinjaEF.Models.Type> typeList { get; set; }

        RelayCommand saveButton { get; set; }
        RelayCommand clearButton { get; set; }
        RelayCommand deleteButton { get; set; }
    }
}
