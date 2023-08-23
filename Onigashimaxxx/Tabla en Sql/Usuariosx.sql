create database dB_Acceso
use dB_Acceso

create table Usuario(
IdUsuario int primary key identity(1,1),
Correo varchar (100),
Contraseña varchar (100)
)

create proc sp_RegistrarUsuario(
@Correo varchar(100),
@Contraseña varchar(100),
@Registrado bit output,
@Mensaje varchar(100) output
)
as
begin
    if(not exists(select*from Usuario where Correo = @Correo))
	begin
	   insert into Usuario(Correo,Contraseña) values(@Correo,@Contraseña)
	   set @Registrado = 1
	   set @Mensaje = 'Usuario Registrado'
	   end
	   else
	   begin
	   set @Registrado = 0
	   set @Mensaje = 'Correo existente'
	   end
end

create proc sp_ValidarUsuario(
@Correo varchar(100),
@Contraseña varchar(100)
)
as
begin
    if(exists(select*from Usuario where Correo = @Correo and Contraseña = @Contraseña))
	  select IdUsuario from Usuario where Correo = @Correo and Contraseña = @Contraseña
	 else
      select '0'
end

declare @registrado bit, @mensaje varchar(100)

exec sp_RegistrarUsuario 'matiaserradorr@gmail.com' ,'5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', @registrado output, @mensaje output
select @registrado
select @mensaje

