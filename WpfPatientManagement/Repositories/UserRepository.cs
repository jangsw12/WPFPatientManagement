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
    public class UserRepository : IUserRepository
    {
        #region Query
        private const string selectQuery = @"SELECT * FROM USERS";
        #endregion

        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Methods
        public async Task<List<USERS>> SelectUserAsync()
        {
            var userList = new List<USERS>();
            var ds = new DataSet();

            await Task.Run(() =>
            {
                using SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, sqlConnection);
                sqlDataAdapter.Fill(ds);
            });

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    userList.Add(new USERS
                    {
                        UserID = row["UserID"].ToString(),
                        Password = row["Password"].ToString(),
                        Job = row["Job"].ToString()
                    });
                }
            }

            return userList;
        }

        public async Task<USERS?> GetUserByCredentialAsync(string id, string password)
        {
            var users = await SelectUserAsync();
            return users.FirstOrDefault(u => string.Equals(u.UserID, id, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }

        public async Task<USERS?> GetUserByIdAsync(string id)
        {
            var users = await SelectUserAsync();
            return users.FirstOrDefault(u => string.Equals(u.UserID, id, StringComparison.OrdinalIgnoreCase));
        }
        #endregion
    }
}