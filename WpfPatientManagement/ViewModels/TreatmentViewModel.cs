using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfPatientManagement.ViewModels
{
    public class TreatmentViewModel : ViewModelBase
    {
        public PatientListControlViewModel LeftVM { get; }
        public PatientRecordControlViewModel RightVM { get; }

        public TreatmentViewModel(PatientListControlViewModel leftVM, PatientRecordControlViewModel rightVM)
        {
            LeftVM = leftVM;
            RightVM = rightVM;

            LeftVM.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(PatientListControlViewModel.SelectedPatient))
                {
                    RightVM.SelectedPatientInfo = LeftVM.SelectedPatient;
                }
            };

            RightVM.OnPatientListFetched = patient =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LeftVM.SetPatient(patient);
                });
            };

        }
    }
}