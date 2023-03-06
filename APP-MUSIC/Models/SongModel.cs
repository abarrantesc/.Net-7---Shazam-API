using System;
namespace APP_MUSIC.Models
{
        public class SongModel
        {

        public Tracks tracks { get; set; }
        public Artists artists { get; set; }
         }

        public class Tracks
        {
            public List<Hits> hits { get; set; }
        }

        public class Hits
        {
            public Track track { get; set; }
            public string snippet { get; set; }
        }

        public class Track
        {
            public string layout { get; set; }
            public string type { get; set; }
            public string key { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public Share share { get; set; }
            public Images images { get; set; }
            public Hub hub { get; set; }
            public List<Artist> artists { get; set; }
            public string url { get; set; }
        }

        public class Hit
        {
            public Track track { get; set; }
            public Artist2 artist { get; set; }
        }

 
        public class Artist2
        {
            public string avatar { get; set; }
            public string name { get; set; }
            public bool verified { get; set; }
            public string weburl { get; set; }
            public string adamid { get; set; }
        }

        public class Artists
        {
            public string id { get; set; }
            public string adamid { get; set; }
            public List<Hit> hits { get; set; }
        }


    
}

