using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class DBConnect
    {
        static string connectionString = "Server=HOME-PC\\TIPOGRAFIKA;Database=Order;Trusted_Connection=True;";
        public async Task<SqlConnection> SQLDataBaseConnect()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return connection;
        }
    }
}
