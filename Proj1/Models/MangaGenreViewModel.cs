using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proj1.Models
{
    public class MangaGenreViewModel
    {
        public List<Manga>? Mangas { get; set; }
        public SelectList? Genres { get; set; }
        public string? MangaGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
