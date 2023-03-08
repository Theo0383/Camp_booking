namespace Entities
{
    public class Booker
    {
        private int bookerId;
        private string bookerName;
        private string bookerEmail;
        private int reserveId_FK;

        public Booker(int bookerId, string bookerName, string bookerEmail, int reserveId_FK)
        {
            BookerId = bookerId;
            BookerName = bookerName;
            BookerEmail = bookerEmail;
            ReserveId_FK = reserveId_FK;
        }
        public Booker(string bookerName, string bookerEmail, int reserveId_FK)
            :this(0, bookerName, bookerEmail, reserveId_FK)
        {

        }

        public int BookerId { get => bookerId; set => bookerId = value; }
        public string BookerName { get => bookerName; set => bookerName = value; }
        public string BookerEmail { get => bookerEmail; set => bookerEmail = value; }
        public int ReserveId_FK { get => reserveId_FK; set => reserveId_FK = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}