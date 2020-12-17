USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username nvarchar(50) NOT NULL,
	password_hash nvarchar(200) NOT NULL,
	salt nvarchar(200) NOT NULL,
	user_role nvarchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE users_collection (
	collection_id int IDENTITY(1,1) NOT NULL, 
	user_id int NOT NULL,
	collection_name nvarchar(160) NOT NULL,
	is_private bit NOT NULL DEFAULT 0,
	CONSTRAINT PK_users_collection PRIMARY KEY (collection_id)
)

CREATE TABLE collections(
	collection_id int NOT NULL,
	user_id int NOT NULL,
	comic_id int NOT NULL
	CONSTRAINT PK_collections PRIMARY KEY (collection_id, user_id, comic_id),
	CONSTRAINT FK_users_collections FOREIGN KEY (collection_id) REFERENCES users_collection (collection_id),
)

CREATE TABLE comics (
	comic_id int IDENTITY(1,1) NOT NULL,
	title nvarchar (200) NOT NULL,
	comic_desc nvarchar (500),
	publisher nvarchar (100) NOT NULL,
	maincharacter nvarchar (200),
	edition int,
	CONSTRAINT PK_comics PRIMARY KEY (comic_id)
)

CREATE TABLE comic_character (
	comic_id int NOT NULL,
	character_id int NOT NULL
	CONSTRAINT FK_comic_character_comics FOREIGN KEY (comic_id) REFERENCES comics (comic_id),	
)

CREATE TABLE characters (
	character_id int IDENTITY (1,1) NOT NULL, 
	character_name nvarchar (200) NOT NULL
	CONSTRAINT PK_characters PRIMARY KEY (character_id)
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('userP', 'Ec+TLVhEZTWDGYPziZUZkiuQp6U=', 'q501sO1EB6s=','Premium');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('userS', 'mvlintodiEsK04IVv40c9yiBn5U=', 'WRZdZVCw+9Q=', 'Standard');


ALTER TABLE collections 
ADD CONSTRAINT FK_collections_comics FOREIGN KEY (comic_id) REFERENCES comics (comic_id)

ALTER TABLE comic_character 
ADD CONSTRAINT FK_comic_character_characters FOREIGN KEY (character_id) REFERENCES characters (character_id)


GO



