using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.Models;

namespace WpfPatientManagement.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        #region Query
        private const string selectQuery = @"SELECT * FROM RECORD 
                                             WHERE PatientID = @PatientID
                                             ORDER BY ConsultationDate DESC";

        private const string insertQuery = @"INSERT INTO RECORD(PatientID, DoctorID, Consultation, ConsultationDate)
                                             VALUES(@PatientID, @DoctorID, @Consultation, @ConsultationDate);";
        #endregion

        private readonly string _connectionString;

        public RecordRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Methods
        public async Task<List<RECORD>> InsertRecordAsync(RECORD record)
        {
            var recordList = new List<RECORD>();
            var ds = new DataSet();

            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();

            using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
            {
                insertCommand.Parameters.AddWithValue("@PatientID", record.PatientID);
                insertCommand.Parameters.AddWithValue("@DoctorID", record.DoctorID);
                insertCommand.Parameters.AddWithValue("@Consultation", (object)record.Consultation ?? DBNull.Value);
                insertCommand.Parameters.AddWithValue("@ConsultationDate", record.ConsultationDate);
              
                await insertCommand.ExecuteNonQueryAsync();
            }

            using (SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection))
            {
                selectCommand.Parameters.AddWithValue("@PatientID", record.PatientID);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                sqlDataAdapter.Fill(ds);
            }

            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    recordList.Add(new RECORD
                    {
                        PatientID = Convert.ToInt32(row["PatientID"]),
                        DoctorID = row["DoctorID"].ToString(),
                        Consultation = row["Consultation"].ToString(),
                        ConsultationDate = Convert.ToDateTime(row["ConsultationDate"]),
                    });
                }
            }

            return recordList;
        }

        public async Task<List<RECORD>> SelectRecordAsync(int patientID)
        {
            var recordList = new List<RECORD>();
            var ds = new DataSet();

            await Task.Run(() =>
            {
                using SqlConnection sqlConnection = new SqlConnection(_connectionString);
                using SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PatientID", patientID);
                
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
            });

            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    recordList.Add(new RECORD
                    {
                        RecordID = Convert.ToInt32(row["RecordID"]),
                        PatientID = Convert.ToInt32(row["PatientID"]),
                        DoctorID = row["DoctorID"].ToString(),
                        Consultation = row["Consultation"].ToString(),
                        ConsultationDate = Convert.ToDateTime(row["ConsultationDate"]),
                    });
                }
            }

            return recordList;
        }
        #endregion
    }
}