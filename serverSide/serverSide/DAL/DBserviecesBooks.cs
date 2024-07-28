using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.Common;
using serverSide.BL;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservicesBooks
{

    public DBservicesBooks() { }

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
    // This method adds a new book to the books table 
    //--------------------------------------------------------------------------------------------------
    public int AddNewBook(Book book)
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

        cmd = CreateCommandWithStoredProcedureAddNewBook("AddNewBook", con, book);             // create the command

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
    // Create the SqlCommand using a stored procedure to add new book
    //---------------------------------------------------------------------------------

    private SqlCommand CreateCommandWithStoredProcedureAddNewBook(String spName, SqlConnection con, Book book)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@title", book.Title);

        cmd.Parameters.AddWithValue("@subTitle", book.SubTitle);

        cmd.Parameters.AddWithValue("@isEbook", book.IsEbook);

        cmd.Parameters.AddWithValue("@price", book.Price);

        cmd.Parameters.AddWithValue("@category", book.Category);

        cmd.Parameters.AddWithValue("@smallThumbnail", book.SmallThumbnail);

        cmd.Parameters.AddWithValue("@Thumbnail", book.Thumbnail);

        cmd.Parameters.AddWithValue("@numOfPages", book.NumOfPages);

        cmd.Parameters.AddWithValue("@description", book.Description);

        cmd.Parameters.AddWithValue("@previewLink", book.PreviewLink);

        cmd.Parameters.AddWithValue("@publishedDate", book.PublishDate);

        cmd.Parameters.AddWithValue("@eirstAuthor", book.FirstAuthorName);

        cmd.Parameters.AddWithValue("@secondAuthor", book.SecondAuthorName);

        cmd.Parameters.AddWithValue("@rating", book.Rating);

        cmd.Parameters.AddWithValue("@numOfReviews", book.NumOfReviews);

        cmd.Parameters.AddWithValue("@textSnippet", book.TextSnippet);


        return cmd;
    }

}

