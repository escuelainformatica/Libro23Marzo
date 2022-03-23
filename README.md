# Libro23Marzo
Libro23Marzo

Ejercicio

# en la base de datos

* Agregar una tabla llamada categorias con las siguientes columnas:

Id (entero)
Nombre (texto)

* Y agregar datos de ejemplo

* Cree una tabla **libros**, agregar las columnas

Id (entero)
Nombre (texto)
idcategoria (entero)


* Luego, en la misma edicion de la tabla **libros** crear una llave foranea.



# 1 en la consola de Nuget escribir lo siguiente:

> Install-Package MySql.EntityFrameworkCore -Version 5.0.10
> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.15

# 2 Luego, en la misma consola ejecutar lo siguiente

> Scaffold-DbContext "server=localhost;port=3306;user=root;password=abc.123;database=cursovisual" MySql.EntityFrameworkCore -OutputDir basevisual -f

