using System.Reflection.Metadata.Ecma335;

namespace serverSide.BL
{
    public class IUser
    {
        int id;
        string userName = string.Empty;
        string eMail = string.Empty;
        string password = string.Empty;
        bool isAdmin = false;
        bool isActive = true;
        bool isLogIn = false; // Because there is only one user logged in every time --> an indecator for us to know
        public IUser() { }


        public IUser(string userName, string eMail, string password)
        {
            this.userName = userName;
            this.eMail = eMail;
            this.password = password;
            
        }
        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public string Password { get => password; set => password = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool IsLogIn { get => isLogIn; set => isLogIn = value; }

        //static public List<IUser> ReadUsers() { return usersList; }
        //static public List<Book> allBooks() { return myBooks; }

        


        //// Add new book to the user's books list
        //public static bool addNewBook(Book book)
        //{
        //    // Check if the book is already in my list --> if it is return false

           

        //}



        //// Delete book from my book list --> by book id
        //public static bool DeleteBookById(int id)
        //{
           
        //}

        


       
    }
}
