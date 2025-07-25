using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfPatientManagement.Models;
using WpfPatientManagement.Repositories;

namespace WpfPatientManagement.ViewModels
{
    public class PatientRecordControlViewModel : ViewModelBase
    {
        #region Fields
        public Action<List<PATIENT>> OnPatientListFetched;
        private readonly IRecordRepository _recordRepository;
        private readonly IPatientRepository _patientRepository;
        private PATIENT _selectedPatientInfo;
        private string _consultation;
        private DateTime _consultationDate;
		private ObservableCollection<RECORD> _patientRecordList;
        private string _nurseNote;
        #endregion

        #region Properties
        public PATIENT SelectedPatientInfo
        {
            get { return _selectedPatientInfo; }
            set { 
                _selectedPatientInfo = value;
                OnPropertyChanged();
                NurseNote = _selectedPatientInfo?.NurseNote;
            }
        }

        public string Consultation
        {
			get { return _consultation; }
			set {
				if (_consultation != value)
				{
                    _consultation = value;
                    OnPropertyChanged();
                }
			}
		}

		public DateTime ConsultationDate
		{
			get { return _consultationDate; }
			set { 
				if (_consultationDate != value)
				{
                    _consultationDate = value;
                    OnPropertyChanged();
                }
            }
		}

        public ObservableCollection<RECORD> PatientRecordList
        {
            get { return _patientRecordList; }
            set
            {
                _patientRecordList = value;
                OnPropertyChanged();
            }
        }

        public string NurseNote
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
        public ICommand SelectRecordCommand { get; set; }
        public ICommand CompleteConsultationCommand { get; set; }
        #endregion

        #region Methods
        private async Task ExecuteSelectRecordCommandAsync()
		{
            if (SelectedPatientInfo == null)
            {
                MessageBox.Show("환자를 선택해주세요.");
                return;
            }

            var result = await _recordRepository.SelectRecordAsync(SelectedPatientInfo.PatientID);
            PatientRecordList = new ObservableCollection<RECORD>(result);
        }

        private async Task CompleteConsultation()
		{
            if (SelectedPatientInfo == null)
            {
                MessageBox.Show("환자를 선택해주세요.");
                return;
            }

            if (SelectedPatientInfo.IsAdmitted == false)
            {
                MessageBox.Show("접수되지 않은 환자입니다.");
                return;
            }

            try
            {
                // 0. 로그인한 사용자 ID 가져오기
                var loggedInUser = Application.Current.Properties["LoggedInUser"] as USERS;
                var doctorID = loggedInUser?.UserID ?? "unknown";

                // 1. 진료 기록 저장
                var record = new RECORD
                {
                    PatientID = SelectedPatientInfo.PatientID,
                    DoctorID = doctorID,
                    Consultation = Consultation,
                    ConsultationDate = DateTime.Now,
                };
                var updated = await _recordRepository.InsertRecordAsync(record);
                PatientRecordList = new ObservableCollection<RECORD>(updated);

                // 2. 상태 업데이트
                SelectedPatientInfo.IsAdmitted = false;
                SelectedPatientInfo.NurseNote = null;

                // 3. PATIENT 테이블 업데이트
                await _patientRepository.UpdatePatientAsync(SelectedPatientInfo);

                // 4. 뷰에 바로 반영되도록 리스트 갱신
                var result = await _patientRepository.SelectPatientAsync();
                OnPatientListFetched?.Invoke(result);

                // 5. 필드 초기화
                Consultation = String.Empty;
                NurseNote = null;

                MessageBox.Show("진료 완료.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"진료 입력 실패: {ex.Message}");
            }
        }
        #endregion

        public PatientRecordControlViewModel(IRecordRepository recordRepository, IPatientRepository patientRepository)
        {
            _recordRepository = recordRepository;
            _patientRepository = patientRepository;

            SelectRecordCommand = new AsyncRelayCommand(ExecuteSelectRecordCommandAsync);
            CompleteConsultationCommand = new AsyncRelayCommand(CompleteConsultation);
        }
    }
}