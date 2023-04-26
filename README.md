# App-Card

App-Card es una aplicación web desarrollada con ADO.NET 6 y MVC Core que permite a los usuarios acceder a diferentes funcionalidades según su rol en la aplicación. El rol "Administrator" puede agregar, editar y eliminar tarjetas ("Cards"), mientras que el rol "User" solo puede iniciar sesión y ver las tarjetas existentes.

## Requisitos previos
Antes de comenzar a utilizar la aplicación, necesitarás tener instalado lo siguiente:

- .NET 6 SDK o posterior
- SQL Server

## Instalación y configuración
1. Clona el repositorio de la aplicación en tu ordenador local.
2. Ejecuta el script de SQL proporcionado para crear las bases de datos y tablas necesarias para la aplicación. Este script también incluye algunas tarjetas precargadas para facilitar la prueba de la aplicación.

## Escalabilidad y Validaciones
App-Card ha sido diseñada con una arquitectura escalable que permite agregar nuevas conexiones de base de datos en caso de que sea necesario. Actualmente, la aplicación ya viene configurada con dos conexiones de base de datos en el archivo appsettings.json.

Si se necesita agregar una nueva conexión de base de datos, se debe crear un nuevo script SQL y agregar el nombre de la conexión como una nueva propiedad en el enum "DataSource". Luego, el nombre de la conexión debe agregarse como otra conexión de base de datos en el archivo appsettings.json. Esto garantiza que la aplicación se mantenga escalable y pueda manejar múltiples conexiones de base de datos sin problemas.

Además, la aplicación utiliza una gran cantidad de validaciones para asegurar que todos los datos ingresados sean válidos y seguros. Se utilizan atributos de validación de datos en los modelos para garantizar que los datos ingresados sean del tipo y formato correctos. También se utilizan técnicas para prevenir la inyección de dependencias, como la función "AddParametersWithValue" que evita que se puedan realizar consultas maliciosas a la base de datos.



También se ha utilizado el atributo "DataSource" en la vista para permitir que el usuario seleccione una base de datos específica al crear una nueva tarjeta. Las validaciones se realizan en el lado del cliente para garantizar que los datos ingresados cumplan con los requisitos de formato y tipo.
