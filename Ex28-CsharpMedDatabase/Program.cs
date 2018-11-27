using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ex28_CsharpMedDatabase
{
    class Program
    {
        private static string connectionString = "Server=EALSQL1.eal.local; Database=c_db05_2018; User Id=c_student05;Password=C_OPENDB05;";
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast Menu punkt");
            Console.WriteLine("1: Insert Pet");
            Console.WriteLine("2: Insert Owner");
            Console.WriteLine("3: Get Owner By Lastname");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Program program = new Program();
                program.InsertPet();
            }
            else if (input == "2")
            {
                Program program = new Program();
                program.InsertOwner();
            }
            else if (input == "3")
            {
                Program program = new Program();
                program.GetOwnersByLastName();
            }
            else
            {
                Console.WriteLine("No input");
            }
        }
        private  void InsertPet()
        {
            Console.WriteLine("indtast pet name");
            string petName = Console.ReadLine();
            Console.WriteLine("indtast pet type");
            string petType = Console.ReadLine();
            Console.WriteLine("indtast pet breed");
            string petBreed = Console.ReadLine();
            Console.WriteLine("indtast pet DOB");
            string petDOB = Console.ReadLine();
            Console.WriteLine("indtast pet weight");
            string petWeight = Console.ReadLine();
            Console.WriteLine("indtast owner id");
            string ownerID = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand insertPet = new SqlCommand("InsertPet", con);
                    insertPet.CommandType = CommandType.StoredProcedure;
                    insertPet.Parameters.Add(new SqlParameter("@PetName", petName));
                    insertPet.Parameters.Add(new SqlParameter("@PetType", petType));
                    insertPet.Parameters.Add(new SqlParameter("@PetBreed", petBreed));
                    insertPet.Parameters.Add(new SqlParameter("@PetDOB", petDOB));
                    insertPet.Parameters.Add(new SqlParameter("@PetWeight", petWeight));
                    insertPet.Parameters.Add(new SqlParameter("@OwnerID", ownerID));

                    insertPet.ExecuteNonQuery();

                    SqlCommand getPets = new SqlCommand("GetPets", con);
                    getPets.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = getPets.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string petID = reader["PetID"].ToString();
                            petName = reader["PetName"].ToString();
                            petType = reader["PetType"].ToString();
                            petBreed = reader["PetBreed"].ToString();
                            petDOB = reader["PetDOB"].ToString();
                            petWeight = reader["PetWeight"].ToString();
                            ownerID = reader["OwnerID"].ToString();
                            Console.WriteLine($"{petID} {petName} {petType} {petBreed} {petDOB} {petWeight} {ownerID}");
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
            }            
        }
        private void InsertOwner()
        {
            Console.WriteLine("indtast Owner LastName");
            string ownerLastName = Console.ReadLine();
            Console.WriteLine("indtast Owner FirstName");
            string ownerFirstName = Console.ReadLine();
            Console.WriteLine("indtast OwnerPhone");
            string ownerPhone = Console.ReadLine();
            Console.WriteLine("indtast OwnerEmail");
            string ownerEmail = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand insertOwner = new SqlCommand("InsertOwner", con);
                    insertOwner.CommandType = CommandType.StoredProcedure;
                    insertOwner.Parameters.Add(new SqlParameter("@OwnerLastName", ownerLastName));
                    insertOwner.Parameters.Add(new SqlParameter("@OwnerFirstName", ownerFirstName));
                    insertOwner.Parameters.Add(new SqlParameter("@OwnerPhone", ownerPhone));
                    insertOwner.Parameters.Add(new SqlParameter("@OwnerEmail", ownerEmail));

                    insertOwner.ExecuteNonQuery();

                    SqlCommand getOwners = new SqlCommand("GetOwners", con);
                    getOwners.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = getOwners.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ownerID = reader["OwnerID"].ToString();
                            ownerLastName = reader["OwnerLastName"].ToString();
                            ownerFirstName = reader["OwnerFirstName"].ToString();
                            ownerPhone = reader["OwnerPhone"].ToString();
                            ownerEmail = reader["OwnerEmail"].ToString();
                            Console.WriteLine($"{ownerID} {ownerLastName} {ownerFirstName} {ownerPhone} {ownerEmail}");
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
            }
        }
        private void GetOwnersByLastName()
        {
            Console.WriteLine("indtast Owner lastname");
            string ownerLastName = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand getOwnersByLastName = new SqlCommand("GetOwnerByLastName", con);
                    getOwnersByLastName.CommandType = CommandType.StoredProcedure;
                    getOwnersByLastName.Parameters.Add(new SqlParameter("@OwnerLastName", ownerLastName));

                    getOwnersByLastName.ExecuteNonQuery();

                    SqlDataReader reader = getOwnersByLastName.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ownerID = reader["OwnerID"].ToString();
                            ownerLastName = reader["OwnerLastName"].ToString();
                            string ownerFirstName = reader["OwnerFirstName"].ToString();
                            string ownerPhone = reader["OwnerPhone"].ToString();
                            string ownerEmail = reader["OwnerEmail"].ToString();
                            Console.WriteLine($"{ownerID} {ownerLastName} {ownerFirstName} {ownerPhone} {ownerEmail}");
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
            }
        }
        private void GetOwnersByEmail() { }
    }
}
