# Realizar una Solución a Nivel de Desarrollo Computacional:
### A. Desarrollo de un Proyecto basado en el uso de “Clases" a nivel de "Programación Orientada a Objetos” utilizando los criterios de:

- Arquitectura de 3 Niveles y Arquitectura Cliente Servidor

- Infraestructura Cliente Servidor y 3 Capas

- Origen de Datos adecuado a dichas Arquitecturas e Infraestructuras

- Conexión, acceso y manejo de datos forma conectada (On Line,
ejemplo: SqlConnection, SqlCommand, SqlDataReader) o desconectada (Off
Line, ejemplo: SqlConnection, SqlAdapter, SqlDataAdapter, DataTable o
DataSet)

- Desarrollo (preferible) basado en un Paradigma de "Programación
Desacoplada" a nivel de las siguientes Clases: Datos, Negocios, y
Presentación

La Clase equivalente a “Datos” tendrá toda la lógica y programación misma a nivel
de desarrollo computacional para tener los “Métodos, Procedimientos y/o
Funciones” para aplicar el concepto de un CRUD, es decir, los procedimientos y
funciones necesarios para insertar, modificar, leer, eliminar o borrar los datos que
van a ser accesados desde el siguiente Proyecto de Interfaz de usuario.
Esta Clase debe de tener el Procedimiento o Función para realizar la Conexión a Base
de Datos, ya sea desde un StringConnection que accese la Base de Datos que se
leerá desde cualquier archivo XML o JSON del Proyecto. Dicho nombre sugerido
para ese procedimiento o función para realizar la conexión a dicha Base de Datos
llamada “SellPoint” se llamará “StringConnectionDB”.

La Clase equivalente a “Negocios” deberá de validar que los “Límites de Crédito de
las Entidades “no sean menor a cero”, por ende, cualquier monto o valor registrado
debe de ser “mayor a cero”.

La Clase equivalente a “Presentación” deberá de tener un “Método, Procedimiento o
Función” que reciba los valores del campo “NumeroDocumento”, y formatearlos
según se requiera con las separaciones correspondientes de los documentos
equivalentes a Cédula de Identidad y Electoral, RNC, y Pasaporte, y, ser presentados
en el Formulario con la longitud y formato con guiones correspondiente.

### B. Desarrollo de un Proyecto en cualquier Plataforma y Ambiente” para aplicar el
uso de los conceptos de desarrollo de, tomando en consideración los siguientes
elementos:

1. Un “Splash Screen o Formulario de Bienvenida” con una imagen o característica
particular de inicio de la “Aplicación SellPoint v1.0”, así como el uso de cualquier
otra información en dicha pantalla de inicio.

2. Un “Login o Formulario de Acceso” para validar las “Credenciales de Acceso a
la Aplicación SellPoint v1.0”. Dichas validaciones de credenciales de acceso se
realizarán con los campos UserNameEntidad y PasswordEntidad de la “Tabla
Entidades”.

Si al ejecutar la apliación, -posterior al login- la "Tabla de Entidades" no tiene
registros para validar las credenciales, en vez de cargar el login, deberá de cargar el
"Mantenimiento de Entidades" para crear una Entidad con sus correspondientes
credenciales de "Nombre de Usuario" y "Contraseña"; posterior a eso, cargar el login,
y validar las credenciales suministradas, según amerite el caso.

3. Al accesar correctamente con las credenciales desde la Base de Datos, cargar un
“Menú Principal” con la siguiente jerarquía de opciones:
- Archivos (Mantenimientos)
- Entidades
- Sistema
- Acerca de…
- Login
- Salir

4. El “Menú Principal” debe de tener en su entorno la información del Usuario
Conectado”, con la “fecha y hora actual del Sistema Operativo”. Se recomienda el
uso de un objeto tipo “StatusBar” para los fines de lugar con sus correspondientes
segmentos o divisiones de visualización.

5. Las Sub-opciones que estarán debajo del “Menú de Archivos” (Grupos
Entidades, Tipos Entidades o “Entidades”) serán los Mantenimientos o
CRUD´s. Cada mantenimiento o CRUD tendrá sus propios botones para adicionar,
modificar, buscar, y eliminar registros o datos, con sus correspondientes validaciones
y criterios de uso.

6. Al accesar la opción “Acerca de…” desde la opción principal Sistema, deberá
mostrar una pantalla con los datos de todos y cada uno de los estudiantes que
realizaron el Proyecto, mostrando por lo menos el nombre, matrícula, y cualquier
otro dato, imagen, información de dichos participantes.

7. Al accesar la opción de “Login” contenida dentro de la opción principal Sistema,
deberá de mostrar la pantalla Login, y con eso, dependiendo de las credenciales
correctas, mostrar en el Menú Principal qué usuario es el qué está logueado,
refrescando o activando dicho usuario donde se esté visualizando, preferiblemente
en el “StatusBar del Menú Principal”.

8. Todos los “formularios realizados”, deberán de tener un enfoque de diseño
con perspectiva 2D o 3D en su diseño.

9. Pueden hacer que el useo de las “Librerías de Clases” esté referenciado de
manera "Programación Acoplada" con el Proyecto (opcional).

10. Pueden crear un “Formulario/Plantilla/Template Padre y un
Formulario/Plantilla/Template Hijo” para el desarrollo de los formularios o
pantallas de dicho Proyecto (opcional).

11. Considerar que: De no aplicar el uso de un "Proyecto adicional", "Clases" o
"Librería de Clases" para el manejo de las funciones, métodos y/o procedimientos
con las programaciones correspondientes, se deberá de desarrollar la programación
dentro de los botones o interacciones del “Formulario de Entidades”.

# Resultado de la solución
## Ventana de carga / Splash
![carga](https://user-images.githubusercontent.com/71516416/187489742-f087bdb9-dc9f-4a63-bf9b-00442dde2ceb.png)
## Ventana Login
![Login](https://user-images.githubusercontent.com/71516416/187488472-e079c4c7-017b-4724-9d54-cf7d3737fc51.png)
## Ventana menú principal / pestaña bienvenida
![MenuBienvenida](https://user-images.githubusercontent.com/71516416/187488560-80ce1dc3-942c-4b95-b0b4-6e7b244289ea.png)
## Ventana menú principal / pestaña acerca de
![MenuAcercaDe](https://user-images.githubusercontent.com/71516416/187488653-4f4974fc-3dce-4c67-926d-97498fbba6c3.png)
## Ventana menú principal / pestaña mantenimientos
![MenuMantenimientos](https://user-images.githubusercontent.com/71516416/187488758-27d75551-571c-4328-b0dc-2683e1f29f90.png)
## Ventana menú principal / pestaña de registro
![MenuRegistro](https://user-images.githubusercontent.com/71516416/187488876-568ee6f3-9157-4d94-bf76-b00c322859d0.png)
### Vista completa de la ventana registro 
![RegistroCompleto](https://user-images.githubusercontent.com/71516416/187488947-f32bdb04-db9f-4cd9-a39b-cd123357cd71.png)
## Ventana menú principal / pestaña de edición
![MenuEdicion](https://user-images.githubusercontent.com/71516416/187489018-c8ffb45d-14bc-4d17-9546-6a99d30453cd.png)
### Vista completa de la ventana edición
![EdicionCompleto](https://user-images.githubusercontent.com/71516416/187489073-63310ce4-90d0-431f-bc80-4f7b01776ac8.png)









