using System.Collections.Generic;
using MODELSdb;
using DATALAYERdb;

namespace BUSINESSLOGICdb
{
    public class AnimeProcess
    {

        private SqlData data;

        public AnimeProcess()
        {
            data = new SqlData();
        }

        public List<AnimeContent> GetAllAnime()
        {
            return data.GetAnime();

        }

        public int AddAnime(AnimeContent anime)
        {
            return data.AddAnime(anime.title, anime.studio, anime.releasedate, anime.status, anime.genre, anime.episodes, anime.summary);
        }


        public int RemoveAnime(string title)
        {
            return data.RemoveAnime(title);
        }

        public List<AnimeContent> SearchAnime(string keyword)
        {

            return data.SearchAnime(keyword);
        }

        
    }
}
