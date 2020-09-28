create table Livro(
	Id int identity(1,1) primary key not null,
	Titulo nvarchar(255) not null,
	Isbn nvarchar(13) not null,
	Publicacao Datetime2 not null,
	AutorId int foreign key references Autor(Id)
);

select l.Titulo, a.Nome from Livro as l inner join Autor as a on  a.Id = l.AutorId where a.Nome = 'Rodrigo'

select * from Autor

insert into Autor(Nome, UltimoNome, Nascimento)values('Fernando','Muniz','1986-10-24')

insert into Livro(Titulo, Isbn, Publicacao,AutorId)values('Asp Net3','13-13-13','2000-10-24',1)

delete from Autor where Id = 2;