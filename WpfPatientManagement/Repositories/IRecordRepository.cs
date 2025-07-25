using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.Models;

namespace WpfPatientManagement.Repositories
{
    public interface IRecordRepository
    {
        Task<List<RECORD>> SelectRecordAsync(int patientID);
        Task<List<RECORD>> InsertRecordAsync(RECORD record);
    }
}