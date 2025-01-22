namespace Demo_ASP_01.Models
{
    public class MessageDetails
    {
        public PersonneDetails Sender { get; set; }
        public PersonneDetails Receiver { get; set; }
        public DateTime SendedDate { get; set; }
        public bool IsReceived { get; set; }
        public string Content { get; set; }
    }
}
