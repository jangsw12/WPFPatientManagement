using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.ViewModels;

namespace WpfPatientManagement.Models
{
	// 사용자 정보(계정)
    public class USERS : ViewModelBase
    {
        #region Fields
        private string _userID;			// PK
		private string _password;		// NOT NULL
        private string _job;			// NOT NULL
        #endregion

        #region Properties
        public string UserID
		{
			get { return _userID; }
			set
			{ 
				if (_userID != value)
				{
					_userID = value;
					OnPropertyChanged();
				}
			}
		}

        public string Password
		{
			get { return _password; }
			set
			{
				if (_password != value)
				{
					_password = value;
					OnPropertyChanged();
				}
			}
		}
	
		public string Job
		{
			get { return _job; }
			set
			{ 
				if (_job != value)
				{
					_job = value;
					OnPropertyChanged();
				}
			}
		}
        #endregion
    }
}