using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.Models;

namespace WpfPatientManagement.Repositories
{
    public interface IPatientRepository
    {
        Task<List<PATIENT>> SelectPatientAsync();
        Task<List<PATIENT>> InsertPatientAsync(PATIENT patient);
        Task<List<PATIENT>> UpdatePatientAsync(PATIENT patient);
        Task<List<PATIENT>> DeletePatientAsync(int patientID);
    }
}