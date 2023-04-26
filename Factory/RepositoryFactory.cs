using app_card.Models.Interfaces;
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

       
    }
}
