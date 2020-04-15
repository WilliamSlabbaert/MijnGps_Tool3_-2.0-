﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tool3
{
    class Program
    {
        public static SqlConnection database = new SqlConnection(@"Data Source=WILLIAM-SLABBAE\SQLEXPRESS;Initial Catalog=AdressenOpdracht;Integrated Security=True");
        static void Main(string[] args)
        {
           
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Get province [1]");
                Console.WriteLine("Get City [2]");
                Console.WriteLine("Get Street [3]");
                Console.WriteLine("Close [4]");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("==> ");
                Console.ResetColor();
                int input = Convert.ToInt32(Console.ReadLine());
                if(input == 1)
                {
                    Choice1();
                }
                if (input == 2)
                {
                    Choice2();
                }
                if (input == 3)
                {
                    Choice3();
                }
                if (input == 4)
                {
                    break;
                }

            }
            
        }

        static void Choice1()
        {
            Console.Write("Province = ");
            String provinceInput = Console.ReadLine();
            Console.WriteLine();
            database.Open();
            SqlCommand command1 = new SqlCommand($"SELECT * FROM [dbo].[Provincie] WHERE PROVINCIENAME=@input", database);
            command1.Parameters.AddWithValue("@input", provinceInput);

            SqlDataAdapter ada = new SqlDataAdapter(command1);

            DataTable set = new DataTable();
            ada.Fill(set);
            String ID = "";
            String NAME = "";
            String gemt = "";
            foreach(DataRow row in set.Rows)
            {
                ID = row[0].ToString();
                NAME = row[1].ToString();
                gemt = row[2].ToString();
            }
            database.Close();
            database.Open();
            String[] GemeenteIds = gemt.Split(",");
            List<String> listIdsGem = new List<string> { };
            foreach (string item in GemeenteIds)
            {
                SqlCommand command2 = new SqlCommand($"SELECT * FROM [dbo].[Gemeente] WHERE ID=@input", database);
                command2.Parameters.AddWithValue("@input", item);
                SqlDataAdapter ada2 = new SqlDataAdapter(command2);
                DataTable set2 = new DataTable();
                ada2.Fill(set2);
                foreach(DataRow row in set2.Rows)
                {
                    listIdsGem.Add(row[1].ToString());
                }
            }
            Console.WriteLine($"ID = {ID} | NAME = {NAME} | CITYCOUNT = {listIdsGem.Count}");
            Console.WriteLine("SEE ALL THE CITIES [Y]");
            String i = Console.ReadLine();
            if (i.ToLower() == "y")
            {
                foreach (string item in listIdsGem)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                database.Close();

            }
            else
            {
                Console.ReadLine();
                database.Close();
            }

            Console.ReadLine();
        }
        static void Choice2()
        {
            Console.Write("City = ");
            String CityInput = Console.ReadLine();
            Console.WriteLine();
            database.Open();
            SqlCommand command1 = new SqlCommand($"SELECT * FROM [dbo].[Gemeente] WHERE GEMEENTENAME=@input", database);
            command1.Parameters.AddWithValue("@input", CityInput);

            SqlDataAdapter ada = new SqlDataAdapter(command1);

            DataTable set = new DataTable();
            ada.Fill(set);
            String ID = "";
            String NAME = "";
            String strt = "";
            String MIN = "";
            String MAX = "";
            foreach (DataRow row in set.Rows)
            {
                ID = row[0].ToString();
                NAME = row[1].ToString();
                strt = row[2].ToString();
                MAX = row[3].ToString();
                MIN = row[4].ToString();
            }
            database.Close();

            String[] strIds = strt.Split(",");
            List<String> ListStreets = new List<string> { };
            foreach (string item in strIds)
            {
                SqlCommand command2 = new SqlCommand($"SELECT * FROM [dbo].[Streets] WHERE ID=@input", database);
                command2.Parameters.AddWithValue("@input", item);
                SqlDataAdapter ada2 = new SqlDataAdapter(command2);
                DataTable set2 = new DataTable();
                ada2.Fill(set2);
                foreach (DataRow row in set2.Rows)
                {
                    ListStreets.Add(row[1].ToString());
                }
            }
            Console.WriteLine($"ID = {ID} | NAME = {NAME} | BIGGEST STREET = {MAX} | SMALLEST STREET = {MIN}");
            Console.WriteLine("SEE ALL THE STREETS [Y]");
            String i = Console.ReadLine();
            if(i.ToLower() == "y")
            {
                foreach (string item in ListStreets)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                database.Close();
            }
            else
            {
                Console.ReadLine();
                database.Close();
            }

        }
        static void Choice3()
        {
            Console.Write("Street = ");
            String streetInput = Console.ReadLine();
            Console.WriteLine();
            database.Open();
            SqlCommand command1 = new SqlCommand($"SELECT * FROM [dbo].[Streets] WHERE STREETNAME=@input", database);
            command1.Parameters.AddWithValue("@input", streetInput);

            SqlDataAdapter ada = new SqlDataAdapter(command1);

            DataTable set = new DataTable();
            ada.Fill(set);
            String ID = "";
            String NAME = "";
            String Segments = "";
            foreach (DataRow row in set.Rows)
            {
                ID = row[0].ToString();
                NAME = row[1].ToString();
                Segments = row[3].ToString();
            }
            String[] SegmentsList = Segments.Split(",");
            Console.WriteLine($"ID = {ID} | NAME = {NAME}");
            Console.WriteLine("SEE ALL DETAILS [Y]");
            String input = Console.ReadLine();
            if(input.ToLower() == "y" )
            {
                foreach(string s in SegmentsList)
                {
                    Console.WriteLine(s);
                }
                database.Close();
            }
            else
            {
                Console.ReadLine();
                database.Close();
            }

        }
    }
}