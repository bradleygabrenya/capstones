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
	email varchar(max),
	workout_goals varchar(max),
	workout_profile varchar(max),
	photo varchar(max),
	check_in varchar(10) DEFAULT 'false',
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
	VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'userrole@com.com','get fit','user gets fit','https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg' ); 

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role, email, workout_goals, workout_profile, photo)
	VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'adminrole@com.com','admins fitness','gets users fit','https://adminphoto.net');


INSERT INTO equipment( equipment_name, description) VALUES ('Power Rack','Massive piece of equipment, used for various exercises.');
INSERT INTO equipment( equipment_name, description) VALUES ('Squat Rack','Not as massive as the power rack; still gets the job done.');
INSERT INTO equipment( equipment_name, description) VALUES ('Cable Crossover Machine','Pulley system, typically used for upper body.');
INSERT INTO equipment( equipment_name, description) VALUES ('Adjustable Weight Bench','Holy grail; used for a whole range of exercises.');
INSERT INTO equipment( equipment_name, description) VALUES ('Chest Press Machine','Standalone piece of equipment for chest.');
INSERT INTO equipment( equipment_name, description) VALUES ('Preacher Curl Bench','Suns out, guns out.');
INSERT INTO equipment( equipment_name, description) VALUES ('Lat Pulldown Machine','Back is just as important as chest; do not forget that.');
INSERT INTO equipment( equipment_name, description) VALUES ('Leg Press Machine','Never neglect leg day.');
INSERT INTO equipment( equipment_name, description) VALUES ('Calf Raise Machine','BAWK BAWK');
INSERT INTO equipment( equipment_name, description) VALUES ('Abdominal Bench','Wait in line.');
INSERT INTO equipment( equipment_name, description) VALUES ('Bench Press','I lied. This is the holy grail.');
INSERT INTO equipment( equipment_name, description) VALUES ('Treadmill','Why we all hate the gym..');
INSERT INTO equipment( equipment_name, description) VALUES ('Elliptical Machine','Slightly less hated cardio machine.');
INSERT INTO equipment( equipment_name, description) VALUES ('Exercise Spin Bike','Get that music going!');
INSERT INTO equipment( equipment_name, description) VALUES ('Rowing Machine','House of Cards.');
INSERT INTO equipment( equipment_name, description) VALUES ('Vertical Climber','LeBron James.');
INSERT INTO equipment( equipment_name, description) VALUES ('Dumbbells','Easily the most known free weights in the entire world.');


INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-04 10:13:32','2022-04-04 10:47:33');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-06 10:10:04','2022-04-06 10:55:38');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-08 10:00:19','2022-04-08 10:37:31');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-11 09:13:34','2022-04-11 10:00:02');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-13 10:15:12','2022-04-13 10:57:26');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-15 11:30:20','2022-04-15 12:06:23');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-18 09:13:27','2022-04-18 10:05:56');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-20 09:23:36','2022-04-20 10:00:00');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-22 10:30:14','2022-04-22 10:55:18');
INSERT INTO daily_workout (user_id,check_in,check_out) VALUES (1,'2022-04-25 10:33:10','2022-04-25 11:15:27');



INSERT INTO use_tracking (user_id, workout_id, equipment_id, reps, [weight], use_start, use_stop) VALUES (1,3000,2000,5,37,'2008-10-10 10:15:32','2008-10-10 10:45:32');


GO