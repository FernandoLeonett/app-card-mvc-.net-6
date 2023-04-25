using app_card.Models;
using app_card.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace app_card.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IConfiguration _configuration;


        public CardRepository(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        public bool Add(Card card)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(card.DataSource.ToString()));

            try
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO Cards (Title, Description, UrlImage) VALUES (@Title, @Description, @UrlImage)", connection);
                command.Parameters.AddWithValue("@Title", card.Title);
                command.Parameters.AddWithValue("@Description", card.Description);
                command.Parameters.AddWithValue("@UrlImage", card.UrlImage);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                // Lanzamos la excepción para que sea capturada en los controladores
                throw;
            }
            finally
            {
                // Usamos Dispose para liberar los recursos de la conexión
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Dispose();
                }
            }
        }


        public bool Delete(int id, DataSource db)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(db.ToString()));

            try
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM Cards WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                // Lanzamos la excepción para que sea capturada en los controladores
                throw;
            }
            finally
            {
                // Usamos Dispose para liberar los recursos de la conexión
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Dispose();
                }
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAll(DataSource db1, DataSource db2)
        {
            var cards = new List<Card>();

            using var connection1 = new SqlConnection(_configuration.GetConnectionString(db1.ToString()));
            using var connection2 = new SqlConnection(_configuration.GetConnectionString(db1.ToString()));

            try
            {
                connection1.Open();
                var command1 = new SqlCommand("SELECT * FROM Cards", connection1);
                var reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    var card = new Card
                    {
                        Id = reader1.GetInt32(0),
                        Title = reader1.GetString(1),
                        Description = reader1.GetString(2),
                        UrlImage = reader1.GetString(3),
                        DataSource =db1
                      
                    };
                    cards.Add(card);
                }

                reader1.Close();

                connection2.Open();
                var command2 = new SqlCommand("SELECT * FROM Cards", connection2);
                var reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    var card = new Card
                    {
                        Id = reader2.GetInt32(0),
                        Title = reader2.GetString(1),
                        Description = reader2.GetString(2),
                        UrlImage = reader2.GetString(3),
                        DataSource = db2


                    };
                    cards.Add(card);
                }

                reader2.Close();
            }
            catch (Exception)
            {
                // Lanzamos la excepción para que sea capturada en los controladores
                throw;
            }
            finally
            {
                // Usamos Dispose para liberar los recursos de la conexión
                if (connection1.State != ConnectionState.Closed)
                {
                    connection1.Dispose();
                }

                if (connection2.State != ConnectionState.Closed)
                {
                    connection2.Dispose();
                }
            }

            return cards;
        }

        public Card GetById(int id, DataSource db)
        {
            throw new NotImplementedException();
        }

        public bool Update(Card card)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(card.DataSource.ToString()));

            try
            {
                connection.Open();

                var command = new SqlCommand("UPDATE Cards SET Title = @Title, Description = @Description, UrlImage = @UrlImage WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", card.Id);
                command.Parameters.AddWithValue("@Title", card.Title);
                command.Parameters.AddWithValue("@Description", card.Description);
                command.Parameters.AddWithValue("@UrlImage", card.UrlImage);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                // Lanzamos la excepción para que sea capturada en los controladores
                throw;
            }
            finally
            {
                // Usamos Dispose para liberar los recursos de la conexión
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Dispose();
                }
            }
        }
    }
}
