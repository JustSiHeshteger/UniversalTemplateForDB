using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;

namespace UniversalTemplateForDB.Repositories
{
    internal class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string stringConnection)
        {
            this._connectionString = stringConnection;
        }

        public void Add(ProductModel productModel)
        {
            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Product
                                                VALUES (@nameProduct, @idMaster, @idCompany, @info)";
                        command.Parameters.Add("@nameProduct", SqlDbType.NVarChar).Value = productModel.NameProduct;
                        command.Parameters.Add("@idMaster", SqlDbType.Int).Value = productModel.IdMaster;
                        command.Parameters.Add("@idCompany", SqlDbType.Int).Value = productModel.IdCompany;
                        command.Parameters.Add("@info", SqlDbType.NVarChar).Value = productModel.Info;
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
                        command.CommandText = @"DELETE FROM Product WHERE IdProduct=@id";
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

        public void Edit(ProductModel productModel)
        {
            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE Product
                                                SET NameProduct=@nameProduct, IdMaster=@idMaster, IdCompany=@idCompany, Info=@info
                                                WHERE IdProduct=@id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = productModel.Id;
                        command.Parameters.Add("@nameProduct", SqlDbType.NVarChar).Value = productModel.NameProduct;
                        command.Parameters.Add("@idMaster", SqlDbType.Int).Value = productModel.IdMaster;
                        command.Parameters.Add("@idCompany", SqlDbType.Int).Value = productModel.IdCompany;
                        command.Parameters.Add("@info", SqlDbType.NVarChar).Value = productModel.Info;
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
                        command.CommandText = "SELECT * FROM Product ORDER BY IdProduct DESC";

                        sqlDataAdapter.SelectCommand = command;
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return dataTable;
        }

        public DataTable GetByValue(string value)
        {
            int idProduct = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string nameProduct = value;

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
                        command.CommandText = @"SELECT * FROM Product " +
                                              @"WHERE IdProduct=@idProduct OR NameProduct=@nameProduct " +
                                              @"ORDER BY IdProduct DESC";
                        command.Parameters.Add("@idProduct", SqlDbType.Int).Value = idProduct;
                        command.Parameters.Add("@nameProduct", SqlDbType.NVarChar).Value = nameProduct;

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
                        command.CommandText = $"ALTER TABLE Product ADD {column} NVARCHAR(50) NULL";
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
                        command.CommandText = $"ALTER TABLE Product DROP COLUMN {column};";
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
