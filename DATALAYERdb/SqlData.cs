using System.Collections.Generic;
using System.Data.SqlClient;
using MODELSdb;

namespace DATALAYERdb
{
    public class SqlData
    {
        string connectionString = "Data Source=LAPTOP-JGL8F6OD\\SQLEXPRESS;Initial Catalog=AnimeList;Integrated Security=True;";
        SqlConnection sqlConnection;

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<AnimeContent> GetAnime()
        {
            string animelists = "SELECT Title, Studio, ReleaseDate, Status, Genre, Episodes, Summary FROM AnimeListTable";
            SqlCommand select = new SqlCommand(animelists, sqlConnection);

            sqlConnection.Open();
            List<AnimeContent> animeList = new List<AnimeContent>();
            SqlDataReader rd = select.ExecuteReader();



                while (rd.Read())
                     {   
                         AnimeContent anime = new AnimeContent
                     {
                            title = rd["Title"].ToString(),
                            studio = rd["Studio"].ToString(),
                            releasedate = rd["ReleaseDate"].ToString(),
                            status = rd["Status"].ToString(),
                            genre = rd["Genre"].ToString(),
                            episodes = rd["Episodes"].ToString(),
                            summary = rd["Summary"].ToString()
                    };
                    animeList.Add(anime);
                }

            sqlConnection.Close();
            return animeList;
        }

        public int AddAnime(string title, string studio, string releasedate, string status, string genre, string episodes, string summary)
        {
            string addani = "INSERT INTO AnimeListTable (Title, Studio, ReleaseDate, Status, Genre, Episodes, Summary) VALUES (@title, @studio, @releasedate, @status, @genre, @episodes, @summary)";
            SqlCommand addnewanime = new SqlCommand(addani, sqlConnection);

                    addnewanime.Parameters.AddWithValue("@title", title);
                    addnewanime.Parameters.AddWithValue("@studio", studio);
                    addnewanime.Parameters.AddWithValue("@releasedate", releasedate);
                    addnewanime.Parameters.AddWithValue("@status", status);
                    addnewanime.Parameters.AddWithValue("@genre", genre);
                    addnewanime.Parameters.AddWithValue("@episodes", episodes);
                    addnewanime.Parameters.AddWithValue("@summary", summary);

            sqlConnection.Open();

            int success = addnewanime.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int RemoveAnime(string title)
        {
            string remove = "DELETE FROM AnimeListTable WHERE Title = @title";
            SqlCommand removeoldanime = new SqlCommand(remove, sqlConnection);
            removeoldanime.Parameters.AddWithValue("@title", title);

            sqlConnection.Open();

            int oldanime = removeoldanime.ExecuteNonQuery();

            sqlConnection.Close();

            return oldanime;
        }

        public List<AnimeContent> SearchAnime(string keyword)
        {
            string search = "SELECT Title, Studio, ReleaseDate, Status, Genre, Episodes, Summary FROM AnimeListTable WHERE Title LIKE @keyword OR Studio LIKE @keyword OR Genre LIKE @keyword";
            SqlCommand searchanime = new SqlCommand(search, sqlConnection);
            searchanime.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            sqlConnection.Open();

            List<AnimeContent> searchResults = new List<AnimeContent>();
            SqlDataReader read = searchanime.ExecuteReader();



                    while (read.Read())
                    {
                        AnimeContent anime = new AnimeContent
                        {
                            title = read["Title"].ToString(),
                            studio = read["Studio"].ToString(),
                            releasedate = read["ReleaseDate"].ToString(),
                            status = read["Status"].ToString(),
                            genre = read["Genre"].ToString(),
                            episodes = read["Episodes"].ToString(),
                            summary = read["Summary"].ToString()
                        };
                        searchResults.Add(anime);
                    }

            sqlConnection.Close();

            return searchResults;
        }

        
    }
}
