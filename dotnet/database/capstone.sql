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
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE collections(
	collection_id int IDENTITY(1,1) NOT NULL,
	is_private bit NOT NULL DEFAULT 0,
	user_id int NOT NULL,
	comic_id int NOT NULL
	CONSTRAINT PK_collections PRIMARY KEY (collection_id, user_id, comic_id)
)
CREATE TABLE comics (
comic_id int IDENTITY(1,1) NOT NULL,
title varchar (200) NOT NULL,
comic_desc varchar (500),
publisher varchar (100) NOT NULL,
)

CREATE TABLE comic_creator (
comic_id int NOT NULL,
creator_id int NOT NULL
)

CREATE TABLE creators (
creator_id int IDENTITY (1,1) NOT NULL,
creator_name varchar (200)
)

CREATE TABLE comic_character (
comic_id int NOT NULL,
character_id int NOT NULL
)

CREATE TABLE characters (
character_id int IDENTITY (1,1) NOT NULL, 
character_name varchar (200) NOT NULL
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO


