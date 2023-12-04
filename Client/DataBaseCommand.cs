using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Client
{
    class DataBaseCommand
    {
        #region Properity
        ColumnValue[] Columns;
        public string SQLExpressionInsert { 
            get
            {
                return CreateSQLInsert();
            } 
        }
        public string SQLExpressionUpdate
        {
            get
            {
                return CreateSQLUpdate();
            }
        }
        public string SQLExpressionDelete
        {
            get
            {
                return CreateSQLDelete();
            }
        }
        #endregion Properity
        #region Construct
        public DataBaseCommand(ColumnValue[] columns)
        {
            Columns = columns;
        }
        public DataBaseCommand(string sqlExpression)
        {
            DataBaseSQLExpressionConnect(sqlExpression);
        }
        public void DataBaseSQLExpressionConnect(string sqlExpression) => SQLDataBaseWork(sqlExpression);
        #endregion Construct
        #region Methods
        private string CreateSQLInsert()
        {
            string sqlExpressionColumnNames = null;
            object sqlExpressionColumnValue = null;

            for(int i = 0; i < Columns.Length; i++)
            {
                if (Columns[i].Value ==)
                if (i == 0) 
                { 
                    sqlExpressionColumnNames = $"{Columns[i].Name}";
                    sqlExpressionColumnValue = Columns[i].Value.GetType().Name == "String" ? $"'{Columns[i].Value}'" : $"{Columns[i].Value}";
                    i++;
                }
                sqlExpressionColumnValue += Columns[i].Value.GetType().Name == "String" ? $", '{Columns[i].Value}'" : $", {Columns[i].Value}";
                sqlExpressionColumnNames += $", {Columns[i].Name}";
            }
            string sqlException = $"INSERT INTO Orders ({sqlExpressionColumnNames}) VALUES ({sqlExpressionColumnValue})";

            return sqlException;
        }
        private string CreateSQLUpdate()
        {
            string sqlExpressionColumnWhere = null;
            object sqlExpressionColumnValue = null;

            for (int i = 0; i < Columns.Length; i++)
            {
                if (i == 0)
                {
                    sqlExpressionColumnWhere = Columns[i].Value.GetType().Name == "string" ? $"{Columns[i].Name}={Columns[i].Value}" : $"{Columns[i].Name}='{Columns[i].Value}'";
                    sqlExpressionColumnValue = Columns[i].Value.GetType().Name == "string" ? $"{Columns[i].Name}={Columns[i].Value}" : $"{Columns[i].Name}='{Columns[i].Value}'";
                }
                sqlExpressionColumnValue += Columns[i].Value.GetType().Name == "string" ? $", {Columns[i].Name}={Columns[i].Value}" : $", {Columns[i].Name}='{Columns[i].Value}'";
            }
            string sqlExpression = $"UPDATE Users SET {sqlExpressionColumnValue} WHERE {sqlExpressionColumnWhere}";

            return sqlExpression;
        }
        private string CreateSQLDelete()
        {
            string sqlExpressionColumnWhere = Columns[0].Value.GetType().Name == "string" ? $"{Columns[0].Name}={Columns[0].Value}" : $"{Columns[0].Name}='{Columns[0].Value}'";
            return sqlExpressionColumnWhere;
        }
        private async void SQLDataBaseWork(string sqlException)
        {
            DBConnect dBConnect = new DBConnect();
            try
            {
                using (SqlCommand command = new SqlCommand(sqlException, await dBConnect.SQLDataBaseConnect()))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Select db values ERROR {ex.Message}");
            }
        }
        #endregion Methods
    }
}

