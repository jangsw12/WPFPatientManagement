using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfPatientManagement.Models;
using WpfPatientManagement.Repositories;

namespace WpfPatientManagement.ViewModels
{
    public class PatientActionsControlViewModel : ViewModelBase
    {
        #region Fields
        public Action<List<PATIENT>> OnPatientListFetched;
        private readonly IPatientRepository _patientRepository;
        private PATIENT _selectedPatient;
        private string? _nurseNote;
        #endregion

        #region Properties
        public PATIENT SelectedPatient
        {
            get { return _selectedPatient; }
            set {
                _selectedPatient = value;
                OnPropertyChanged();
            }
        }

        public string? NurseNote
        {
            get { return _nurseNote; }
            set
            {
                _nurseNote = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand SelectCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AdmitPatientCommand { get; set; }
        #endregion

        #region Methods
        private async Task ExecuteSelectCommandAsync()
        {
            try
            {
                var result = await _patientRepository.SelectPatientAsync();
                OnPatientListFetched?.Invoke(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"조회 실패: {ex.Message}");
            }
        }

        private async Task ExecuteInsertCommandAsync()
        {
            try
            {
                if (SelectedPatient == null)
                {
                    MessageBox.Show("입력할 데이터를 선택하거나 입력해주세요.");
                    return;
                }

                var result = await _patientRepository.InsertPatientAsync(SelectedPatient);

                OnPatientListFetched?.Invoke(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"입력 실패: {ex.Message}");
            }
        }

        private async Task ExecuteUpdateCommandAsync()
        {
            try
            {
                if (SelectedPatient == null || SelectedPatient.PatientID == 0)
                {
                    MessageBox.Show("수정할 데이터를 선택해주세요.");
                    return;
                }

                var result = await _patientRepository.UpdatePatientAsync(SelectedPatient);

                OnPatientListFetched?.Invoke(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"갱신 실패: {ex.Message}");
            }
        }

        private async Task ExecuteDeleteCommandAsync()
        {
            try
            {
                if (SelectedPatient == null || SelectedPatient.PatientID == 0)
                {
                    MessageBox.Show("삭제할 데이터를 선택해주세요.");
                    return;
                }

                var confirm = MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButton.YesNo);
                if (confirm != MessageBoxResult.Yes)
                    return;

                var result = await _patientRepository.DeletePatientAsync(SelectedPatient.PatientID);

                OnPatientListFetched?.Invoke(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"삭제 실패: {ex.Message}");
            }
        }

        private async Task ExecuteAdmitPatientCommandAsync()
        {
            try
            {
                if (SelectedPatient == null)
                {
                    MessageBox.Show("환자를 선택해주세요.");
                    return;
                }

                if (SelectedPatient.IsAdmitted)
                {
                    MessageBox.Show("이미 접수된 환자입니다.");
                    return;
                }

                SelectedPatient.IsAdmitted = true;
                SelectedPatient.NurseNote = NurseNote;

                await _patientRepository.UpdatePatientAsync(SelectedPatient);

                NurseNote = String.Empty;

                var result = await _patientRepository.SelectPatientAsync();
                OnPatientListFetched?.Invoke(result);

                MessageBox.Show("접수 완료.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"입력 실패: {ex.Message}");
            }
        }
        #endregion

        public PatientActionsControlViewModel(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

            SelectCommand = new AsyncRelayCommand(ExecuteSelectCommandAsync);
            InsertCommand = new AsyncRelayCommand(ExecuteInsertCommandAsync);
            UpdateCommand = new AsyncRelayCommand(ExecuteUpdateCommandAsync);
            DeleteCommand = new AsyncRelayCommand(ExecuteDeleteCommandAsync);
            AdmitPatientCommand = new AsyncRelayCommand(ExecuteAdmitPatientCommandAsync);
        }
    }
}