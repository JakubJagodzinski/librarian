﻿namespace librarian.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}