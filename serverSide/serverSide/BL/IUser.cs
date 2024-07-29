using System.Net;
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

<<<<<<< Updated upstream
        static public List<IUser> ReadUsers() { return usersList; }
        
=======
        //static public List<IUser> ReadUsers() { return usersList; }
        //static public List<Book> allMyBooks() { return myBooks; }
>>>>>>> Stashed changes

        // add new user
        public bool Insert(IUser newUser)
        {
            DBservicesUsers dBservicesUsers = new DBservicesUsers();

            if (dBservicesUsers.AddNewUser(newUser) == 1) return true;

            else return false;
        }

<<<<<<< Updated upstream

        // Add new book to the user's books list
        public static bool addNewBook(int userId, int bookId)
        {
            // Check if the book is already in my list --> if it is return false

            DBservicesUsers dBservicesUsers = new DBservicesUsers();
            dBservicesUsers.addNewbookToUser(userId,bookId);
            return true;

        }

        //show all user's books
        public static List<Book> showMyBooks(int userId)
        {
            DBservicesUsers dBservicesUsers = new DBservicesUsers();
            return dBservicesUsers.GetBooksPerUser(userId);

        }



        // Delete book from my book list --> by book id
        //public static bool DeleteBookById(int id)
        //{

        //}
=======
        // login a user
        public static int Login(IUser LoginUser)
        {
            DBservicesUsers dbservicesUsers = new DBservicesUsers();

            return dbservicesUsers.logInUser(LoginUser);

        }
        // logout a user - because there is always one user logged in the logout make the islogin = false
        public static bool Logout(int userId)
        {
            DBservicesUsers dbservicesUsers = new DBservicesUsers();

            dbservicesUsers.logOut(userId);

            return true;
        }
>>>>>>> Stashed changes

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
