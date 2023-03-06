using System;
namespace APP_MUSIC.Models
{




    public class Artwork
    {
        public int width { get; set; }
        public string url { get; set; }
        public int height { get; set; }
        public string textColor3 { get; set; }
        public string textColor2 { get; set; }
        public string textColor4 { get; set; }
        public string textColor1 { get; set; }
        public string bgColor { get; set; }
        public bool hasP3 { get; set; }
    }

    public class Attributes
    {
        public bool hasTimeSyncedLyrics { get; set; }
        public string albumName { get; set; }
        public List<string> genreNames { get; set; }
        public int trackNumber { get; set; }
        public string releaseDate { get; set; }
        public int durationInMillis { get; set; }
        public bool isVocalAttenuationAllowed { get; set; }
        public bool isMasteredForItunes { get; set; }
        public string isrc { get; set; }
        public Artwork artwork { get; set; }
        public string composerName { get; set; }
        public string audioLocale { get; set; }
        public PlayParams playParams { get; set; }
        public string url { get; set; }
        public int discNumber { get; set; }
        public bool isAppleDigitalMaster { get; set; }
        public bool hasLyrics { get; set; }
        public List<string> audioTraits { get; set; }
        public string name { get; set; }
        public List<Preview> previews { get; set; }
        public string artistName { get; set; }
        public string contentRating { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
    }

    public class PlayParams
    {
        public string id { get; set; }
        public string kind { get; set; }
    }

    public class Preview
    {
        public string url { get; set; }
    }

    public class TopSongs
    {
        public List<Datum> data { get; set; }
    }


}

