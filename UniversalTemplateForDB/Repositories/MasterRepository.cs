using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;

namespace UniversalTemplateForDB.Repositories
{
    internal class MasterRepository : BaseRepository, IMasterRepository
    {
        public MasterRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Add(MasterModel masterModel)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Master VALUES (@name, @secondName, @experience)";
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = masterModel.Name;
                        command.Parameters.Add("@secondName", SqlDbType.NVarChar).Value = masterModel.SecondName;
                        command.Parameters.Add("@experience", SqlDbType.Int).Value = masterModel.Experience;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Master WHERE IdMaster=@id";
                        command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void Edit(MasterModel masterModel)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE Master 
                                                SET Name=@name, SecondName=@secondName, Experience=@exp
                                                WHERE IdMaster=@id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = masterModel.Id;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = masterModel.Name;
                        command.Parameters.Add("@secondName", SqlDbType.NVarChar).Value = masterModel.SecondName;
                        command.Parameters.Add("@exp", SqlDbType.Int).Value = masterModel.Experience;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Master ORDER BY IdMaster DESC";

                        sqlDataAdapter.SelectCommand = command;
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return dataTable;
        }

        public DataTable GetByValue(string value)
        {
            int idMaster = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string name = value;
            string secondName = value;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Master " +
                                              @"WHERE IdMaster=@idMaster OR Name=@name+'%' OR SecondName=@secondName+'%' " +
                                              @"ORDER BY IdMaster DESC";
                        command.Parameters.Add("@idMaster", SqlDbType.Int).Value = idMaster;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.Add("@secondName", SqlDbType.NVarChar).Value = secondName;

                        sqlDataAdapter.SelectCommand = command;
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return dataTable;
        }

        public void AddColumn(string column)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = $"ALTER TABLE Master ADD {column} NVARCHAR(50) NULL";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void DropColumn(string column)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = $"ALTER TABLE Master DROP COLUMN {column};";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
