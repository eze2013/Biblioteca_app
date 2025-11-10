📚 Biblioteca App

Proyecto desarrollado durante mi pasantía en Fabricard, como parte de una serie de ejercicios prácticos orientados al diseño, desarrollo y prueba de aplicaciones conectadas a bases de datos.
El trabajo abarca desde la creación del modelo de datos hasta la construcción de una aplicación web funcional, pasando por arquitectura en capas, inyección de dependencias y pruebas unitarias.

🚀 Descripción general

Biblioteca App es un sistema diseñado para gestionar la información de una biblioteca, abarcando la relación entre libros, autores, países de origen, copias y estanterías.
El proyecto evoluciona a través de diferentes etapas, cada una agregando nuevas capas de complejidad técnica y buenas prácticas de desarrollo.


🧩 Etapas del proyecto
🗂️ Tarea 1 – Diseño y creación de base de datos

** Modelado relacional completo para una biblioteca.

** Creación de tablas con convenciones de nombres normalizadas (BIB_Entidad).

** Implementación de claves primarias y foráneas con nombres estandarizados.

** Inserción de registros de prueba.

** Desarrollo de procedimientos almacenados para:

** Buscar un libro por nombre.

** Obtener autores según el país de nacimiento.

** Listar todas las copias disponibles de un libro y su ubicación en estanterías.

💡 Lenguaje: SQL Server
💾 Objetivo: Comprender el diseño relacional, normalización y uso de procedimientos almacenados.


⚙️ Tarea 2 – Aplicación de consola (arquitectura en capas)

** Desarrollo en Visual Studio (C# / .NET Framework).

** Estructura de 3 capas:

** Datos: conexión y consultas a la base de datos.

** Negocio: lógica de obtención y procesamiento de información.

** Presentación: aplicación de consola para listar autores de libros.

** Integración con la base de datos de la Tarea 1 mediante conexión a VPN corporativa.

🧱 Objetivo: aplicar el patrón de arquitectura en capas y separación de responsabilidades.


🧠 Tarea 3 – Refactorización e inyección de dependencias

** Implementación de interfaces para las clases de acceso a datos y negocio.

** Aplicación de inyección de dependencias a través de constructores.

** Uso de la librería Simple Injector para resolver dependencias en tiempo de ejecución.

** Eliminación del uso de instanciación directa (new) en la capa de presentación.

🔁 Objetivo: aplicar principios SOLID, mejorar mantenibilidad y testabilidad del código.


🧪 Tarea 4 – Pruebas unitarias

** Creación de un proyecto de Unit Test para la capa de negocio.

** Desarrollo de un test case para el método de consulta de autores.

** Implementación de mocks que simulan el comportamiento del DAO, retornando una lista de 3 autores.

** Validación de que el resultado no sea nulo y contenga más de un elemento.

🧰 Framework de pruebas: MSTest
🎯 Objetivo: asegurar la correcta funcionalidad del método y fortalecer la calidad del código.

🌐 Tarea 5 – Aplicación web (ASP.NET)

** Desarrollo de una aplicación web con ASP.NET Web Forms.

** Implementación de una página que:

** Muestra un ComboBox con los países disponibles (obtenidos de la BD).
      
** Permite seleccionar un país y consultar los autores correspondientes.
      
** Muestra los resultados en una grilla dinámica.
      
** Integración directa con los procedimientos almacenados de la base de datos.

** Uso de Master Page de plantilla para uniformidad visual.

💻 Objetivo: integrar backend y frontend, consolidando los conocimientos en ASP.NET y SQL Server.


🛠️ Tecnologías utilizadas
Tipo	Herramientas
Lenguajes	JavaScript (73.3%), HTML (10.9%), C# (10.7%), ASP.NET (5%), CSS (0.1%)
Entorno	Visual Studio Community 2015
Base de datos	SQL Server
Frameworks / Librerías	ASP.NET, Simple Injector, MSTest
Control de versiones	Git / GitHub
Conexión corporativa	VPN Fabricard


🧩 Arquitectura general

BibliotecaApp/
│
├── Datos/                # Acceso a datos (DAO, conexión SQL)
├── Negocio/              # Lógica de negocio e interfaces
├── Presentacion/         # Consola o WebApp según la etapa
├── Tests/                # Proyecto de Unit Testing
└── Scripts_SQL/          # Creación de BD y procedimientos almacenados


🎯 Objetivo formativo

Este proyecto me permitió fortalecer competencias clave en:
** Diseño y modelado de bases de datos relacionales.

** Programación en capas con principios SOLID.

** Implementación de inyección de dependencias.

** Pruebas unitarias y uso de mocks.

** Desarrollo de aplicaciones web conectadas a base de datos.

** Representa un recorrido completo desde el backend hasta la interfaz de usuario, pasando por todas las capas de una aplicación profesional.

💬 Autor

Ezequiel Sánchez

💼 Desarrollador en formación – Pasantía en Fabricard

🌐 LinkedIn - https://www.linkedin.com/in/hugo-ezequiel-sanchez/
