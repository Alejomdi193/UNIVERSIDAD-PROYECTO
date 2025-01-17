# Proyecto API con .NET y MySQL - BackUpUniversidad 

Este proyecto consiste en el desarrollo de una API en un proyecto de C# (.NET) conectado a una base de datos MySQL. La API implementa diversas consultas para obtener información específica de la base de datos de forma estructurada y eficiente.

## Tecnologías Utilizadas

- **.NET**: Framework para desarrollar aplicaciones robustas y escalables.
- **MySQL**: Sistema de gestión de bases de datos relacional utilizado para almacenar y gestionar datos.
- **Entity Framework Core**: Herramienta ORM (Mapeo Objeto-Relacional) que facilita la interacción con la base de datos.

## Consultas Implementadas

### Consultas y Endpoints

1. **Listado de nombres completos de los estudiantes ordenados alfabéticamente:**
   - Endpoint: `http://localhost:5186/Api/Persona/Apellidos`

2. **Estudiantes sin número de teléfono registrado:**
   - Endpoint: `http://localhost:5186/Api/Persona/SinNumero`

3. **Estudiantes nacidos en 1999:**
   - Endpoint: `http://localhost:5186/Api/Persona/NacidosEn1999`

4. **Profesores sin número de teléfono y con NIF terminado en 'K':**
   - Endpoint: `http://localhost:5186/Api/Persona/ProfesoresSinCelYNif`

5. **Asignaturas del primer cuatrimestre, tercer año, identificador de grado 7:**
   - Endpoint: `http://localhost:5186/Api/Asignatura/AsignaturasPrimerCuatrimestreTercer`

6. **Estudiantes matriculados en el Grado en Ingeniería Informática (Plan 2015):**
   - Endpoint: `http://localhost:5186/Api/Persona/AlumnasMatriculadasEnIngenieriaInformatica`

7. **Asignaturas ofrecidas en el Grado en Ingeniería Informática (Plan 2015):**
   - Endpoint: `http://localhost:5186/Api/Asignatura/AsignaturasEnIngenieriaInformatica`

8. **Profesores y departamentos asociados, ordenados alfabéticamente:**
   - Endpoint: `http://localhost:5186/Api/Profesor/ProfesoresConDepartamentoOrdenados`

9. **Asignaturas del año escolar del estudiante con ID 26902806M:**
   - Endpoint: `http://localhost:5186/Api/Persona/ObtenerAsignaturasPorAlumno`

10. **Departamentos con profesores enseñando asignaturas en el Grado en Ingeniería Informática (Plan 2015):**
    - Endpoint: `http://localhost:5186/Api/Persona/ObtenerDepartamentosConAsignaturasEnGrado`

11. **Estudiantes matriculados durante el curso 2018/2019:**
    - Endpoint: `http://localhost:5186/Api/Persona/ObtenerAlumnosMatriculadosEnCursoEscolar`

12. **Profesores y departamentos (incluyendo profesores sin departamento):**
    - Endpoint: `http://localhost:5186/Api/Persona/ObtenerProfesoresConDepartamentosOrdenados`

13. **Profesores no asociados a departamentos y departamentos sin profesores asociados:**
    - Endpoint: `http://localhost:5186/Api/Profesor/ObtenerProfesoresYDepartamentosSinAsociacion`

14. **Profesores que no imparten asignaturas:**
    - Endpoint: `http://localhost:5186/Api/Profesor/ObtenerProfesoresSinAsignaturas`

15. **Asignaturas sin profesor asignado:**
    - Endpoint: `http://localhost:5186/Api/Asignatura/ObtenerAsignaturasSinProfesor`

16. **Departamentos con asignaturas que no se han impartido nunca:**
    - **Nota:** Consulta aún no implementada en el proyecto.

## Organización del Proyecto

- **Controllers**: Contiene la lógica para manejar las solicitudes HTTP y gestionar las rutas.
- **Models**: Define las estructuras de datos utilizadas para representar y procesar la información.
- **Data**: Incluye el contexto de la base de datos configurado mediante Entity Framework Core.

## Cómo Ejecutar el Proyecto

1. Clona el repositorio.
2. Configura tu cadena de conexión en el archivo `appsettings.json` con las credenciales de tu base de datos MySQL.
3. Restaura los paquetes necesarios ejecutando:

   ```bash
   dotnet restore
   ```

4. Inicia el proyecto:

   ```bash
   dotnet run
   ```

5. Accede a los endpoints mediante un cliente HTTP como Postman o tu navegador web.

## Licencia

Este proyecto está licenciado bajo la MIT License.