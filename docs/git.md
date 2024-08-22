# Conceptos basicos
-  Repositorio: Estructura de directorios donde se almacenan los elementos componentes de software producidos a lo largo de todo el proyecto.
- GIT: es un sistema de control de versiones distribuido que permite gestionar y registrar cambios en el código, facilitando la colaboración entre desarrolladores.
-  `.gitignore`: un archivo en la raíz del repo que se utiliza para especificar que archivos no deben ser trakeados ni estar en el repositorio, recomendable usar [paginas](gitignore.io) para generarlos.
-  root del proyecto de git:carpeta raiz del repositorio
## Workflow:
![image](https://github.com/user-attachments/assets/ac2fb236-bfb1-4481-83e6-cdf27759be13)

## Commandos Utiles:
- `git init`: crear un repo, en tu computadora local
- `git clone [url]`: clonar un repo desde un servicio como github a tu computadora.
- `git status`: muestra el estado de los archivos (Modificado,Staged, pendiendte de push, o si falta hacer un pull)
- `git add`: el index usando el contenido actual del working tree. En general agrega todo el contenido excepto lo ignorado (git ignore), pero puede configurarse con los distintos parámetros. Se puede llegar a usar muchas veces antes de un commit.
	- `git add .`: agrega todo los archivos que esten mas abajo del directorio actual (no de la raíz del repo ) es decir si estoy en en el `root` del `repoistorio` y hago `cd sample`  y luego `git add .` solo se actualizara el index con los archivos que cambiaron dentro de la carpeta `sample` ![[Pasted image 20240822183920.png]]
	- `git add -A`: Es como el `git add .` pero no le importa donde estas parado agrega todos los archivos cambiados a staged.
- `git commit -m "[mensaje]"`: hacer commit, con mensaje de los archivos que estan en `staged`\
- `git pull`:  Incorpora los cambios desde el reposiotrio a la rama actual.
- `git push`:  Actualiza las referencias remotas usando las locales.
- `git branch [name]`: crear nueva branch que referencia el commit en el que estmaos parados
- `git checkout [name]`:  cambiarse a la rama de nombre `name`
	- `git checkout -b [name]`:  crear una rama con nombre `name` y cambiarse a ella.
- `git merge [name]` mergea la rama de nombre `name` a la que estamos parados.
	- Para el oblig deberian de hacer `git merge --no-ff` ya que crea un commit manteniedo la historia del commit.
- `git rebase [name]`: Suponiendo el caso en el que HEAD se encuentre apuntando a una branch testing, cuando ejecutemos el comando `git rebase master`, Git rebobinará la branch testing hasta llegar al primer ancestro en común que tenga con master. Luego aplicará los commits restantes de testing encima de los cambios generados en master. Al finalizar la ejecución testing tendrá incluídos los cambios de master. NO USAR PARA EL OBLIGATORIO.

# Git Flow
Gitflow es un flujo de trabajo definido para Git que nos especifica qué tipo de branches tener y qué propósito cumplen las mismas.
## Flujo basico:
- Dos branches base **develop** y **master**.
- Para trabajar en una funcionalidad creamos una **feature branch**, que tiene como **branch** **base a develop**. Cuando terminamos la funcionalidad la **branch se mergea a develop**.
- **Las ramas feature nunca interactúan con master.**
- **Para integrar a master se crean las ramas release desde develop**

## Ramas Features:
Ramas Features: Rama que se genera a partir de development, donde cada feature/funcionalidad nueva debe ser trabajada, y una vez termianada esta se mergea a develpoment. Algunos Ejemplos:
- feature/createUser
- feature/deleteUser
- feature/changedColorOfIcons

## Ventajas
- Cada funcionalidad del código es englobada en una rama independiente:
	a.El código se vuelve más simple de revisar
	b.Es más fácil relacionar requerimientos funcionalidades con el código donde fueron implementadas
- Reduce el % de conflictos
- Volver al pasado en el código se vuelve más simple
