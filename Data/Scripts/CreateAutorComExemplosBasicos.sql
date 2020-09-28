--Create
--select
--Drop
--update
--Delete
--INSERT
--Alter Table Column
CREATE TABLE Autor(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nome NVARCHAR(50),
	UltimoNome nvarchar(50),
	Nascimento Datetime2
);
insert into Autor
(Nome, UltimoNome, Nascimento)
values('Rodrigo', 'Muniz','1986-10-24');

select Id, Nome,UltimoNome from Autor;

delete from Autor where Nome = 'Rodrigo';

update Autor 
	set Nome = 'Rodrigo',UltimoNome = 'Fernandes Muniz'
	where Id=10

update Autor 
	set Nome='Jéssica', UltimoNome = 'Bianchi'
	where Id = 11

--Drop table não funciona se houver uma foreing key associada a tabela
drop table Autor

alter table Autor
	alter column Nome nvarchar(255)

