/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LeagueOfNinja"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<IMainViewModel,MainViewModel>();
            SimpleIoc.Default.Register<ICrudEquipmentViewModel, CrudEquipmentViewModel>();
            SimpleIoc.Default.Register<ISelectNinjaViewModel, SelectNinjaViewModel>();
        }

        public IMainViewModel Main
        {
            get
            {
                /*Correct way of returning:
                 * return ServiceLocator.Current.GetInstance<IMainViewModel>();
                 * this however does not return work with dependency injection so we are returning a static mainviewcontroller with the right UnitOfWork
                 */

                if (MainViewModel.Instance == null)
                {
                    new MainViewModel(new LeagueOfNinjaEF.DAL.UnitOfWork());
                }

                return MainViewModel.Instance;
            }
        }

        public ICrudEquipmentViewModel CrudEquipmentVM
        {
            get
            {
                if (CrudEquipmentViewModel.Instance == null)
                    new CrudEquipmentViewModel(new LeagueOfNinjaEF.DAL.UnitOfWork());

                return CrudEquipmentViewModel.Instance;
            }
        }

        public ISelectNinjaViewModel SelectNinjaVM
        {
            get
            {
                if (SelectNinjaViewModel.Instance == null)
                    new SelectNinjaViewModel(new LeagueOfNinjaEF.DAL.UnitOfWork());

                return SelectNinjaViewModel.Instance;
            }
        }


        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}