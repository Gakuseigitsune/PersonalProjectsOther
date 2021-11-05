drop database characterList;
create database characterList;
use characterList;

create table owners(

uid int not null auto_increment,
username varchar (50) not null unique,
email varchar(128) unique,
isAdmin bool,
userType int,

primary key (uid)

);

insert into owners(username, isAdmin, userType) values('~KKogitsune', true, 0);
insert into owners(username, isAdmin, userType) values('Gakuseigitsune', true, 1);



create table characters(

cid int not null auto_increment,
uid int not null,
name varchar(50) not null,
species varchar(25),
char_class varchar(20) not null,


primary key (cid), foreign key (uid) references owners(uid)

);


insert into characters (name, uid, char_class) values('test1',1, 'admin');
insert into characters (name, uid, char_class) values('test2',1, 'test');
insert into characters (name, uid, char_class) values('test3',1, 'none');

create table images(

rfid bigint auto_increment not null,
cid int not null,
label varchar(25) not null,
upld_ts datetime default current_timestamp on update current_timestamp not null,

primary key (rfid), foreign key (cid) references characters(cid)

);





select * from Characters;
#select * from Characters where species like'';
