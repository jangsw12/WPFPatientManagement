﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPatientManagement.Stores
{
    public class MainNavigationStore
    {
		private INotifyPropertyChanged? _currentViewModel;

		public INotifyPropertyChanged? CurrentViewModel
		{
			get { return _currentViewModel; }
			set {
				_currentViewModel = value;
				CurrentViewModelChanged?.Invoke();
				_currentViewModel = null;
			}
		}

        public Action? CurrentViewModelChanged { get; set; }
    }
}