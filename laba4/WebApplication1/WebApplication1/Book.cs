namespace WebApplication1
{
    public class Book
    {
        public String Name { get; set; }
        public int Year { get; set; }
        public String Genre { get; set; }
        public String Author { get; set; }
        public Book()
        {

        }
        public Book(string name, int year, string genre, string author)
        {
            this.Name = name;
            this.Year = year;
            this.Genre = genre;
            this.Author = author;
        }
        public string GetBookInfo()
        {
            return $"<td>{Name}</td><td>{Year}</td><td>{Genre}</td><td>{Author}</td>";
        }
    }

}
