using app_card.Models;
using app_card.Models.Interfaces;
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
            string uniqueId = Guid.NewGuid().ToString();

            try
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO Cards VALUES (@Id, @Title, @Description, @UrlImage)", connection);
                command.Parameters.AddWithValue("@Id", uniqueId);
                command.Parameters.AddWithValue("@Title", card.Title);
                command.Parameters.AddWithValue("@Description", card.Description);
                command.Parameters.AddWithValue("@UrlImage", card.UrlImage ?? (object)DBNull.Value); // Operador ternario

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


        public bool Delete(string id, DataSource db)
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



        public List<Card> GetAll(DataSource db1, DataSource db2)
        {
            var cards = new List<Card>();

            using var connection1 = new SqlConnection(_configuration.GetConnectionString(db1.ToString()));
            using var connection2 = new SqlConnection(_configuration.GetConnectionString(db2.ToString()));

            try
            {
                connection1.Open();
                var command1 = new SqlCommand("SELECT * FROM Cards", connection1);
                var reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    var card = new Card
                    {
                        Id = reader1.GetGuid(0),
                        Title = reader1.GetString(1),
                        Description = reader1.GetString(2),
                        UrlImage = reader1.IsDBNull(3) ? null : reader1.GetString(3),
                        DataSource = db1

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
                        Id = reader2.GetGuid(0),
                        Title = reader2.GetString(1),
                        Description = reader2.GetString(2),
                        UrlImage = reader2.IsDBNull(3) ? null : reader2.GetString(3),
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

                var command = new SqlCommand("UPDATE Cards SET Title = @Title, Description = @Description WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", card.Id);
                command.Parameters.AddWithValue("@Title", card.Title);
                command.Parameters.AddWithValue("@Description", card.Description);

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
