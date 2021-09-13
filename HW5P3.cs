using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace HW5
{
    class HW5P3
    {
        static MySqlConnection conn;

        static void S1()
        {
            MySqlDataReader reader;
            Console.WriteLine("Enter a news id: ");
            // Read an integer from the user
            string stringInput = Console.ReadLine();
            int input = Int32.Parse(stringInput);

            try
            {
                // Write (copy from queries folder) the query, using the news id read from the user
                //      You can use @" to begin a raw string, which allows for multiple lines in the string

                // Build a Command which holds the query and the location of the target server
                //      Use the static MySqlConnection object conn which was initialized and opened at the beginning of the application

                // Retrieve the results into a DataReader
                //      There are many methods for executing a command, use the one which returns a DataReader for the simplest solution.

                // Output the header from the DataReader
                //     Use the .GetName function of the DataReader to get the column names for the header (just one column for function 1)

                // Loop through the rows of the DataReader to output the values from the DataReader

                /*
                        Inside the loop
                        We use the DataReader object to get the values in the rows matching the columns of the header ouput before the loop.
                         -> reader.GetType(index) //Where 'Type' in GetType is to be replaced by the actual type of the attribute.
                         -> GetString for string type, GetInt32 for Integer types etc.
                        For Example: 
                        Console.WriteLine(String.Format("{0}\t{1}", reader.GetString(index1), reader.GetInt32(index2)));
                */

                // Close the DataReader
                string q = "SET @nid = " + input.ToString() + ";" + "SELECT title" + " FROM news" + " WHERE news_id = @nid;";
                string query = String.Format(@q);
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("title"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader.GetString(0)));
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S2()
        {
            MySqlDataReader reader;
            
            try
            {
                // Write (copy from queries folder) the query
                string query = String.Format(@" 
                                                SELECT news_id, LENGTH(body_text) AS length
                                                FROM news
                                                WHERE LENGTH(body_text)>100
                                                ORDER BY news_id;
                                            ");

                // Build a Command which holds the query and the location of the target server

                // Retrieve the results into a DataReader

                // Output the header from the DataReader
                //Console.WriteLine(String.Format("{0}\t{1}",reader.GetName(0), reader.GetName(1)));

                // Loop through the rows of the DataReader to output the values from the DataReader
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("news_id\tlength"));
                while (reader.Read())
		            {
			            Console.WriteLine(String.Format("{0}\t{1}",reader.GetString(0), reader.GetInt32(1)));
                    }
                reader.Close();


                // Close the DataReader
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S3()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT title, DATE_FORMAT(STR_TO_DATE(publish_date, '%c/%d/%y'), '%M') AS Month
                                                FROM news
                                                ORDER BY STR_TO_DATE(publish_date, '%m/%d/%y')
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("title\tMonth"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1}", reader.GetString(0), reader.GetString(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S4()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@"                                                
                                                SELECT publisher
                                                FROM publisher_table
                                                JOIN news
                                                USING (publisher_id)
                                                GROUP BY publisher
                                                ORDER BY publisher;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("publisher"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader.GetString(0)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S5()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT country, COUNT(news_id) AS articleCount
                                                FROM country_table
                                                LEFT JOIN news
                                                USING (country_id)
                                                GROUP BY country
                                                ORDER BY articleCount DESC;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("country\tarticleCount"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1}", reader.GetString(0), reader.GetInt32(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S6()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT ROUND(AVG(news_guard_score),3) AS `Average Score`
                                                FROM news;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("Average Score"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0:0.000}", reader.GetDouble(0)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S7()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT month, numArticles, overall, ROUND(100*numArticles/overall,3) AS percentage
                                                FROM
                                                (
                                                SELECT month, monthnum, COUNT(publish_date) AS numArticles, overallCount AS overall
                                                FROM
                                                (
                                                SELECT DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%M') AS month, 
                                                DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%m') AS monthnum,
	                                            publish_date
                                                FROM news
                                                ) AS T1
                                                JOIN
                                                (
                                                SELECT COUNT(*) overallCount FROM news
                                                ) AS T2
                                                GROUP BY month, monthnum, overallCount
                                                ) AS T3
                                                ORDER BY monthnum;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("month\tnumArticles\toverall\tpercentage"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}", reader.GetString(0), reader.GetInt32(1), reader.GetDecimal(2), reader.GetDecimal(3)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S8()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT publisher, ROUND(AVG(reliability)*100, 3) AS percentage
                                                FROM news
                                                JOIN publisher_table
                                                USING (publisher_id)
                                                GROUP BY publisher
                                                ORDER BY percentage DESC, publisher;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("publisher\tpercentage"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1}", reader.GetString(0), reader.GetDecimal(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S9()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT country, ROUND(AVG(news_guard_score),3) AS avg_news_score
                                                FROM news
                                                JOIN country_table
                                                USING (country_id)
                                                GROUP BY country
                                                ORDER BY AVG(news_guard_score) DESC, country ASC;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("country\tavg_news_score"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1:0.000}", reader.GetString(0), reader.GetDecimal(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void S10()
        {
            MySqlDataReader reader;
            try
            {
                // Write (copy from queries folder) the query
                // Build a Command which holds the query and the location of the target server
                // Retrieve the results into a DataReader
                // Output the header from the DataReader
                // Loop through the rows of the DataReader to output the values from the DataReader
                // Close the DataReader
                string query = String.Format(@" 
                                                SELECT author, political_bias, COUNT(*) AS numArticles
                                                FROM news
                                                JOIN news_authors
                                                USING (news_id)
                                                JOIN author_table
                                                USING (author_id)
                                                JOIN political_bias_table
                                                USING (political_bias_id)
                                                GROUP BY author, political_bias
                                                ORDER BY author, COUNT(*) DESC, political_bias;
                                            ");
                MySqlCommand cmd = new MySqlCommand(query, conn); reader = cmd.ExecuteReader();
                Console.WriteLine(String.Format("author\tpolitical_bias\tnumArticles"));
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1}\t{2}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void establishConnection()
        {
            string connStr = "server=localhost;user=root;database=hw5;port=3306;password=password;Allow User Variables=True;";  // change the database and password to test on your machine
            conn = new MySqlConnection(connStr);                                                     // must be these values when submitting to gradescope
            conn.Open();
        }

        static void Main(string[] args)
        {
            try
            {
                // Establish Connection to MySQL Server
                Console.WriteLine("Testing Connection to MySQL Server...");
                establishConnection();
                Console.WriteLine("Established Connection to MySQL Server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Could not connect to the server.");
                Console.WriteLine("Check that the server is running,");
                Console.WriteLine("that you have loaded the database hw5,");
                Console.WriteLine("And that the password in establishConnection() matches your MySQL password.");                
                return;
            }
            
            // Loop until the user enters 0
            Console.WriteLine("Which task to perform (0 for quit): ");
            // Take a number as input from the user
            string stringInput = Console.ReadLine();
            int input = Int32.Parse(stringInput);

            while (input != 0)
            {
                // Use a switch case to call the function the user chose
                // If it was none of the options, output "Invalid choice"
                switch (input)
                {
                    case 1:
                        S1();
                        break;
                    case 2:
                        S2();
                        break;
                    case 3:
                        S3();
                        break;
                    case 4:
                        S4();
                        break;
                    case 5:
                        S5();
                        break;
                    case 6:
                        S6();
                        break;
                    case 7:
                        S7();
                        break;
                    case 8:
                        S8();
                        break;
                    case 9:
                        S9();
                        break;
                    case 10:
                        S10();
                        break;
                    default:
                        Console.WriteLine(input);
                        break;
                }

                Console.WriteLine("\nWhich task to perform (0 for quit): ");
                stringInput = Console.ReadLine();
                input = Int32.Parse(stringInput);
            }
        }
    }
}
