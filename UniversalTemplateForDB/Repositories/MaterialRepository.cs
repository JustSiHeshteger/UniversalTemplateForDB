using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;

namespace UniversalTemplateForDB.Repositories
{
    internal class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Add(MaterialModel materialModel)
        {
            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Material
                                                VALUES (@idProduct, @nameMaterial, @price)";
                        command.Parameters.Add("@idProduct", SqlDbType.Int).Value = materialModel.IdProduct;
                        command.Parameters.Add("@nameMaterial", SqlDbType.NVarChar).Value = materialModel.NameMaterial;
                        command.Parameters.Add("@price", SqlDbType.Int).Value = materialModel.Price;
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
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM Material WHERE IdMaterial=@id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void Edit(MaterialModel materialModel)
        {
            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE Material
                                                SET IdProduct=@idProduct, NameMaterial=@nameMaterial, Price=@price
                                                WHERE IdMaterial=@id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = materialModel.IdMaterial;
                        command.Parameters.Add("@idProduct", SqlDbType.Int).Value = materialModel.IdProduct;
                        command.Parameters.Add("@nameMaterial", SqlDbType.NVarChar).Value = materialModel.NameMaterial;
                        command.Parameters.Add("@price", SqlDbType.Int).Value = materialModel.Price;
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
                        command.CommandText = "SELECT * FROM Material ORDER BY IdMaterial DESC";

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
            int idMaterial = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string nameMaterial = value;

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
                        command.CommandText = @"SELECT * FROM Material
                                                WHERE IdMaterial=@idMaterial OR NameMaterial=@nameMaterial
                                                ORDER BY IdMaterial DESC";
                        command.Parameters.Add("@idMaterial", SqlDbType.Int).Value = idMaterial;
                        command.Parameters.Add("@nameMaterial", SqlDbType.NVarChar).Value = nameMaterial;

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
                        command.CommandText = $"ALTER TABLE Material ADD {column} NVARCHAR(50) NULL";
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
                        command.CommandText = $"ALTER TABLE Material DROP COLUMN {column};";
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
