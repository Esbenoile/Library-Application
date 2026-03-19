-- Drop existing tables if they exist
IF OBJECT_ID('dbo.CommentLikes', 'U') IS NOT NULL
    DROP TABLE dbo.CommentLikes;

IF OBJECT_ID('dbo.Comments', 'U') IS NOT NULL
    DROP TABLE dbo.Comments;

CREATE TABLE Comments (
    comment_id INT IDENTITY(1,1) PRIMARY KEY, 
    user_id INT NOT NULL,
    book_id VARCHAR(15) NOT NULL,
    comment_text TEXT NOT NULL,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    timestamp DATETIME DEFAULT GETDATE(),
    like_count INT DEFAULT 0,
    dislike_count INT DEFAULT 0,
    FOREIGN KEY (user_id) REFERENCES dbo.users(user_id),
    FOREIGN KEY (book_id) REFERENCES dbo.book(book_id)  
);

CREATE TABLE CommentLikes (
    comment_id INT NOT NULL,  
    user_id INT NOT NULL,
    like_status INT CHECK (like_status IN (0, 1)), 
    PRIMARY KEY (comment_id, user_id), 
    FOREIGN KEY (comment_id) REFERENCES Comments(comment_id),  
    FOREIGN KEY (user_id) REFERENCES dbo.users(user_id)  
);


ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_User 
FOREIGN KEY (user_id) REFERENCES dbo.users(user_id);

ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Book 
FOREIGN KEY (book_id) REFERENCES dbo.book(book_id);

-- Add foreign keys to the CommentLikes table
ALTER TABLE CommentLikes
ADD CONSTRAINT FK_CommentLikes_Comment 
FOREIGN KEY (comment_id) REFERENCES Comments(comment_id);

ALTER TABLE CommentLikes
ADD CONSTRAINT FK_CommentLikes_User 
FOREIGN KEY (user_id) REFERENCES dbo.users(user_id);
