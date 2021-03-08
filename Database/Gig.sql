create database GigManagement;
use GigManagement;
--user details
create table user_details(username varchar(40) primary key not null, 
names varchar(50) not null, passwords varchar(30) not null);
--artist details
create table artist_details(artist_username varchar(40) primary key not null, 
names varchar(50) not null, passwords varchar(30) not null);
--gig details 
create table gigs(gig_id int primary key, gig_name varchar(50) not null, 
artist_name varchar(40) not null, venue varchar(40) not null, gig_date datetime, 
genre varchar(20),isCancelled varchar(10) DEFAULT 'No');
insert into gigs values (4, 'sunburn','maitrayee','mumbai','12.12.2021','rock','no')
insert into gigs values (2, 'sunburnfest','maitrayee','kolkata',13/12/2020,'rock','no')
select * from gigs where venue = 'mumbai' OR gig_name = 'sunburn ' OR gig_date = '12.12.2021'
select * from gigs where venue ='mumbai'
--calender 
create table  gig_calender(username varchar(40), gig_id int, foreign key(username) 
references user_details(username), foreign key(gig_id) references gigs(gig_id));
--following
 create table following(username varchar(40) not null, artist_username varchar(40) not null, foreign key(username) 
references user_details(username), foreign key(artist_username) references artist_details(artist_username));
alter table following add primary key(username,artist_username)
drop table following
select * from gigs