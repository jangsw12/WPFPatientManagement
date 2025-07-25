using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.ViewModels;

namespace WpfPatientManagement.Models
{
    // 환자 정보
    public class PATIENT : ViewModelBase
    {
        #region Fields
        private int _patientID;             // PK, Auto Increase
		private string _name;               // NOT NULL
		private DateTime _birthDate;        // NOT NULL
        private string _gender;             // NOT NULL, SQL에선 char(1)
        private string _phoneNumber;        // NOT NULL
		private string? _address;
		private string? _email;
        private bool _isAdmitted;           // NOT NULL, Default : false
        private string? _nurseNote;         // NULL

        #endregion

        #region Properties
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

		public string Name
		{
			get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

		public DateTime BirthDate
		{
			get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Gender
        {
            get { return _gender; }
            set { 
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
		{
			get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

		public string? Address
		{
			get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }

		public string? Email
		{
			get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsAdmitted
        {
            get { return _isAdmitted; }
            set
            {
                if (_isAdmitted != value)
                {
                    _isAdmitted = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? NurseNote
        {
            get { return _nurseNote; }
            set
            {
                if (_nurseNote != value)
                {
                    _nurseNote = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}