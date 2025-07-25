using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfPatientManagement.Repositories;
using WpfPatientManagement.Services;

namespace WpfPatientManagement.ViewModels
{
    public class LoginControlViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;
        private Visibility _idVisible = Visibility.Collapsed;
        private Visibility _passwordVisible = Visibility.Collapsed;
        private string _userID;
        private string _password;
        private string _idError;
        private string _passwordError;
        #endregion

        #region Properties
        public Visibility IdVisible
        {
            get { return _idVisible; }
            set { 
                _idVisible = value;
                OnPropertyChanged();
            }
        }

        public Visibility PasswordVisible
        {
            get { return _passwordVisible; }
            set
            {
                _passwordVisible = value;
                OnPropertyChanged();
            }
        }

        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string IdError
        {
            get { return _idError; }
            set
            {
                _idError = value;
                OnPropertyChanged();
            }
        }

        public string PasswordError
        {
            get { return _passwordError; }
            set
            {
                _passwordError = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ToLoginCommand { get; set; }
        public ICommand ToSignupCommand { get; set; }
        #endregion

        #region Methods
        private async Task ToLoginAsync()
        {
            IdError = null;
            PasswordError = null;
            IdVisible = Visibility.Collapsed;
            PasswordVisible = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(UserID) || string.IsNullOrWhiteSpace(Password))
            {
                if (string.IsNullOrWhiteSpace(UserID))
                {
                    IdError = "아이디를 입력해주세요.";
                    IdVisible = Visibility.Visible;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    PasswordError = "비밀번호를 입력해주세요.";
                    PasswordVisible = Visibility.Visible;
                }
                return;
            }

            var user = await _userRepository.GetUserByIdAsync(UserID ?? "");

            if (user == null)
            {
                IdError = "존재하지 않는 아이디입니다.";
                IdVisible = Visibility.Visible;
                return;
            }

            if (user.Password != Password)
            {
                PasswordError = "입력하신 비밀번호가 맞지 않습니다.";
                PasswordVisible = Visibility.Visible;
                return;
            }

            // 로그인한 사용자 정보 앱에 저장
            Application.Current.Properties["LoggedInUser"] = user;

            switch (user.Job)
            {
                case "간호사":
                    _navigationService.Navigate(NaviType.FrontView);
                    break;
                case "의사":
                    _navigationService.Navigate(NaviType.TreatmentView);
                    break;
                default:
                    return;
            }
        }

        private void ToSignup(object _)
        {
            _navigationService.Navigate(NaviType.SignupControl);
        }
        #endregion

        public LoginControlViewModel(INavigationService navigationService, IUserRepository userRepository)
        {
            _navigationService = navigationService;
            _userRepository = userRepository;

            ToLoginCommand = new AsyncRelayCommand(ToLoginAsync);
            ToSignupCommand = new RelayCommand<object>(ToSignup);
        }
    }
}