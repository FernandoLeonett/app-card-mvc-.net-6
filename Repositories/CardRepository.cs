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
        private readonly string _connectionString1;
        private readonly string _connectionString2;

        public CardRepository(string connectionString1, string connectionString2)
        {
            _connectionString1 = connectionString1;
            _connectionString2 = connectionString2;
        }

        public bool Add(Card card)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAll()
        {
            var cards = new List<Card>();

            using var connection1 = new SqlConnection(_connectionString1);
            using var connection2 = new SqlConnection(_connectionString2);

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

        public Card GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
