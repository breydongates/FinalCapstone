namespace Capstone.Models
{
    public class Collection
    {
        public int UserId { get; set; }

        public int CollectionId { get; set; } = 0;

        public string CollectionName { get; set; }

        public bool IsPrivate { get; set; }


    }
}
