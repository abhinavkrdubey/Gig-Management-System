create database GigManagement;
use GigManagement;
--user details
create table user_details(username varchar(40) primary key not null, 
names varchar(50) not null, passwords varchar(30) not null);
create table artist_details(artist_username varchar(40) primary key not null, 
names varchar(50) not null, passwords varchar(30) not null);
--gig details 
create table gigs(gig_id int primary key, gig_name varchar(50) not null, 
artist_name varchar(40) not null, 
venue varchar(40) not null, gig_date datetime, genre varchar(20),isCancelled varchar(10) DEFAULT 'No');
--calender 
create table  gig_calender(username varchar(40), gig_id int, isCancelled varchar(10), 
gig_date datetime, foreign key(username) 
references user_details(username), foreign key(gig_id) references gigs(gig_id));
--following
 create table following(username varchar(40) not null, artist_username varchar(40) not null, foreign key(username) 
references user_details(username), foreign key(artist_username) references artist_details(artist_username));