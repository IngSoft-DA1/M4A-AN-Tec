# Framework
Un framework es una aplicación incompleta, que provee funcionalidad genérica con el objetivo de permitirle al usuario escribir software que cumpla un propósito en particular.​

![image](https://github.com/user-attachments/assets/0b18477b-4434-4973-924c-476d9001f6a1)

## ¿Qué es  .Net?
- **Framework** de desarrollo construido por Microsoft que corre sobre el sistema operativo de **Microsoft**.
- .Net soporta soporta múltiples lenguajes. *c#, f#, Visual basic, C++* y más.
  
## ¿Qué es .NetCore?
- Al Igual que .Net es un **Framework** construido por Microsoft, pero tiene como diferencia que es multiplataforma, es decir puede correr tanto en Windows omo macOS y Linux. 
- En este curso utilizaremos .NetCore
  
# Librerías de clases base (BCL)​  
- Son un conjunto de librerías base que son accesibles para todos los lenguajes del framework.
- Libreria: Las librerías encapsulan distintas funcionalidades como manejo de threads, acceso a archivos, llamadas remotas, acceso a la api de ui, manejo de bases de datos, etc.​
- EL *namespace* de la *BCL* es **System**.
  
![image](https://github.com/user-attachments/assets/f01906e5-faa2-4ff8-89cf-447c6fb20b07)

## Ambiente de ejecución CLR (*Common language runtime*)
- Es un runtime que puede ser utilizado por distintos lenguajes de programación. Las funcionalidades que el CLR provee (como manejo de memoria, manejo de excepciones, sincronización de threads, seguridad, entre otras) son accesibles por cualquier lenguaje que le sea compatible.​
- Es más el CLR no sabe el lenguaje del código mientras siempre que el compilador del mismo genere un lenguaje intermedio que el CLR pueda interpretar.
- Intermediate Language: es el código que luego el CLR maneja en tiempo de ejecución​
### Flujo:
![image](https://github.com/user-attachments/assets/1a2aacd4-a398-4348-a205-0298c9f06b6a)


## Metadata:
- La Metadata puede ser entendida como información que describe que es lo que está definido en cada módulo (tipos y métodos)​
Tiene múltiples usos, algunos ejemplos son:
- Visual Studio utiliza la metadata para el uso de intellisense, es decir sugerir métodos disponibles y los parámetros requeridos.​
- Serialización y deserialización de objetos para transferencia entre máquinas remotas.​
- Determinación del tiempo de vida de un objeto por el Garbage Collector​

# Assembly:
Es un archivo ejecutable (.exe) o un archivo con definiciones de tipos y funcionalidad para ser utilizado por un ejecutable (.dll).
- Un assembly es un grupo lógico de uno o más archivos o módulos​
- Un assembly es la unidad menor de reuso, liberación y versionado​
- Los assemblies van acompañados por un archivo de metadata llamado manifest, que describe los archivos que forman el assembly. Es decir, es metadata que describe al propio assembly.​
- Los assemblies van acompañados por archivos de recursos que necesite​
- Los assemblies contienen módulos en IL y la metadata particular que describe a ese módulo​

![image](https://github.com/user-attachments/assets/0df8d858-db16-4f80-b3df-d30fe10a74f0)
 
## Common Type System​
El Common Type System es una especificación que describe como se deben definir los tipos para ejecutarse dentro del CLR.​
​
## Common Language Specification​
El Common Language Specification es un conjunto de reglas que describe en detalle el conjunto de mínimo de funcionalidades que un compilador debe soportar para producir código que pueda ser ejecutado por el CLR y que al mismo tiempo pueda ser accedido por todos los lenguajes que apuntan a .NET.​ El CLS puede ser visto como un subset del CTS.​

- Tanto el CTS como el CLS son parte del CLR
![image](https://github.com/user-attachments/assets/f8e84d64-bb25-4c16-9745-860a6cddf995)

# Assembly
## Private Assemblies

Un Private Assembly es un ensamblado que se utiliza exclusivamente por una aplicación en particular. Estos assemblies se almacenan en el mismo directorio o en un subdirectorio de la aplicación que los está utilizando. Cada vez que se compila un proyecto, se genera una copia privada del assembly que se coloca en el directorio de salida del proyecto (por ejemplo, la carpeta bin/Debug o bin/Release).

Cuando creamos un proyecto en Rider, los ensamblados que se generan son Private Assemblies, lo que significa que son exclusivos de la aplicación en la que estás trabajando. Este tipo de assembly es fácil de manejar porque no requiere instalaciones especiales y se ejecuta directamente desde el directorio donde se encuentra la aplicación.

Ejemplo: Cada vez que compilan su proyecto, están creando un Private Assembly que se guarda en una carpeta específica del proyecto.

## Shared Assemblies

Un Shared Assembly es un ensamblado diseñado para ser utilizado por múltiples aplicaciones. Estos assemblies se almacenan en una ubicación central llamada Global Assembly Cache (GAC). Solo las bibliotecas (.dll) se pueden instalar en el GAC, no los ejecutables (.exe).

La idea detrás de los Shared Assemblies es evitar tener múltiples copias de la misma biblioteca en diferentes proyectos. En su lugar, se almacena una única copia en el GAC, y cualquier aplicación que lo necesite puede acceder a él.

Esto es útil cuando varias aplicaciones requieren la misma funcionalidad, como una biblioteca de clases común.

Ejemplo: Imagina que tienes una biblioteca para manejar operaciones matemáticas avanzadas y la utilizas en varios proyectos diferentes. Si la instalas como un Shared Assembly en el GAC, todas tus aplicaciones pueden usarla sin duplicarla.

## Global Assembly Cache (GAC)

El GAC es un área especial en el sistema donde se almacenan los Shared Assemblies. Este directorio centralizado permite que diferentes aplicaciones en la misma máquina compartan ensamblados sin necesidad de tener múltiples copias en diferentes directorios de proyectos.

El GAC ayuda a reducir la redundancia en el sistema y facilita el mantenimiento de las bibliotecas compartidas.

Un assembly en el GAC está disponible globalmente en el sistema, por lo que cualquier aplicación que lo necesite puede acceder a él sin necesidad de incluirlo en su propio directorio.

Ejemplo: Piensa en el GAC como una biblioteca pública donde todos pueden consultar el mismo libro sin necesidad de tener una copia en su casa.

## DLL Hell

El DLL Hell es un problema clásico que ocurre cuando diferentes aplicaciones necesitan diferentes versiones de la misma biblioteca.

Si una aplicación A utiliza la versión 1.0.0 de una dll y otra aplicación B instala una versión más nueva, como la 1.0.1, puede ocurrir que la versión más nueva sobrescriba la anterior, causando que la aplicación A falle.

Este problema surgía porque las aplicaciones no podían especificar qué versión exacta de una dll necesitaban, lo que provocaba conflictos cuando se actualizaba una dll.

La solución moderna a este problema es que cada dll en el GAC puede tener múltiples versiones instaladas, lo que permite que las aplicaciones usen la versión específica que necesitan sin interferir con otras aplicaciones.

Ejemplo: Piensa en DLL Hell como cuando dos personas en una casa comparten el mismo cepillo de dientes, pero una de ellas cambia el cepillo por otro que la otra persona no puede usar, lo que causa problemas.

### ¿Qué sucede al eliminar el archivo DLL?

Cuando eliminas el archivo b.dll y luego intentas ejecutar el .exe, el programa fallará al iniciar. Esto sucede porque la aplicación de consola depende de la biblioteca "B" para ejecutar el código dentro de la clase "A". 

Sin la presencia del archivo b.dll, el runtime de .NET no puede encontrar la implementación de la clase "A" que tu aplicación está intentando utilizar, lo que resulta en una excepción FileNotFoundException o un error similar.
