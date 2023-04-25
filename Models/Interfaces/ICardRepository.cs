namespace app_card.Models.Interfaces
{
    public interface ICardRepository
    {
        List<Card> GetAll();
        Card GetById(int id);
        Boolean Add(Card card);
        Boolean Update(Card card);
        Boolean Delete(int id);
    }
}
