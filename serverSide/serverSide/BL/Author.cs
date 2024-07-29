namespace serverSide.BL
{
    public class Author
    {

        string name = string.Empty;
        int id;

        public Author(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        // public static Author addNewAuthor(int id, string name) { }
    }
}
