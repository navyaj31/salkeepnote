using SqlKeepnote;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace SqlKeepnote
{
    public class KeepNotes
    {
        public void AddNote()
        {
            SqlConnection con = new SqlConnection("server=IN-8HRQ8S3; database=Keepnote; Integrated security=true");
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Notes", con);
            DataSet ds = new DataSet();
            adp.Fill(ds); 
            var row  = ds.Tables[0].NewRow();


            Console.WriteLine("Enter notes title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the description of the notes:  ");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;

            row["Title"]=title;
            row["Description"]=description;
            row["Date"]=date;

            ds.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Details are successfully added");
        
        }

        public void ViewNote()
        {
            SqlConnection con = new SqlConnection("server=IN-8HRQ8S3; database=Keepnote; Integrated security=true");
            Console.WriteLine("Enter the Note_Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"Select * from Notes where  Note_Id = {id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            Console.WriteLine("Note_Id\tNote_Title\tNote_Description\tNote_Date");
            for(int i= 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for(int j=0; j< ds.Tables[0].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables[0].Rows[i][j]}\t");    
                }
                Console.WriteLine();
            } 

        }
        public void ViewAllNotes()
        {
            SqlConnection con = new SqlConnection("server=IN-8HRQ8S3; database=Keepnote; Integrated security=true");
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Notes", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            Console.WriteLine("Note_Id\tNote_Title\tNote_Description\tNote_Date");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                }
                Console.WriteLine();

            }
            Console.Write("Total Notes = ");
            Console.Write($"{ds.Tables[0].Rows.Count}");
            Console.WriteLine();


        }
        public void UpdateNote()
        {
            SqlConnection con = new SqlConnection("server=IN-8HRQ8S3; database=Keepnote; Integrated security=true");
            Console.WriteLine("Enter the Notes_Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"Select * from Notes where Note_Id = {id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            Console.WriteLine("Enter notes title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the description of the notes:  ");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;

            var row = ds.Tables[0].Rows[0];
            row["Title"] = title;
            row["Description"] = description;
            row["Date"] = date;
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Details are successfully Updated");
        }
        public void DeleteNote()
        {
            SqlConnection con = new SqlConnection("server=IN-8HRQ8S3; database=Keepnote; Integrated security=true");
            Console.WriteLine("Enter the Notes_Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"Select * from Notes where Note_Id = {id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ds.Tables[0].Rows[0].Delete();
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Details are successfully deleted");

        }

    }
     

                

}

internal class Program
{
    static void Main(string[] args)
    {
        KeepNotes Note = new KeepNotes();

        while (true)
        {
            Console.WriteLine("1. Create notes");
            Console.WriteLine("2. Get notes  By Id");
            Console.WriteLine("3. Get All notes");
            Console.WriteLine("4. Update notes By Id");
            Console.WriteLine("5. Delete Notes");
            Console.WriteLine("Enter Your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Note.AddNote();
                        break;
                    }
                case 2:
                    {
                        Note.ViewNote();
                        break;
                    }
                case 3:
                    {
                        Note.ViewAllNotes();
                        break;
                    }
                case 4:
                    {
                        Note.UpdateNote();
                        break;
                    }
                case 5:
                    {
                        Note.DeleteNote();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Choice");
                        break;

                    }

            }
        }

    }
}
