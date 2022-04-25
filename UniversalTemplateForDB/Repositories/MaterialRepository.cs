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

        public IEnumerable<MaterialModel> GetAll()
        {
            var materialList = new List<MaterialModel>();

            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Material ORDER BY IdMaterial DESC";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var materialModel = new MaterialModel
                                {
                                    IdMaterial = (int)reader[0],
                                    IdProduct = (int)reader[1],
                                    NameMaterial = reader[2].ToString(),
                                    Price = (int)reader[3]
                                };

                                materialList.Add(materialModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return materialList;
        }

        public IEnumerable<MaterialModel> GetByValue(string value)
        {
            var materialList = new List<MaterialModel>();
            int idMaterial = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string nameMaterial = value;

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

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var materialModel = new MaterialModel()
                                {
                                    IdMaterial = (int)reader[0],
                                    IdProduct = (int)reader[1],
                                    NameMaterial = reader[2].ToString(),
                                    Price = (int)reader[3],
                                };
                                materialList.Add(materialModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return materialList;
        }
    }
}
