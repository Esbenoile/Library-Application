
IF OBJECT_ID('dbo.book', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.book;
END


CREATE TABLE book (
    book_id VarChar(15),
    book_title VarChar(40),
    book_description TEXT,
    book_publisher TEXT,
    book_image_cover TEXT, 
    book_genre TEXT,
	book_writer TEXT,
	Primary Key(book_id)
);
