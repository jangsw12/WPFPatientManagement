using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.ViewModels;

namespace WpfPatientManagement.Models
{
    // 진료 기록
    public class RECORD : ViewModelBase
    {
        #region Fields
        private int _recordID;                 // PK, Auto Increase
        private int _patientID;                // FK(PATIENT Table), NOT NULL
        private string _doctorID;              // FK(USERS Table), NOT NULL
        private string? _consultation;          
		private DateTime _consultationDate;    // NOT NULL
        #endregion

        #region Properties
        public int RecordID
		{
			get { return _recordID; }
            set
            {
                if (_recordID != value)
                {
                    _recordID = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PatientID
        {
            get { return _patientID; }
            set
            {
                if (_patientID != value)
                {
                    _patientID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DoctorID
        {
            get { return _doctorID; }
            set
            {
                if (_doctorID != value)
                {
                    _doctorID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Consultation
		{
			get { return _consultation; }
            set
            {
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
            set
            {
                if (_consultationDate != value)
                {
                    _consultationDate = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}