create table PersonalBio
(
id int primary key identity(1,1),
Name  varchar(500) not null,
Lastname varchar(500) not null,
Age int not null,
	 varchar(500) not null
)
insert into PersonalBio values('Siva','s',20,'address1')
Select * from PersonalBio

-- insert records into PersonalBio 
create or alter procedure InsertPersonalBio(@Name nvarchar(100),@Lastname nvarchar(100),@Age int,@Address nvarchar(100))
as
begin

  insert into PersonalBio (Name,Lastname,Age,Address)values (@Name,@Lastname,@Age,@Address)
end

exec InsertPersonalBio  'Sivanesn','s',20,'address2'

-------select sp
create or alter procedure SelectPersonalBio
as
begin

  Select * from PersonalBio

end

exec SelectPersonalBio

-------select sp with id
create or alter procedure selecteithID(@id int)
as
begin

  Select * from PersonalBio where id =@id

end

exec selecteithID 6

--ubdate

create or alter  procedure UbdatePersonalBio (@Name nvarchar(100),@Lastname nvarchar(100),@Age int,@Address nvarchar(100),@id int)
as
begin

  update PersonalBio set Name =@Name,Lastname=@Lastname, Age=@Age, Address=@Address where id=@id

end

exec UbdatePersonalBio 'hellosiva','ww',333,'my address s',2

--delete
create or alter procedure DeletePersonalBio (@id int)
as
begin

  delete from PersonalBio where id =@id

end

exec DeletePersonalBio 1002

Truncate table PersonalBio