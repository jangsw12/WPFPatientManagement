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
    public class PatientRepository : IPatientRepository
    {
        #region Query
        private const string selectQuery = @"SELECT * FROM PATIENT ORDER BY IsAdmitted DESC, Name ASC";

        private const string insertQuery = @"INSERT INTO PATIENT(Name, BirthDate, Gender, PhoneNumber, Address, Email, NurseNote)
                                             VALUES(@Name, @BirthDate, @Gender, @PhoneNumber, @Address, @Email, @NurseNote);
                                             SELECT * FROM PATIENT ORDER BY IsAdmitted DESC, Name ASC";

        private const string updateQuery = @"UPDATE PATIENT
                                             SET Name=@Name, BirthDate=@BirthDate, Gender=@Gender, PhoneNumber=@PhoneNumber, Address=@Address, Email=@Email, IsAdmitted=@IsAdmitted, NurseNote=@NurseNote
                                             WHERE PatientID=@PatientID;
                                             SELECT * FROM PATIENT ORDER BY IsAdmitted DESC, Name ASC";

        private const string deleteQuery = @"DELETE FROM PATIENT WHERE PatientID = @PatientID;
                                             SELECT * FROM PATIENT ORDER BY IsAdmitted DESC, Name ASC;";
        #endregion

        private readonly string _connectionString;

        public PatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Methods
        public async Task<List<PATIENT>> DeletePatientAsync(int patientID)
        {
            var patientList = new List<PATIENT>();
            var ds = new DataSet();

            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();

            using SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("PatientID", patientID);
            await sqlCommand.ExecuteNonQueryAsync();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, sqlConnection);
            sqlDataAdapter.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    patientList.Add(new PATIENT
                    {
                        PatientID = Convert.ToInt32(row["PatientID"]),
                        Name = row["Name"].ToString(),
                        BirthDate = Convert.ToDateTime(row["BirthDate"]),
                        Gender = row["Gender"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Address = row["Address"].ToString(),
                        Email = row["Email"].ToString(),
                        IsAdmitted = Convert.ToBoolean(row["IsAdmitted"]),
                    });
                }
            }

            return patientList;
        }

        public async Task<List<PATIENT>> InsertPatientAsync(PATIENT patient)
        {
            var patientList = new List<PATIENT>();
            var ds = new DataSet();

            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
         
            using SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Name", patient.Name);
            sqlCommand.Parameters.AddWithValue("@BirthDate", patient.BirthDate);
            sqlCommand.Parameters.AddWithValue("@Gender", patient.Gender);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@Address", (object)patient.Address ?? DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Email", (object)patient.Email ?? DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsAdmitted", patient.IsAdmitted);
            sqlCommand.Parameters.AddWithValue("@NurseNote", (object)patient.NurseNote ?? DBNull.Value);

            await sqlCommand.ExecuteNonQueryAsync();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, sqlConnection);
            sqlDataAdapter.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    patientList.Add(new PATIENT
                    {
                        PatientID = Convert.ToInt32(row["PatientID"]),
                        Name = row["Name"].ToString(),
                        BirthDate = Convert.ToDateTime(row["BirthDate"]),
                        Gender = row["Gender"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Address = row["Address"].ToString(),
                        Email = row["Email"].ToString(),
                        IsAdmitted = Convert.ToBoolean(row["IsAdmitted"]),
                        NurseNote = row["NurseNote"].ToString(),
                    });
                }
            }

            return patientList;
        }

        public async Task<List<PATIENT>> SelectPatientAsync()
        {
            var patientList = new List<PATIENT>();
            var ds = new DataSet();

            await Task.Run(() =>
            {
                using SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, sqlConnection);
                sqlDataAdapter.Fill(ds);
            });

            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    patientList.Add(new PATIENT
                    {
                        PatientID = Convert.ToInt32(row["PatientID"]),
                        Name = row["Name"].ToString(),
                        BirthDate = Convert.ToDateTime(row["BirthDate"]),
                        Gender = row["Gender"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Address = row["Address"].ToString(),
                        Email = row["Email"].ToString(),
                        IsAdmitted = Convert.ToBoolean(row["IsAdmitted"]),
                        NurseNote = row["NurseNote"].ToString(),
                    });
                }
            }

            return patientList;
        }

        public async Task<List<PATIENT>> UpdatePatientAsync(PATIENT patient)
        {
            var patientList = new List<PATIENT>();
            var ds = new DataSet();

            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();


            using SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PatientID", patient.PatientID);
            sqlCommand.Parameters.AddWithValue("@Name", patient.Name);
            sqlCommand.Parameters.AddWithValue("@BirthDate", patient.BirthDate);
            sqlCommand.Parameters.AddWithValue("@Gender", patient.Gender);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@Address", (object)patient.Address ?? DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Email", (object)patient.Email ?? DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsAdmitted", patient.IsAdmitted);
            sqlCommand.Parameters.AddWithValue("@NurseNote", (object)patient.NurseNote ?? DBNull.Value);

            await sqlCommand.ExecuteNonQueryAsync();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, sqlConnection);
            sqlDataAdapter.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    patientList.Add(new PATIENT
                    {
                        PatientID = Convert.ToInt32(row["PatientID"]),
                        Name = row["Name"].ToString(),
                        BirthDate = Convert.ToDateTime(row["BirthDate"]),
                        Gender = row["Gender"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Address = row["Address"].ToString(),
                        Email = row["Email"].ToString(),
                        IsAdmitted = Convert.ToBoolean(row["IsAdmitted"]),
                        NurseNote = row["NurseNote"].ToString(),
                    });
                }
            }

            return patientList;
        }
        #endregion
    }
}