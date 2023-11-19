CREATE DATABASE myfinanceweb

use myfinanceweb

create table planoconta(
	id int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id),
)

create table transacao(
	id int identity(1,1) not null,
	historico varchar(50) not null,
	tipo char(1) not null,
	valor decimal(9,2),
	planocontaid int not null,
	data datetime not null,
	primary key(id),
	foreign key(planocontaid) references planoconta(id)
)

insert into planoconta(descricao, tipo)
values 
	('Alimentação', 'D'),
	('Combustível', 'D'),
	('Alguel', 'D'),
	('Plano de saúde', 'D'),
	('Salário', 'R'),
	('Dividendos', 'R');

select * from planoconta;