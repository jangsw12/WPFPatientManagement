using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPatientManagement.ViewModels
{
    public class FrontViewModel : ViewModelBase
    {
        public PatientListControlViewModel LeftVM { get; }
        public PatientActionsControlViewModel RightVM { get; }

        public FrontViewModel(PatientListControlViewModel leftVM, PatientActionsControlViewModel rightVM)
        {
            LeftVM = leftVM;
            RightVM = rightVM;

            RightVM.OnPatientListFetched = patient =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LeftVM.SetPatient(patient);
                });
            };

            LeftVM.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(PatientListControlViewModel.SelectedPatient))
                {
                    RightVM.SelectedPatient = LeftVM.SelectedPatient;
                }
            };
        }
    }
}