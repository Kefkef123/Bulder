namespace Bulder.Models
{
    public class Message : TableEntity
    {
        public string Text { get; set; }
        public string Author { get; set; }
    }
}