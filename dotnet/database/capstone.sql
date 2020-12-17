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
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Premium', 'Ec+TLVhEZTWDGYPziZUZkiuQp6U=', 'q501sO1EB6s=','Premium');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Standard', 'mvlintodiEsK04IVv40c9yiBn5U=', 'WRZdZVCw+9Q=', 'Standard');


ALTER TABLE collections 
ADD CONSTRAINT FK_collections_comics FOREIGN KEY (comic_id) REFERENCES comics (comic_id)

ALTER TABLE comic_character 
ADD CONSTRAINT FK_comic_character_characters FOREIGN KEY (character_id) REFERENCES characters (character_id)

INSERT INTO users_collection (user_id, collection_name, is_private) VALUES('3', 'FIRST VOLUMES', '1');
INSERT INTO users_collection (user_id, collection_name, is_private) VALUES('3', 'MY COMICS', '0');
INSERT INTO users_collection (user_id, collection_name, is_private) VALUES('4', 'BATMAN', '0');
INSERT INTO users_collection (user_id, collection_name, is_private) VALUES('4', 'SPIDER-MAN', '0');
INSERT INTO users_collection (user_id, collection_name, is_private) VALUES('4', 'BLACK PANTHER', '0');
INSERT INTO users_collection (user_id, collection_name, is_private) VALUES('4', 'WONDER WOMAN', '0');

INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('WOLVERINE: BLACK, WHITE, AND BLOOD', 'RETURN TO THE WEAPON X PROGRAM...', 'MARVEL', 'WOLVERINE', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('WONDER WOMAN: VOLUME 1 THE LIES REBIRTH','HEROIC. ICONIC. UNSTOPPABLE.  ARMED WITH HER LASSO OF TRUTH...', 'DC', 'WONDER WOMAN', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('HARLEY QUINN: VOLUME 1: HOT IN THE CITY', 'HARLEY QUINN RETURNS TO HER FIRST SOLO SERIES...', 'DC', 'HARLEY QUINN', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('BLACK WIDDOW #1', 'NATASHA ROMANOFF HAS BEEN A SPY ALMOST AS LONG...', 'MARVEL', 'BLACK WIDOW', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('BATMAN VOL 1: THE COURT OF OWLS', 'AFTER A SERIES OF BRUTAL MURDERS ROCKS GOTHAM CITY...', 'DC', 'BATMAN', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('SUPERMAN #1', 'THE DOOMED PLANET KRYPTON WAS ABOUT TO EXPLODE...', 'DC', 'SUPERMAN', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('INCREDIBLE HULK VOL 1-1', 'LANDING IN A GRAVEYARD EN ROUTE TO NEW YORK...', 'MARVEL', 'HULK', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('AMAZING SPIDER-MAN', 'THE SPIDER-MAN EVENT OF THE DECADE BEGINS!', 'MARVEL', 'SPIDER-MAN', '667');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('HEROES AT HOME', 'BEING STUCK INSIDE ISN''T EASY FOR ANYONE, EVEN SUPER HEROES', 'MARVEL', 'SPIDER-MAN', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('BLACK PANTHER: POWER TP', 'WAKANDA HAS BEEN ATTACKED ON EVERY FRONT...', 'MARVEL', 'BLACK PANTHER', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('YOUNG HELLBOY: THE HIDDEN LAND', 'STRANDED ON A STRANGE ISLAND AFTER A MISHAP...', 'DARK HORSE', 'HELLBOY', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('ASSASSINS CREED VALHALLA: SONG OF GLORY', 'EIVOR, A VIKING WARRIOR, OBSERVES A VILLAGE RAIDED...', 'DARK HORSE', 'EIVOR', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('BATMAN AND ROBIN ETERNAL #1', 'FIVE YEARS AGO, BATMAN AND ROBIN WORKED THE MOST DISTURBING CASE...', 'DC', 'BATMAN', '1');
INSERT INTO comics (title, comic_desc, publisher, maincharacter, edition) VALUES('BATMAN AND ROBIN ETERNAL #13', 'RED ROBIN AND RED HOOD HAVE FOLLOWED A TRAIL OF TECHNOLOGY...', 'DC', 'BATMAN', '13');


INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '1');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '2');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '3');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '4');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '5');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '6');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('1', '3', '7');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '8');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '9');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '10');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '11');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '12');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '13');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('2', '3', '14');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('3', '4', '5');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('3', '4', '13');
INSERT INTO collections (collection_id, user_id, comic_id) VALUES ('3', '4', '14');


INSERT INTO characters (character_name) VALUES ('WOLVERINE');
INSERT INTO characters (character_name) VALUES ('WONDER WOMAN');
INSERT INTO characters (character_name) VALUES ('HARLEY QUINN');
INSERT INTO characters (character_name) VALUES ('BLACK WIDOW');
INSERT INTO characters (character_name) VALUES ('BATMAN');
INSERT INTO characters (character_name) VALUES ('SUPERMAN');
INSERT INTO characters (character_name) VALUES ('HULK');
INSERT INTO characters (character_name) VALUES ('SPIDER-MAN');
INSERT INTO characters (character_name) VALUES ('BLACK PANTHER');
INSERT INTO characters (character_name) VALUES ('HELLBOY');
INSERT INTO characters (character_name) VALUES ('EIVOR');

INSERT INTO comic_character (comic_id, character_id) VALUES ('1', '1');
INSERT INTO comic_character (comic_id, character_id) VALUES ('2', '2');
INSERT INTO comic_character (comic_id, character_id) VALUES ('3', '3');
INSERT INTO comic_character (comic_id, character_id) VALUES ('4', '4');
INSERT INTO comic_character (comic_id, character_id) VALUES ('5', '5');
INSERT INTO comic_character (comic_id, character_id) VALUES ('6', '6');
INSERT INTO comic_character (comic_id, character_id) VALUES ('7', '7');
INSERT INTO comic_character (comic_id, character_id) VALUES ('8', '8');
INSERT INTO comic_character (comic_id, character_id) VALUES ('9', '8');
INSERT INTO comic_character (comic_id, character_id) VALUES ('10', '9');
INSERT INTO comic_character (comic_id, character_id) VALUES ('11', '10');
INSERT INTO comic_character (comic_id, character_id) VALUES ('12', '11');
INSERT INTO comic_character (comic_id, character_id) VALUES ('13', '5');
INSERT INTO comic_character (comic_id, character_id) VALUES ('14', '5');


GO





