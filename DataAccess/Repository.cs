using Entities;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CampDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Booker> GetAllBookers()
        {
            try
            {
                List<Booker> bookers = new List<Booker>();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Bookers";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Booker bookInfo = new(
                        (int)reader["BookerId"],
                        (string)reader["Bookername"],
                        (string)reader["BookerEmail"],
                        (int)reader["ReserveId_FK"]
                        );
                    bookers.Add(bookInfo);
                }
                connection.Close();
                connection.Dispose();
                return bookers;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException("Could not extablish a connection to the database", e);
            }
        }
        public List<Reservation> GetAllReservations(int res_Id_FK)
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Reservations";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reserveInfo = new(
                        (int)reader["ReserveId"],
                        (DateTime)reader["ReserveStart"],
                        (DateTime)reader["ReserveStart"],
                        (int)reader["SpaceId_FK"]
                        );
                    if(reserveInfo.ReserveId == res_Id_FK)
                    { 
                        reservations.Add(reserveInfo);
                    }
                }
                connection.Close();
                connection.Dispose();
                return reservations;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException("Could not extablish a connection to the database", e);
            }
        }
        public List<Space> GetAllSpaces()
        {
            try
            {
                List<Space> spaces = new List<Space>();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Spaces";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Space spaceInfo = new(
                        (int)reader["SpaceId"],
                        (string)reader["SpaceVIP"]
                        );
                    spaces.Add(spaceInfo);
                }
                connection.Close();
                connection.Dispose();
                return spaces;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException("Could not extablish a connection to the database", e);
            }
        }
        public void SaveNewBooker(Booker booker)
        {
            string sql = $"INSERT INTO Bookers(BookerName, BookerEmail, ReserveId_FK) VALUES('{booker.BookerName}', '{booker.BookerEmail}', '{booker.ReserveId_FK}');";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void SaveNewReservation(Reservation reservation)
        {
            string sql = $"INSERT INTO Reservations(ReserveStart, ReserveEnd, SpaceId_FK) VALUES('{reservation.ReserveStart.ToString("yyyy-MM-dd HH:mm:ss")}', '{reservation.ReserveEnd.ToString("yyyy-MM-dd HH:mm:ss")}', '{reservation.SpaceId_FK}');";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
    }
}