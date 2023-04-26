namespace app_card.Models.Interfaces
{
    public interface IRepositoryFactory
    {
        ICardRepository GetCardRepository();

    }
}
