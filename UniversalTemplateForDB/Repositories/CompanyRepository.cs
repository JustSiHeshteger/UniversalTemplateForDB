using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;

namespace UniversalTemplateForDB.Repositories
{
    internal class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #region Методы

        public void Add(CompanyModel companyModel)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Company VALUES (@name, @address, @phone)";
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = companyModel.NameCompany;
                        command.Parameters.Add("@address", SqlDbType.NVarChar).Value = companyModel.Address;
                        command.Parameters.Add("@phone", SqlDbType.Int).Value = companyModel.Phone;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
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
                        command.CommandText = "DELETE FROM Company WHERE IdCompany=@id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void Edit(CompanyModel companyModel)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE Company 
                                            SET NameCompany=@name, Address=@address, Phone=@phone 
                                            WHERE IdCompany=@id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = companyModel.Id;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = companyModel.NameCompany;
                        command.Parameters.Add("@address", SqlDbType.NVarChar).Value = companyModel.Address;
                        command.Parameters.Add("@phone", SqlDbType.Int).Value = companyModel.Phone;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }


        /// <summary>
        /// Метод для считывания всех копманий
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CompanyModel> GetAll()
        {
            var companyList = new List<CompanyModel>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Company ORDER BY IdCompany DESC";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var companyModel = new CompanyModel
                                {
                                    Id = (int)reader[0],
                                    NameCompany = reader[1].ToString(),
                                    Address = reader[2].ToString(),
                                    Phone = (int)reader[3]
                                };

                                companyList.Add(companyModel);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return companyList;
        }


        /// <summary>
        /// Метод для нахождения заданного значения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<CompanyModel> GetByValue(string value)
        {
            var companyList = new List<CompanyModel>();
            int companyId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string companyName = value;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Company 
                                                WHERE IdCompany=@id OR NameCompany=@name+'%' 
                                                ORDER BY IdCompany DESC";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = companyId;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = companyName;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var companyModel = new CompanyModel
                                {
                                    Id = (int)reader[0],
                                    NameCompany = reader[1].ToString(),
                                    Address = reader[2].ToString(),
                                    Phone = (int)reader[3]
                                };

                                companyList.Add(companyModel);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return companyList;
        }

        #endregion
    }
}
