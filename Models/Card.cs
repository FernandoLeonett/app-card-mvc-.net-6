namespace app_card.Models
{

    public enum DataSource
    {

        CHRISTMAS,
        BIRTHDAY
    }
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string UrlImage { get; set; }

        
        public DataSource DataSource { get; set; }
    }
}
