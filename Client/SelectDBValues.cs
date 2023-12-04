using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class SelectDBValues
    {
        public static async Task SQLDataBaseSelect(DataTable data)
        {
            string sqlException = $"SELECT * FROM Orders";
            DBConnect dBConnect = new DBConnect();
            try
            {
                using (SqlCommand command = new SqlCommand(sqlException, await dBConnect.SQLDataBaseConnect()))
                {
                    using(SqlDataAdapter sql = new SqlDataAdapter(command))
                    {
                        sql.Fill(data);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Select db values ERROR {ex.Message}");
            }
        }
    }
}
