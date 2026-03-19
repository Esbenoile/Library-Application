using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;
using static Perpustakaan.Discover;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Perpustakaan
{
    internal class DatabaseClass
    {
        public static SqlConnection DB;
        public static SqlCommand KodeBuku, NamaBuku, DekripsiBuku, SypnosisBuku, GambarBuku, BukuData, BookGenre, BookAuthor, BookQuantity, BookTotal;
        public static SqlCommand RegisterId, Username, Email, Password, Datetime, ProfilePicture, Balance, BanStatus;
        public static SqlCommand CommentId, UserId, BookId, CommentText, Rating, Timestamp, LikeCount, DislikeCount;
        public static SqlCommand RentalId, EndDate, RentalDate, RentalUserId, RentalBookId, CodeGeneration, StatusRental, StatusDeposit;
        public static SqlCommand MessageId, SenderId, ReceiverId, Content, SentAt, IsRead;
        public static SqlCommand FriendId, FriendUserId, Status, RequestDate;
        public static SqlCommand InventoryId, InventoryBookId, InventoryUserId;

        public class Comment
        {
            public int CommentId { get; set; }
            public int UserId { get; set; }
            public string BookId { get; set; }
            public string CommentText { get; set; }
            public int Rating { get; set; }
            public DateTime Timestamp { get; set; }
            public int LikeCount { get; set; }
            public int DislikeCount { get; set; }
        }

        public class Book
        {
            public string BookId { get; set; }
            public string BookTitle { get; set; }
            public string BookDescription { get; set; }
            public string BookPublisher { get; set; }
            public byte[] BookImageCover { get; set; }
            public string BookGenre { get; set; }
            public string BookAuthor { get; set; }
            public int BookQuantity { get; set; }
            public int BookTotal { get; set; }
        }

        public class Register
        {
            public int RegisterId { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public DateTime Datetime { get; set; }
            public byte[] ProfilePicture { get; set; }
            public decimal? Balance { get; set; }
            public bool BanStatus { get; set; }
        }

        public class Rental
        {
            public int RentalId { get; set; }
            public int RentalUserId { get; set; }
            public string RentalBookId { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime RentalDate { get; set; }
            public string CodeGeneration { get; set; }
            public bool StatusRental { get; set; }   
            public bool StatusDeposit { get; set; }
        }

        public class Message
        {
            public int MessageId { get; set; }
            public int SenderId { get; set; }
            public int ReceiverId { get; set; }
            public string Content { get; set; }
            public DateTime SentAt { get; set; }
            public bool IsRead { get; set; }
        }

        public class Friend
        {
            public int FriendId { get; set; }
            public int UserId { get; set; }
            public int FriendUserId { get; set; }
            public string Status { get; set; } 
            public DateTime RequestDate { get; set; }
        }

        public class Inventory
        {
            public int InventoryId { get; set; }
            public string InventoryBookId { get; set; }
            public int InventoryUserId { get; set; }
        }



        public static void BukaDB(string databaseAccess)
        {
            DB = new SqlConnection($"Data Source=(local); Initial Catalog=Database_Library; User ID=sa; Password=123456");
            DB.Open();

            if (databaseAccess == "book")
            {
                KodeBuku = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_id", DB);
                NamaBuku = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_title", DB);
                DekripsiBuku = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_description", DB);
                SypnosisBuku = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_publisher", DB);
                GambarBuku = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_image_cover", DB);
                BookGenre = new SqlCommand("SELECT * FROM" + databaseAccess + " ORDER BY book_genre", DB);
                BookAuthor = new SqlCommand("SELECT * FROM" + databaseAccess + " ORDER BY book_writer", DB);
                BookQuantity = new SqlCommand("SELECT * FROM" + databaseAccess + " ORDER BY book_quantity", DB);
                BookTotal = new SqlCommand("SELECT * FROM" + databaseAccess + " ORDER BY book_total", DB);
            }
            else if (databaseAccess == "users")
            {
                RegisterId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY user_id", DB);
                Username = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY username", DB);
                Email = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY email", DB);
                Password = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY password", DB);
                Datetime = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY created_at", DB);
                ProfilePicture = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY profile_picture", DB);
                Balance = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY balance", DB);
                BanStatus = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY status", DB);
            }
            else if (databaseAccess == "Comments")
            {
                CommentId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY comment_id", DB);
                UserId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY user_id", DB);
                BookId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_id", DB);
                CommentText = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY comment_text", DB);
                Rating = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY rating", DB);
                Timestamp = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY timestamp", DB);
                LikeCount = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY like_count", DB);
                DislikeCount = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY dislike_count", DB);
            } else if (databaseAccess == "Rental")
            {
                RentalId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY rental_id", DB);
                UserId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY user_id", DB);
                BookId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_id", DB);
                EndDate = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY end_date", DB);
                RentalDate = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY rental_date", DB);
                CodeGeneration = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY code_generation", DB);
                StatusRental = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY status", DB);
                StatusDeposit = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY deposit_status", DB);
            }
            else if (databaseAccess == "Messages")
            {
                MessageId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY message_id", DB);
                SenderId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY sender_id", DB);
                ReceiverId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY receiver_id", DB);
                Content = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY content", DB);
                SentAt = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY sent_at", DB);
                IsRead = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY is_read", DB);
            }
            else if (databaseAccess == "Friends")
            {
                FriendId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY friend_id", DB);
                UserId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY user_id", DB);
                FriendUserId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY friend_user_id", DB);
                Status = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY status", DB);
                RequestDate = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY request_date", DB);
            }
            else if (databaseAccess == "inventory")
            {
                InventoryId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY inventory_id", DB);
                InventoryBookId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY book_id", DB);
                InventoryUserId = new SqlCommand("SELECT * FROM " + databaseAccess + " ORDER BY user_id", DB);
            }


        }

        public static void TutupDB(string databaseAccess)
        {
            if (databaseAccess == "book")
            {
                KodeBuku.Dispose();
                NamaBuku.Dispose();
                DekripsiBuku.Dispose();
                SypnosisBuku.Dispose();
                GambarBuku.Dispose();
                BookGenre.Dispose();
                BookQuantity.Dispose();
                BookTotal.Dispose();
            }
            else if (databaseAccess == "users")
            {
                RegisterId.Dispose();
                Username.Dispose();
                Email.Dispose();
                Password.Dispose();
                Datetime.Dispose();
                ProfilePicture.Dispose();
                Balance.Dispose();
                BanStatus.Dispose();
            }
            else if (databaseAccess == "Comments")
            {
                CommentId.Dispose();
                UserId.Dispose();
                BookId.Dispose();
                CommentText.Dispose();
                Rating.Dispose();
                Timestamp.Dispose();
                LikeCount.Dispose();
                DislikeCount.Dispose();
            }
            else if (databaseAccess == "Rental")
            {
                RentalId.Dispose();
                UserId.Dispose();
                BookId.Dispose();
                EndDate.Dispose();
                RentalDate.Dispose();
                CodeGeneration.Dispose();
                StatusRental.Dispose();
                StatusDeposit.Dispose();
            }
            else if (databaseAccess == "Friends")
            {
                FriendId.Dispose();
                UserId.Dispose();
                FriendUserId.Dispose();
                Status.Dispose();
                RequestDate.Dispose();
            }
            else if (databaseAccess == "Messages")
            {
                MessageId.Dispose();
                SenderId.Dispose();
                ReceiverId.Dispose();
                Content.Dispose();
                SentAt.Dispose();
                IsRead.Dispose();
            }
            else if (databaseAccess == "inventory")
            {
                InventoryId.Dispose();
                InventoryBookId.Dispose();
                InventoryUserId.Dispose();
            }

            DB.Close();
            DB.Dispose();
        }
        public static void AddNewComment(string ParamUserId, string ParamBookId, string ParamCommentText, string ParamRating, string ParamLikeCount, string ParamDislikeCount)
        {
            try
            {
                string checkBookIdCommandText = "SELECT COUNT(1) FROM book WHERE book_id = @book_id";
                using (SqlCommand checkCommand = new SqlCommand(checkBookIdCommandText, DB))
                {
                    checkCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    int bookExists = (int)checkCommand.ExecuteScalar();

                    if (bookExists == 0)
                    {
                        return;
                    }
                }

                string commandText = @"
            INSERT INTO Comments (user_id, book_id, comment_text, rating, timestamp, like_count, dislike_count)
            VALUES (@user_id, @book_id, @comment_text, @rating, @timestamp, @like_count, @dislike_count)";

                using (SqlCommand command = new SqlCommand(commandText, DB))
                {
                    command.Parameters.AddWithValue("@user_id", ParamUserId);
                    command.Parameters.AddWithValue("@book_id", ParamBookId);
                    command.Parameters.AddWithValue("@comment_text", ParamCommentText);
                    command.Parameters.AddWithValue("@rating", ParamRating);
                    command.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    command.Parameters.AddWithValue("@like_count", ParamLikeCount);
                    command.Parameters.AddWithValue("@dislike_count", ParamDislikeCount);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error adding comment: {ex.Message}");
            }
        }

        public static void AddNewBook(string ParamBookId, string ParamBookTitle, string ParamBookDescription, string ParamBookPublisher, string ParamBookWriter, string ParamBookGenre, int ParamBookQuantity, int ParamBookTotal, Image ParamImage)
        {
            try
            {
                string commandText = @"
            INSERT INTO book (book_ID, book_Title, book_description, book_publisher, book_genre, book_writer, book_quantity, book_total, book_image_cover)
            VALUES (@book_ID, @book_Title, @book_Description, @book_Publisher, @book_Genre, @book_Writer, @book_quantity, @book_total, @book_image_cover)";

                using (SqlCommand command = new SqlCommand(commandText, DB))
                {
                    command.Parameters.AddWithValue("@Book_ID", ParamBookId);
                    command.Parameters.AddWithValue("@Book_Title", ParamBookTitle);
                    command.Parameters.AddWithValue("@Book_Description", ParamBookDescription);
                    command.Parameters.AddWithValue("@Book_Publisher", ParamBookPublisher);
                    command.Parameters.AddWithValue("@Book_Genre", ParamBookGenre);
                    command.Parameters.AddWithValue("@Book_Writer", ParamBookWriter);
                    command.Parameters.AddWithValue("@Book_Quantity", ParamBookQuantity);
                    command.Parameters.AddWithValue("@Book_Total", ParamBookTotal);

                    if (ParamImage != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ParamImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png); 
                            byte[] imageBytes = ms.ToArray(); 
                            command.Parameters.AddWithValue("@Book_Image_Cover", imageBytes);
                        }
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Book_Image_Cover", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }

                //Console.WriteLine("Data berhasil disimpan!");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error adding book: {ex.Message}");
            }
        }

        public static void UpdateBook(string bookId, string bookTitle, string bookDescription, string bookPublisher, string bookWriter, string bookGenre, int bookQuantity, int bookTotal, Image bookImage)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookId)) throw new ArgumentException("Book ID cannot be null or empty.");

                string commandText = @"
                    UPDATE book 
                    SET 
                        book_Title = @Book_Title,
                        book_Description = @Book_Description,
                        book_Publisher = @Book_Publisher,
                        book_Genre = @Book_Genre,
                        book_Writer = @Book_Writer,
                        book_Quantity = @Book_Quantity,
                        book_Total = @Book_Total,
                        book_Image_Cover = @Book_Image_Cover
                    WHERE 
                        book_ID = @Book_ID";

                using (SqlCommand command = new SqlCommand(commandText, DB))
                {
                    command.Parameters.AddWithValue("@Book_ID", bookId);
                    command.Parameters.AddWithValue("@Book_Title", bookTitle ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Book_Description", bookDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Book_Publisher", bookPublisher ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Book_Genre", bookGenre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Book_Writer", bookWriter ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Book_Quantity", bookQuantity);
                    command.Parameters.AddWithValue("@Book_Total", bookTotal);

                    if (bookImage != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bookImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            command.Parameters.AddWithValue("@Book_Image_Cover", ms.ToArray());
                        }
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Book_Image_Cover", DBNull.Value);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //Console.WriteLine("Book updated successfully.");
                    }
                    else
                    {
                        //Console.WriteLine("No rows were updated. Please check the book ID.");
                    }
                }
            }
            catch (ArgumentException argEx)
            {
                //Console.WriteLine($"Validation error: {argEx.Message}");
            }
        }


        public static void AddNewRental(string ParamBookId, string ParamUserId, DateTime ParamEndDate, DateTime ParamRentDate, string generationCode, DateTime ParamDate)
        {
            try
            {
                string checkBookIdCommandText = "SELECT COUNT(1) FROM book WHERE book_id = @book_id";
                using (SqlCommand checkCommand = new SqlCommand(checkBookIdCommandText, DB))
                {
                    checkCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    int bookExists = (int)checkCommand.ExecuteScalar();

                    if (bookExists == 0)
                    {
                        //Console.WriteLine("Error: The provided book_id does not exist in the book table.");
                        return;
                    }
                }

                string findAvailableRentalIdCommandText = @"
            SELECT MIN(t1.rental_id + 1) AS next_id
            FROM Rental t1
            LEFT JOIN Rental t2 ON t1.rental_id + 1 = t2.rental_id
            WHERE t2.rental_id IS NULL";

                int rentalId;
                using (SqlCommand findIdCommand = new SqlCommand(findAvailableRentalIdCommandText, DB))
                {
                    object result = findIdCommand.ExecuteScalar();
                    rentalId = result != DBNull.Value ? Convert.ToInt32(result) : 1; 
                }

                string insertRentalCommandText = @"
            INSERT INTO Rental (rental_id, book_id, user_id, end_date, rental_date, code_generation, status, session, deposit_status)
            VALUES (@rental_id, @book_id, @user_id, @end_date, @rental_date, @code_generation, @status, @session, @deposit_status)";

                using (SqlCommand insertCommand = new SqlCommand(insertRentalCommandText, DB))
                {
                    insertCommand.Parameters.AddWithValue("@rental_id", rentalId);
                    insertCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    insertCommand.Parameters.AddWithValue("@user_id", ParamUserId);
                    insertCommand.Parameters.AddWithValue("@end_date", ParamEndDate);
                    insertCommand.Parameters.AddWithValue("@rental_date", ParamRentDate);
                    insertCommand.Parameters.AddWithValue("@code_generation", generationCode);
                    insertCommand.Parameters.AddWithValue("@status", false);
                    insertCommand.Parameters.AddWithValue("@session", ParamDate);
                    insertCommand.Parameters.AddWithValue("@deposit_status", false);

                    insertCommand.ExecuteNonQuery();
                }

                //Console.WriteLine($"Successfully added rental with rental_id: {rentalId}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error adding rental: {ex.Message}");
            }
        }



        public static void AddNewInventory(string ParamBookId, int ParamUserId)
        {
            try
            {
                string checkBookIdCommandText = "SELECT COUNT(1) FROM book WHERE book_id = @book_id";
                using (SqlCommand checkCommand = new SqlCommand(checkBookIdCommandText, DB))
                {
                    checkCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    int bookExists = (int)checkCommand.ExecuteScalar();

                    if (bookExists == 0)
                    {
                        return;
                    }
                }

                string findAvailableInventoryIdCommandText = @"
        SELECT ISNULL(MAX(inventory_id), 0) + 1
        FROM Inventory";

                int inventoryId;
                using (SqlCommand findIdCommand = new SqlCommand(findAvailableInventoryIdCommandText, DB))
                {
                    object result = findIdCommand.ExecuteScalar();
                    inventoryId = result != DBNull.Value ? Convert.ToInt32(result) : 1;
                }

                string insertInventoryCommandText = @"
        INSERT INTO Inventory (inventory_id, book_id, user_id)
        VALUES (@inventory_id, @book_id, @user_id)";

                using (SqlCommand insertCommand = new SqlCommand(insertInventoryCommandText, DB))
                {
                    insertCommand.Parameters.AddWithValue("@inventory_id", inventoryId);
                    insertCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    insertCommand.Parameters.AddWithValue("@user_id", ParamUserId);

                    insertCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {

            }
        }




        public static void DeleteInventory(string ParamBookId, string ParamUserId, int ParamInventoryId)
        {
            try
            {
                string deleteRentalCommandText = "DELETE FROM inventory WHERE inventory_id = @inventory_id AND book_id = @book_id AND user_id = @user_id";

                using (SqlCommand deleteCommand = new SqlCommand(deleteRentalCommandText, DB))
                {
                    deleteCommand.Parameters.AddWithValue("@inventory_id", ParamInventoryId);
                    deleteCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    deleteCommand.Parameters.AddWithValue("@user_id", ParamUserId);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Successfully deleted rental with inventory_id: {ParamInventoryId}");
                    }
                    else
                    {
                        Console.WriteLine("No rental found with the specified details.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting rental: {ex.Message}");
            }
        }



        public static void DeleteRental(string ParamBookId, string ParamUserId, int ParamRentalId)
        {
            try
            {
                string deleteRentalCommandText = "DELETE FROM Rental WHERE rental_id = @rental_id AND book_id = @book_id AND user_id = @user_id";

                using (SqlCommand deleteCommand = new SqlCommand(deleteRentalCommandText, DB))
                {
                    deleteCommand.Parameters.AddWithValue("@rental_id", ParamRentalId);
                    deleteCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                    deleteCommand.Parameters.AddWithValue("@user_id", ParamUserId);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Successfully deleted rental with rental_id: {ParamRentalId}");
                    }
                    else
                    {
                        Console.WriteLine("No rental found with the specified details.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting rental: {ex.Message}");
            }
        }




        public static bool CheckLoginCredentials(string email, string password, string sqlCmd)
        {
            try
            {
                SqlCommand command = new SqlCommand(sqlCmd, DB);
                command.Parameters.AddWithValue("@email", email);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader.GetString(reader.GetOrdinal("password"));
                        return storedPassword == password;
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error during login: {ex.Message}");
            }
            return false;
        }


        public static List<Book> BacaDataBuku(string sqlCmd)
        {
            List<Book> books = new List<Book>();

            try
            {
                SqlCommand paginatedQuery = new SqlCommand(sqlCmd, DB);

                using (SqlDataReader reader = paginatedQuery.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book
                        {
                            BookId = reader.GetString(reader.GetOrdinal("book_id")),
                            BookTitle = reader.GetString(reader.GetOrdinal("book_title")),
                            BookDescription = reader.GetString(reader.GetOrdinal("book_description")),
                            BookAuthor = reader.GetString(reader.GetOrdinal("book_writer")),
                            BookPublisher = reader.GetString(reader.GetOrdinal("book_publisher")),
                            BookImageCover = reader.GetSqlBinary(reader.GetOrdinal("book_image_cover")).Value, 
                            BookGenre = reader.GetString(reader.GetOrdinal("book_genre")),
                            BookQuantity = reader.GetInt32(reader.GetOrdinal("book_quantity")),
                            BookTotal = reader.GetInt32(reader.GetOrdinal("book_total"))
                        };

                        books.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error reading data: {ex.Message}");
            }

            return books;
        }

        public static List<Comment> BacaDataComment(string sqlCmd, Dictionary<string, object> parameters = null)
        {
            List<Comment> comments = new List<Comment>();

            try
            {
                SqlCommand command = new SqlCommand(sqlCmd, DB);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Comment comment = new Comment
                        {
                            CommentId = reader.GetInt32(reader.GetOrdinal("comment_id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                            BookId = reader.GetString(reader.GetOrdinal("book_id")),
                            CommentText = reader.GetString(reader.GetOrdinal("comment_text")),
                            Rating = reader.GetInt32(reader.GetOrdinal("rating")),
                            Timestamp = reader.GetDateTime(reader.GetOrdinal("timestamp")),
                            LikeCount = reader.GetInt32(reader.GetOrdinal("like_count")),
                            DislikeCount = reader.GetInt32(reader.GetOrdinal("dislike_count"))
                        };

                        comments.Add(comment);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error reading data: {ex.Message}");
            }

            return comments;
        }

        public static bool CanAddComment(int userId, string bookId)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Comments 
                WHERE user_id = @UserId AND book_id = @BookId";

            var parameters = new Dictionary<string, object>
            {
                { "@UserId", userId },
                { "@BookId", bookId }
            };

            using (SqlCommand command = new SqlCommand(query, DB))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                int commentCount = (int)command.ExecuteScalar();
                return commentCount < 3; 
            }
        }

        public static bool CanAddRent(int userId, string bookId)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Rental 
                WHERE user_id = @UserId AND book_id = @BookId";

            var parameters = new Dictionary<string, object>
            {
                { "@UserId", userId },
                { "@BookId", bookId }
            };

            using (SqlCommand command = new SqlCommand(query, DB))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                int rentCount = (int)command.ExecuteScalar();

                return rentCount == 0;
            }
        }


        public static bool CanAddInventory(int ParamUserId, string ParamBookId)
        {
            bool rentVarInven = false;

            try
            {

                string query = @"
                    SELECT COUNT(*) 
                    FROM inventory
                    WHERE user_id = @UserId AND book_id = @BookId";

                using (SqlCommand command = new SqlCommand(query, DB))
                {
                    command.Parameters.AddWithValue("@UserId", ParamUserId);
                    command.Parameters.AddWithValue("@BookId", ParamBookId);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        rentVarInven = false;
                    }
                    else
                    {
                        rentVarInven = true;
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return rentVarInven;
        }

        public static List<Rental> BacaDataRentalByUserId(string userId = null)
        {
            List<Rental> rentals = new List<Rental>();

            try
            {
                string sqlCmd = userId == null
                    ? "SELECT rental_id, book_id, user_id, end_date, rental_date, code_generation, status FROM Rental"
                    : "SELECT rental_id, book_id, user_id, end_date, rental_date, code_generation, status FROM Rental WHERE user_id = @user_id";

                using (SqlCommand command = new SqlCommand(sqlCmd, DB))
                {
                    if (userId != null)
                    {
                        command.Parameters.AddWithValue("@user_id", userId);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rental rental = new Rental
                            {
                                RentalId = reader.GetInt32(reader.GetOrdinal("rental_id")),
                                RentalBookId = reader.GetString(reader.GetOrdinal("book_id")),
                                RentalUserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("end_date")),
                                RentalDate = reader.GetDateTime(reader.GetOrdinal("rental_date")),
                                StatusRental = reader.GetBoolean(reader.GetOrdinal("status")),
                                CodeGeneration = reader.GetString(reader.GetOrdinal("code_generation"))
                            };

                            rentals.Add(rental);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error reading rental data: {ex.Message}");
            }

            return rentals;
        }

        public static List<Inventory> GetInventoryByBookIdAndUser(int userId)
        {
            List<Inventory> inventories = new List<Inventory>();

            try
            {
                // Single query to get both BookId and InventoryId for the given UserId
                using (SqlCommand command = new SqlCommand(
                    "SELECT book_id, inventory_id FROM inventory WHERE user_id = @UserId", DB))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inventory inventory = new Inventory
                            {
                                InventoryBookId = reader.GetString(reader.GetOrdinal("book_id")),
                                InventoryId = reader.GetInt32(reader.GetOrdinal("inventory_id"))
                            };

                            inventories.Add(inventory);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching inventory data: {ex.Message}");
            }

            return inventories;
        }




        public static List<Register> GetUsernameById(int userId)
        {
            List<Register> userLists = new List<Register>();

            try
            {
                using (SqlCommand userQuery = new SqlCommand("SELECT user_id, username, email, password, created_at, profile_picture, balance, status FROM users WHERE user_id = @UserId", DB))
                {
                    userQuery.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = userQuery.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Register userList = new Register
                            {
                                RegisterId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                Username = reader.GetString(reader.GetOrdinal("username")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Datetime = reader.GetDateTime(reader.GetOrdinal("created_at")),
                                ProfilePicture = reader.IsDBNull(reader.GetOrdinal("profile_picture"))
                                    ? null
                                    : (byte[])reader["profile_picture"],
                                Balance = reader.IsDBNull(reader.GetOrdinal("balance"))
                                    ? (decimal?)null
                                    : reader.GetDecimal(reader.GetOrdinal("balance")),
                                BanStatus = reader.GetBoolean(reader.GetOrdinal("status"))

                            };

                            userLists.Add(userList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading user data: {ex.Message}");
            }

            return userLists;
        }



        public static List<Friend> GetFriendsByUserId(int userId)
        {
            List<Friend> friendLists = new List<Friend>();

            try
            {
                using (SqlCommand friendQuery = new SqlCommand("SELECT friend_id, user_id, friend_user_id, status, request_date FROM friends WHERE user_id = @UserId OR friend_user_id = @UserId", DB))
                {
                    friendQuery.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = friendQuery.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Friend friend = new Friend
                            {
                                FriendId = reader.GetInt32(reader.GetOrdinal("friend_id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                FriendUserId = reader.GetInt32(reader.GetOrdinal("friend_user_id")),
                                Status = reader.GetString(reader.GetOrdinal("status")),
                                RequestDate = reader.GetDateTime(reader.GetOrdinal("request_date"))
                            };

                            friendLists.Add(friend);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading friend data: {ex.Message}");
            }

            return friendLists;
        }

        public static List<Message> GetMessagesBetweenUsers(int userId1, int userId2)
        {
            List<Message> messageLists = new List<Message>();

            try
            {
                using (SqlCommand messageQuery = new SqlCommand(
                    "SELECT message_id, sender_id, receiver_id, content, sent_at, is_read FROM messages " +
                    "WHERE (sender_id = @UserId1 AND receiver_id = @UserId2) OR (sender_id = @UserId2 AND receiver_id = @UserId1) " +
                    "ORDER BY sent_at", DB))
                {
                    messageQuery.Parameters.AddWithValue("@UserId1", userId1);
                    messageQuery.Parameters.AddWithValue("@UserId2", userId2);

                    using (SqlDataReader reader = messageQuery.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = new Message
                            {
                                MessageId = reader.GetInt32(reader.GetOrdinal("message_id")),
                                SenderId = reader.GetInt32(reader.GetOrdinal("sender_id")),
                                ReceiverId = reader.GetInt32(reader.GetOrdinal("receiver_id")),
                                Content = reader.GetString(reader.GetOrdinal("content")),
                                SentAt = reader.GetDateTime(reader.GetOrdinal("sent_at")),
                                IsRead = reader.GetBoolean(reader.GetOrdinal("is_read"))
                            };

                            messageLists.Add(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading message data: {ex.Message}");
            }

            return messageLists;
        }



        public static void AddNewRequest(int ParamSenderId, int ParamRecieverId, string Status, DateTime ParamRequestDate, string GenerationCode, string ResponseDate)
        {
            try
            {
                //string checkBookIdCommandText = "SELECT COUNT(1) FROM friendrequests WHERE book_id = @book_id";
                //using (SqlCommand checkCommand = new SqlCommand(checkBookIdCommandText, DB))
                //{
                //    checkCommand.Parameters.AddWithValue("@book_id", ParamBookId);
                //    int bookExists = (int)checkCommand.ExecuteScalar();

                //    if (bookExists == 0)
                //    {
                //        //Console.WriteLine("Error: The provided book_id does not exist in the book table.");
                //        return;
                //    }
                //}

                string findAvailableRentalIdCommandText = @"
            SELECT MIN(t1.request_id + 1) AS next_id
            FROM friendrequests t1
            LEFT JOIN Rental t2 ON t1.request_id + 1 = t2.request_id
            WHERE t2.request_id IS NULL";

                int request_id;
                using (SqlCommand findIdCommand = new SqlCommand(findAvailableRentalIdCommandText, DB))
                {
                    object result = findIdCommand.ExecuteScalar();
                    request_id = result != DBNull.Value ? Convert.ToInt32(result) : 1;
                }

                string insertRentalCommandText = @"
            INSERT INTO friendrequests (request_id, sender_id, receiver_id, status, request_date, response_date)
            VALUES (@request_id, @sender_id, @receiver_id, @status, @request_date, @response_date";
                using (SqlCommand insertCommand = new SqlCommand(insertRentalCommandText, DB))
                {
                    insertCommand.Parameters.AddWithValue("@request_id", request_id);
                    insertCommand.Parameters.AddWithValue("@sender_id", ParamSenderId);
                    insertCommand.Parameters.AddWithValue("@receiver_id", ParamRecieverId);
                    insertCommand.Parameters.AddWithValue("@status", Status);
                    insertCommand.Parameters.AddWithValue("@request_date", ParamRequestDate);
                    insertCommand.Parameters.AddWithValue("@response_date", GenerationCode);
                    insertCommand.ExecuteNonQuery();
                }

                //Console.WriteLine($"Successfully added rental with rental_id: {rentalId}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error adding rental: {ex.Message}");
            }
        }





        public static int GetTotalBooks(string datatype, string databaseAccess, string keyword = null)
        {
            int totalBooks = 0;

            try
            {
                DatabaseClass.BukaDB(databaseAccess);

                string query = "SELECT COUNT(*) FROM " + databaseAccess;
                SqlCommand totalBooksCommand = new SqlCommand(query, DB);

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += $" WHERE CAST({datatype} AS VARCHAR(MAX)) = @keyword";
                    totalBooksCommand.CommandText = query;
                    totalBooksCommand.Parameters.AddWithValue("@keyword", keyword);
                }

                totalBooks = (int)totalBooksCommand.ExecuteScalar();
                DatabaseClass.TutupDB(databaseAccess);
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error counting books: {ex.Message}");
            }

            return totalBooks;
        }

        public static bool IsUserExists(string variable, string variableKey, string sqlCmd)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(sqlCmd, DB))
                {
                    command.Parameters.AddWithValue(variableKey, variable);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void SaveProfilePicture(int userId, Image profilePicture)
        {
            try
            {
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePicture.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imageData = ms.ToArray();
                }

                string commandText = "UPDATE users SET profile_picture = @ProfilePicture WHERE user_id = @UserId";

                using (SqlCommand command = new SqlCommand(commandText, DB))
                {
                    command.Parameters.AddWithValue("@ProfilePicture", imageData);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }

                //Console.WriteLine("Profile picture saved successfully.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error saving profile picture: {ex.Message}");
            }
        }

        public static Image GetProfilePicture(int userId)
        {
            string commandText = "SELECT profile_picture FROM users WHERE user_id = @UserId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@UserId", userId); 

                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    byte[] imageData = (byte[])result;

                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        return Image.FromStream(ms); 
                    }
                }
                else
                {
                    //Console.WriteLine("No profile picture found.");
                    return null; 
                }
            }
        }

        public static long GetUserBalance(int userId)
        {
            string commandText = "SELECT balance FROM users WHERE user_id = @UserId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt64(result); 
                }
                else
                {
                    //Console.WriteLine("Balance not found or user does not exist.");
                    return 0;
                }
            }
        }

        public static void UpdateUserBalance(int userId, long newBalance)
        {
            string commandText = "UPDATE users SET balance = @Balance WHERE user_id = @UserId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@Balance", newBalance);
                command.Parameters.AddWithValue("@UserId", userId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //Console.WriteLine("Balance updated successfully.");
                }
                else
                {
                    //Console.WriteLine("Failed to update balance. User may not exist.");
                }
            }
        }


        public static void UpdateUserStatus(int userId)
        {
            string commandText = "UPDATE users SET status = @Status WHERE user_id = @UserId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@Status", true);
                command.Parameters.AddWithValue("@UserId", userId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Status updated successfully
                }
                else
                {
                    // Failed to update status. User may not exist.
                }
            }
        }


        public static void UpdateUserStatusWhite(int userId)
        {
            string commandText = "UPDATE users SET status = @Status WHERE user_id = @UserId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@Status", false);
                command.Parameters.AddWithValue("@UserId", userId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Status updated successfully
                }
                else
                {
                    // Failed to update status. User may not exist.
                }
            }
        }

        public static int GetBookQuantity(string bookId)
        {
            string commandText = "SELECT book_quantity FROM book WHERE book_id = @BookId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@BookId", bookId);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    //Console.WriteLine("Book not found or quantity not available.");
                    return -1;
                }
            }
        }

        public static void DecreaseBookQuantity(string bookId, int amount)
        {
            int currentQuantity = GetBookQuantity(bookId);

            string commandText = "UPDATE book SET book_quantity = book_quantity - @Amount WHERE book_id = @BookId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@BookId", bookId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //Console.WriteLine("Book quantity decreased successfully.");
                }
                else
                {
                    //Console.WriteLine("Failed to decrease book quantity. Book may not exist.");
                }
            }
        }

        public static void RedeemCode(int rentalId)
        {
            string commandText = "UPDATE Rental SET status = @Status WHERE rental_id = @RentalId";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@RentalId", rentalId);
                command.Parameters.AddWithValue("@Status", true); 

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //Console.WriteLine("Book quantity decreased and rental status updated successfully.");
                }
                else
                {
                    //Console.WriteLine("Failed to update the rental. Rental ID may not exist.");
                }
            }
        }


        public static void RegisterUser(string username, string email, string password)
        {
            try
            {
                string commandText = "INSERT INTO users (username, email, password, created_at, status) VALUES ('"
                    + username + "', '"
                    + email + "', '"
                    + password + "', '"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                    + false + "')";

                using (SqlCommand command = new SqlCommand(commandText, DB))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error registering user: {ex.Message}");
            }
        }

        public static int FetchUserId(string email, string password)
        {
            int userId = -1; 

            string commandText = @"
            SELECT user_id 
            FROM users 
            WHERE email = @email 
            AND password = @password;";

            using (SqlCommand command = new SqlCommand(commandText, DB))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }

            return userId;
        }
    }
}