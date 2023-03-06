using System;
using System.Dynamic;
using APP_MUSIC.Models;

namespace API_MUSIC.Interface
{
	public interface IMusic
	{
        Task<ExpandoObject> GetSongsDetailsAsync(int Id);
        Task<TopSongs> GetTopSongArtistAsync(int Id);

        Task<SongModel> SearchSongAsync(string searchWords);

    }
}

