# Blazor - Repaso

### **¿Qué es Blazor?**

Blazor es un framework de **Microsoft** que permite desarrollar aplicaciones web interactivas utilizando **C#** en lugar de **JavaScript**. Se basa en la combinación de **HTML**, **CSS** y **C#** para generar aplicaciones con una interfaz de usuario dinámica, similar a **SPA (Single Page Applications)**.

### **Estructura del Proyecto Blazor**

- **Pages**: Contiene las diferentes vistas o páginas, cada archivo tiene extensión `.razor` y define el contenido visible en la aplicación.
- **Shared**: Incluye componentes reutilizables como encabezados, pies de página, y menús de navegación que se pueden compartir entre varias páginas.
- **Data**: Puede usarse para gestionar la capa de acceso a datos (aunque en muchos casos es preferible separarla en otro proyecto).
- **BusinessLogic**: Separar la lógica del negocio es una buena práctica que permite un mantenimiento más sencillo y pruebas independientes.

### **Directivas en Blazor**

- **`@page`**: Define la URL asociada a una página específica en Blazor.
- **`@code`**: Permite combinar código C# con la interfaz de usuario (HTML), lo que facilita el manejo de lógica directamente en los archivos `.razor`.
- **`@inject`**: Inyecta dependencias o servicios en los componentes para que puedan usarse dentro del código.

### **Inyección de Dependencias**

Blazor permite utilizar la **Inyección de Dependencias (DI)** para proporcionar servicios y gestionar datos a lo largo de la aplicación. Se registra un servicio en `Program.cs` mediante `builder.Services.AddSingleton<VehicleService>()`, lo que asegura que el servicio esté disponible durante la ejecución de la aplicación.

Ejemplo de inyección:

```csharp
@inject VehicleService VehicleService
```

### **Uso de Servicios**:

Los servicios como `VehicleService` permiten gestionar la lógica del negocio, como agregar, eliminar o actualizar datos. Un ejemplo típico es cargar una lista de vehículos desde el servicio:

```csharp
@code {
    private List<Vehicle> _vehicles;

    protected override void OnInitialized() {
        _vehicles = VehicleService.Vehicles;
    }
}
```

### **Manejo de Datos en Blazor**

Blazor te permite mostrar datos en la interfaz de usuario utilizando la directiva `@foreach` para recorrer listas de objetos. Ejemplo de cómo listar vehículos:

```csharp
<table>
    @foreach (var vehicle in _vehicles) {
        <tr>
            <td>@vehicle.DoorQuantity</td>
            <td>@vehicle.Color</td>
        </tr>
    }
</table>

```

### 7. **Eventos y Métodos en Blazor**

Blazor permite manejar eventos directamente desde el HTML, como el clic de un botón:

```html
<button @onclick="AddVehicle">Agregar Vehículo</button
```

Este evento ejecuta el método `AddVehicle` definido en el bloque `@code`:

```csharp
void AddVehicle() {
    VehicleService.AddVehicle(new Vehicle(...));
}
```

### **Estados y Ciclo de Vida de los Componentes**

Blazor tiene varios métodos en su ciclo de vida, como `OnInitialized()` y `OnParametersSet()`, que permiten inicializar y gestionar el estado de los componentes.

### **Base de Datos en Memoria**

Para las primeras aplicaciones de prueba, se pueden utilizar bases de datos en memoria registradas con DI, por ejemplo:

```csharp
builder.Services.AddSingleton<MemoryDatabase>();
```

Luego, puedes inyectar el servicio en una página y mostrar datos desde la base:

```csharp
@inject MemoryDatabase MemoryDatabase
```

### **Bootstrap para Estilos**:

Blazor utiliza Bootstrap por defecto para proporcionar un diseño web responsivo y moderno. Los componentes como tablas y botones ya vienen estilizados con clases de Bootstrap:

```html
<table class="table">
    ...
</table>
```

### **Crear, Editar, Listar y Eliminar Elementos**:

Blazor permite implementar fácilmente operaciones CRUD. Un ejemplo sería:

- **Listar**: Utilizando `@foreach` para mostrar elementos en una tabla.
- **Agregar**: Mediante formularios vinculados con `@bind` para capturar datos del usuario.
- **Editar**: Permitiendo editar campos mediante rutas dinámicas y utilizando parámetros (`@page "/items/{id:int}/edit"`).
- **Eliminar**: Asignando un evento `@onclick` a un botón para ejecutar la acción de borrado.
