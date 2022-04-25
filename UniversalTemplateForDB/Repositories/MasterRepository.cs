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

        public IEnumerable<MasterModel> GetAll()
        {
            var masterList = new List<MasterModel>();

            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Master ORDER BY IdMaster DESC";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var masterModel = new MasterModel
                                {
                                    Id = (int)reader[0],
                                    Name = reader[1].ToString(),
                                    SecondName = reader[2].ToString(),
                                    Experience = (int)reader[3]
                                };
                                masterList.Add(masterModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return masterList;
        }

        public IEnumerable<MasterModel> GetByValue(string value)
        {
            var masterList = new List<MasterModel>();
            int idMaster = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string name = value;
            string secondName = value;

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

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var masterModel = new MasterModel()
                                {
                                    Id = (int)reader[0],
                                    Name = reader[1].ToString(),
                                    SecondName = reader[2].ToString(),
                                    Experience = (int)reader[3]
                                };
                                masterList.Add(masterModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return masterList;
        }
    }
}
