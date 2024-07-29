using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.Common;
using serverSide.BL;
using System.Dynamic;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservicesUsers
{

    public DBservicesUsers() { }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

   
    //--------------------------------------------------------------------------------------------------
    // This method adds a new user to the users table 
    //--------------------------------------------------------------------------------------------------
    public int AddNewUser(IUser user )
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureAddNewUser("AddNewIUser", con, user);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to add new user
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedureAddNewUser(String spName, SqlConnection con, IUser user)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@username", user.UserName);

        cmd.Parameters.AddWithValue("@email", user.EMail);

        cmd.Parameters.AddWithValue("@password", user.Password);

        return cmd;
    }


    //--------------------------------------------------------------------------------------------------
    // login user - return user id
    //--------------------------------------------------------------------------------------------------
    public object logInUser(IUser user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedurelogInUser("LoginIUser", con, user);             // create the command

        dynamic userDetails = new ExpandoObject(); // create a dynamic object 
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                userDetails.userId = Convert.ToInt32(dataReader["userId"]);
                userDetails.userName = Convert.ToString(dataReader["userName"]);
            }
            return userDetails;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to login user
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedurelogInUser(String spName, SqlConnection con, IUser user)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", user.EMail);

        cmd.Parameters.AddWithValue("@password", user.Password);

        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    // This method logout the log in user
    //--------------------------------------------------------------------------------------------------
    public void logOut(int userId)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureLogOut("LogoutIUser", con, userId);             // create the command


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to logout user
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedureLogOut(String spName, SqlConnection con, int userId)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@userId", userId);

        return cmd;
    }

   
    //--------------------------------------------------------------------------------------------------
    // This method add New book To user
    //--------------------------------------------------------------------------------------------------

    public int addNewbookToUser(int userID, int bookID)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureaddNewbookToUser("addNewbookToUser", con, userID, bookID);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to add new book to user
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedureaddNewbookToUser(String spName, SqlConnection con, int userId, int bookId)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@userid", userId);

        cmd.Parameters.AddWithValue("@bookid", bookId);


        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    // This method show all books from specific user
    //--------------------------------------------------------------------------------------------------

    public List<Book> GetBooksPerUser(int userId)

    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureGetBooksPerUser("GetBooksPerUser", con, userId);             // create the command


        List<Book> userBooks = new List<Book>();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Book book = new Book();
                book.Id = Convert.ToInt32(dataReader["id"]);
                book.Title = Convert.ToString(dataReader["title"]);
                book.SubTitle = Convert.ToString(dataReader["subTitle"]);
                book.IsEbook = Convert.ToByte(dataReader["isEbook"]);
                book.IsActive = Convert.ToByte(dataReader["isActive"]);
                book.IsAvailable = Convert.ToByte(dataReader["isAvailable"]); 
                book.Price = (float)Convert.ToDouble(dataReader["price"]); 
                book.Category = Convert.ToString(dataReader["category"]); 
                book.SmallThumbnail = Convert.ToString(dataReader["smallThumbnail"]);
                book.Thumbnail = Convert.ToString(dataReader["thumbnail"]); 
                book.NumOfPages = Convert.ToInt32(dataReader["numOfPages"]); 
                book.Description = Convert.ToString(dataReader["description"]); 
                book.PreviewLink = Convert.ToString(dataReader["previewLink"]); 
                book.PublishDate = Convert.ToString(dataReader["publishDate"]); 
                book.FirstAuthorName = Convert.ToString(dataReader["firstAuthor"]); 
                book.SecondAuthorName = Convert.ToString(dataReader["secondAuthor"]); 
                book.NumOfReviews = Convert.ToInt32(dataReader["numOfReviews"]); 
                book.Rating = (float)Convert.ToDouble(dataReader["rating"]);
                book.TextSnippet = Convert.ToString(dataReader["textSnippet"]);
                userBooks.Add(book);

            }
            return userBooks;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to get books per user
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedureGetBooksPerUser(String spName, SqlConnection con, int userId)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@userId", userId);

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to mark book as read by user 
    //---------------------------------------------------------------------------------


    public int readBookByUser(int bookId,int userId)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedurereadBookByUser("ReadBook", con,bookId, userId);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure to mark book as read by user
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedurereadBookByUser(String spName, SqlConnection con, int bookId,int userId)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@bookId",bookId);

        cmd.Parameters.AddWithValue("@userId",userId);

        return cmd;
    }

}
