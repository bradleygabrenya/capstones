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
	user_role varchar(50) NOT NULL,	
	email varchar(max) NOT NULL,
	workout_goals varchar(max) NOT NULL,
	workout_profile varchar(max) NOT NULL,
	photo varchar(max) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)	
)

CREATE TABLE equipment (
	equipment_id int IDENTITY(2000,1) NOT NULL,
	equipment_name varchar(200) NOT NULL,
	description varchar(max) NOT NULL,
	CONSTRAINT PK_equipment_id PRIMARY KEY (equipment_id)
)

CREATE TABLE daily_workout (
	workout_id int IDENTITY(3000,1) NOT NULL,
	user_id int NOT NULL,
	check_in datetime NOT NULL,
	check_out datetime NOT NULL,
	CONSTRAINT PK_workout_id PRIMARY KEY (workout_id),
	CONSTRAINT FK_user_id FOREIGN KEY(user_id) REFERENCES users(user_id)
)

CREATE TABLE use_tracking (
	tracking_id int IDENTITY(4000,1) NOT NULL,
	user_id int NOT NULL,
	workout_id int NOT NULL,
	equipment_id int NOT NULL,
	reps int DEFAULT 0,
	[weight] decimal(6,2) DEFAULT 0,
	use_start datetime NOT NULL,
	use_stop datetime NOT NULL,	
	CONSTRAINT PK_tracking_id PRIMARY KEY (tracking_id),
	CONSTRAINT FK_user_id_USETRACKING FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_equipment_id FOREIGN KEY (equipment_id) REFERENCES equipment(equipment_id),
	CONSTRAINT FK_workout_id FOREIGN KEY (workout_id) REFERENCES daily_workout(workout_id)
)


--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role, email, workout_goals, workout_profile, photo)
	VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'userrole@com.com','get fit','user gets fit','https://photo.net' ); 

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role, email, workout_goals, workout_profile, photo)
	VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'adminrole@com.com','admins fitness','gets users fit','https://adminphoto.net');


INSERT INTO equipment( equipment_name, description) VALUES ('ujihg','sdhfg');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2008-10-10 10:13:32','2008-10-10 10:47:32');
INSERT INTO use_tracking (user_id, workout_id, equipment_id, reps, [weight], use_start, use_stop) VALUES (1,3000,2000,5,37,'2008-10-10 10:15:32','2008-10-10 10:45:32');


GO