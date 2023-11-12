Returns a list with the first surname, second surname and first name of all students. The list should be sorted alphabetically from lowest to highest by first last name, middle name and first name.

    ````sql
      http://localhost:5186/Api/Persona/Apellidos
    ```

2. Find out the first and last name of the students who **have not** entered their phone number in the database.

    ````sql
      http://localhost:5186/Api/Persona/SinNumero
    ```

3. Returns the list of students who were born in `1999`.

    ````sql
     http://localhost:5186/Api/Persona/NacidosEn1999
    ```

4. Returns the list of `teachers` who **have not** registered their phone number in the database and also have a tax ID ending in `K`.

    ````sql
      http://localhost:5186/Api/Persona/ProfesoresSinCelYNif
    ```

5. Returns the list of the subjects taught in the first term, in the third year of the degree that has the identifier `7`.

    ````sql
      http://localhost:5186/Api/Asignatura/AsignaturasPrimerCuatrimestreTercer
    ```

6. Returns a list with the data of all **students** who have ever enrolled in the `Degree in Computer Engineering (Plan 2015)`.

    ````sql
      http://localhost:5186/Api/Persona/AlumnasMatriculadasEnIngenieriaInformatica
    ```

7. Returns a list with all the subjects offered in the `Degree in Computer Engineering (Plan 2015)`.

    ````sql
      http://localhost:5186/Api/Asignatura/AsignaturasEnIngenieriaInformatica
    ```

8. Return a list of the `teachers` along with the name of the `department` to which they are attached. The listing should return four columns, `first last name, middle last name, first name and department name.` The result will be sorted alphabetically from lowest to highest by `last name and first name.`.

    ````sql
      http://localhost:5186/Api/Profesor/ProfesoresConDepartamentoOrdenados
    ```

9. Returns a list with the name of the subjects, start year and end year of the school year of the student with ID `26902806M`.

    ````sql
      http://localhost:5186/Api/Persona/ObtenerAsignaturasPorAlumno
    ```

10. Returns a list with the name of all the departments that have professors teaching a subject in the `Grado en Ingeniería Informática (Plan 2015)`.

     ````sql
       http://localhost:5186/Api/Persona/ObtenerDepartamentosConAsignaturasEnGrado
     ```

11. Returns a list of all students who have enrolled in a course during the 2018/2019 academic year.

     ````sql
       http://localhost:5186/Api/Persona/ObtenerAlumnosMatriculadosEnCursoEscolar
     ```

12. Returns a list with the names of **all** teachers and the departments they are linked to. The listing should also show those teachers who have no department associated with them. The list should return four columns, department name, first surname, second surname and professor's first name. The result will be sorted alphabetically from lowest to highest by department name, last name and first name.

     ````sql
       http://localhost:5186/Api/Persona/ObtenerProfesoresConDepartamentosOrdenados
     ```


13. Returns a list of professors that are not associated with a department.Returns a list of departments that do not have associated professors.

     ````sql
      http://localhost:5186/Api/Profesor/ObtenerProfesoresYDepartamentosSinAsociacion
     ```

14. Returns a list of teachers who do not teach any subject.

     ````sql
       http://localhost:5186/Api/Profesor/ObtenerProfesoresSinAsignaturas
     ```

15. Returns a list of subjects that do not have a teacher assigned to them.

     ````sql
       http://localhost:5186/Api/Asignatura/ObtenerAsignaturasSinProfesor
     ```

16. Returns a list of all departments that have a subject that has not been taught in any school year. The result should show the name of the department and the name of the subject that has never been taught.

     ````sql
       # Query Here
     ```


