using app_card.Models.Interfaces;
using app_card.Models;
using app_card.Repositories;


namespace app_card
{
    public class RepositoryFactory : IRepositoryFactory
    {

        private readonly IConfiguration _configuration;

        public RepositoryFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICardRepository GetCardRepository()
        {
        
            return new CardRepository(_configuration.GetConnectionString("BirthdayCards"), _configuration.GetConnectionString("ChristmasCards"));
        }

        private string GetConnectionString(DataSource baseType)
        {
            string? connectionString = baseType switch
            {
                DataSource.BIRTHDAY => _configuration.GetConnectionString("BirthdayCards"),
                DataSource.CHRISTMAS => _configuration.GetConnectionString("ChristmasCards"),
                _ => throw new ArgumentException("Invalid BaseType value"),
            };
            return connectionString;
        }
    }
}
