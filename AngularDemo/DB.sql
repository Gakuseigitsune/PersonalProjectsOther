drop database characterList;
create database characterList;
use characterList;
create table characters(

cid int not null auto_increment,
name varchar(50) not null,
species varchar(25),
char_class varchar(20) not null,


primary key (cid)

);

insert into characters (name, char_class) values('test1', 'admin');
insert into characters (name, char_class) values('test2', 'test');
insert into characters (name, char_class) values('test3', 'none');


select * from Characters;
#select * from Characters where species like'';
