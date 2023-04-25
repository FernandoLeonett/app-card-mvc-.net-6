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
        
            return new CardRepository(_configuration);
        }

        private string GetConnectionString(DataSource baseType)
        {
            try
            {
                return _configuration.GetConnectionString(baseType.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not find connection string for {baseType} DataSource.", ex);
            }
        }

    }
}
