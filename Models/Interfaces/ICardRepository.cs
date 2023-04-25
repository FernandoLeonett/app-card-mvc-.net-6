namespace app_card.Models.Interfaces
{
    public interface ICardRepository
    {
        List<Card> GetAll(DataSource DataSource1, DataSource DataSource2);
        Card GetById(int id, DataSource db);
        bool Add(Card card);
        bool Update(Card card);
        bool Delete(int id);
    }
}
