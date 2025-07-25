using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfPatientManagement.Commands;
using WpfPatientManagement.Models;
using WpfPatientManagement.Repositories;

namespace WpfPatientManagement.ViewModels
{
    public class PatientListControlViewModel : ViewModelBase
    {
        #region Fields
        private readonly IPatientRepository _patientRepository;
		private string _searchText;
		private ICollectionView _filteredPatientList;
		private ObservableCollection<PATIENT> _patientList = new();
		private PATIENT _selectedPatient;
        #endregion

        #region Properties
        public string SearchText
		{
			get { return _searchText; }
			set { 
				_searchText = value;
				OnPropertyChanged();
				ApplyFilter();
			}
		}

		public ICollectionView FilteredPatientList
        {
			get { return _filteredPatientList; }
			set { 
				_filteredPatientList = value;
				OnPropertyChanged();
			}
		}

        public ObservableCollection<PATIENT> PatientList
        {
			get { return _patientList; }
			set { 
				_patientList = value;
				OnPropertyChanged();
				ApplyFilter();
			}
		}

		public PATIENT SelectedPatient
		{
			get { return _selectedPatient; }
			set { 
				_selectedPatient = value;
				OnPropertyChanged();
			}
		}
        #endregion

        #region Commands
        public ICommand SearchCommand { get; set; }
        #endregion

        #region Methods
        public void SetPatient(List<PATIENT> patientList)
		{
			PatientList.Clear();
			foreach (var patient in patientList)
				PatientList.Add(patient);

			ApplyFilter();
		}

		private bool FilterPatient(object obj)
		{
			if (obj is PATIENT item)
			{
				if (string.IsNullOrWhiteSpace(SearchText))
					return true;

				return (item.Name?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			return false;
		}

		private void ApplyFilter()
		{
			_filteredPatientList.Refresh();
		}

		private async void LoadDataAsync()
		{
			var data = await _patientRepository.SelectPatientAsync();
			SetPatient(data);
		}
		#endregion

        public PatientListControlViewModel(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

			_filteredPatientList = CollectionViewSource.GetDefaultView(_patientList);
			_filteredPatientList.Filter = FilterPatient;

			SearchCommand = new RelayCommand<object>(_ => ApplyFilter());

			LoadDataAsync();
        }
    }
}