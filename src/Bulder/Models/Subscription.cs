namespace Bulder.Models
{
    public class Subscription
    {
        public Guid RowKey { get; set; }
        public string EmailAddress { get; set; }
        public string TwitterChannel { get; set; }
    }
}