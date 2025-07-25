using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.Controls;
using WpfPatientManagement.Stores;
using WpfPatientManagement.ViewModels;

namespace WpfPatientManagement.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainNavigationStore _mainNavigationStore;
        public INotifyPropertyChanged? CurrentViewModel
        {
            set => _mainNavigationStore.CurrentViewModel = value;
        }

        public NavigationService(MainNavigationStore mainNavigationStore)
        {
            _mainNavigationStore = mainNavigationStore;
        }

        public void Navigate(NaviType naviType)
        {
            switch (naviType)
            {
                case NaviType.LoginControl:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(LoginControlViewModel));
                    break;
                case NaviType.SignupControl:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(SignupControlViewModel));
                    break;
                case NaviType.FrontView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(FrontViewModel));
                    break;
                case NaviType.TreatmentView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(TreatmentViewModel));
                    break;
                case NaviType.PatientListControl:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(PatientListControlViewModel));
                    break;
                case NaviType.PatientActionsControl:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(PatientActionsControlViewModel));
                    break;
                case NaviType.PatientRecordControl:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetRequiredService(typeof(PatientRecordControlViewModel));
                    break;

                default:
                    return;
            }
        }
    }
}