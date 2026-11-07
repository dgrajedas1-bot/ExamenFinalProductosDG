# Examen Final Programación II – Tema II: Sistema de Productos (DG)

**Alumna:** Daniela Paola Grajeda Sandoval · **Carné:** 0900-25-15929 · **Sección:** A
**Tecnología:** ASP.NET Web Forms (.aspx + code-behind + Site.Master) · .NET Framework 4.8 · Bootstrap 5 (local) · SQL Server Express (ADO.NET)

## Qué hace
- Menú **Examen Final | Inicio | Acerca de | Contacto**.
- **Inicio:** tarjeta *Nuevo Producto* (Código, Nombre, Precio $, Stock, botón **Guardar Producto**) y tarjeta *Inventario Actual*.
  - Guardar inserta en la base de datos y la tabla se actualiza al instante.
  - **Eliminar** (solo en el inventario) pide confirmación y borra el producto de la base.
  - Validaciones en el navegador y en el servidor, precios siempre con 2 decimales y mensajes de error amigables.
- **Contacto:** nombre, carné, sección y curso, configurables en `Web.config` (`appSettings`).
- **Acerca de:** texto del examen.

## Estructura (capas)
| Proyecto | Contenido |
|---|---|
| `CapaEntidadesDG` | `clsProductoDG` |
| `CapaDatosDG` | `clsConexionDG`, `clsProductoDatosDG` (SQL parametrizado) |
| `CapaNegocioDG` | `clsProductoNegocioDG`, `clsResultadoDG` (reglas y mensajes) |
| `WebExamenFinalDG` (capa de presentación) | `Site.Master`, `Default.aspx`, `About.aspx`, `Contact.aspx` |
| `BaseDatosDG` | `scrExamenFinalProductosDG.sql` |

Todos los archivos están guardados en UTF-8 con BOM y el sitio usa `fileEncoding="utf-8"`, para que las tildes se vean bien. Todo el código propio tiene sufijo **DG** y comentarios XML (`///`). No usa paquetes NuGet ni CodeDom.

## Actualizar si ya tenías la versión anterior
- **Si clonaste con Git:** cierra la solución, ejecuta **Git → Extraer (Pull)** o `git pull` y vuelve a abrir `ExamenFinalProductos_DanielaGrajedaDG.sln`. Si Visual Studio muestra los proyectos viejos (`EntidadesDG`, `DatosDG`, `NegocioDG`) como no disponibles, borra las carpetas viejas que hayan quedado vacías o con `bin`/`obj`.
- **Si usas el ZIP:** extráelo en una **carpeta nueva**, cierra la solución anterior y abre la nueva.
- **La base de datos existente sirve tal cual**; no hay que recrearla. Si cambiaste `Data Source` en `Web.config`, vuelve a poner tu servidor.
- Opcional, solo para que el producto de ejemplo lleve tilde en una BD ya creada:
  `UPDATE dbo.tblProductoDG SET NombreDG = N'Tablet Gráfica' WHERE CodigoDG = N'PRD-003' AND NombreDG = N'Tablet Grafica';`

## Pasos en la máquina virtual (Visual Studio 2022)
1. **Requisito:** en el Visual Studio Installer, carga de trabajo **ASP.NET y desarrollo web**, con el componente *.NET Framework 4.8 targeting pack*.
2. **Clonar:** en Visual Studio, *Clonar un repositorio* → `https://github.com/dgrajedas1-bot/ExamenFinalProductosDG.git`.
3. **Abrir** `ExamenFinalProductos_DanielaGrajedaDG.sln`.
4. **Base de datos:** abre SSMS conectado a `ML-RefVm-941826\SQLEXPRESS` (Autenticación de Windows). Abre `BaseDatosDG\scrExamenFinalProductosDG.sql` y ejecútalo (F5). Crea la BD `ExamenFinalProductosDG`, la tabla `tblProductoDG` y 3 productos, uno con tu nombre. No borra nada.
5. **Cadena de conexión:** si tu servidor tiene otro nombre, cambia `Data Source` en `WebExamenFinalDG\Web.config` (`cnnExamenDG`).
6. **Proyecto de inicio:** clic derecho en `WebExamenFinalDG` → *Establecer como proyecto de inicio*. Clic derecho en `Default.aspx` → *Establecer como página de inicio*.
7. **Compilar** (Ctrl+Shift+B) y **ejecutar** con IIS Express (Ctrl+F5). Se abre `http://localhost:51240/`.
8. **Probar:** guarda un producto, intenta guardar con campos vacíos o un código repetido y elimina un producto (acepta la confirmación).

## Publicar en IIS (rúbrica)
1. Activa IIS: *Panel de control → Programas → Activar o desactivar características de Windows*.
   - **Internet Information Services**
   - *Servicios World Wide Web → Características de desarrollo de aplicaciones*: **ASP.NET 4.8**, **Extensibilidad .NET 4.8**, **Extensiones ISAPI** y **Filtros ISAPI**
2. En Visual Studio: clic derecho en `WebExamenFinalDG` → **Publicar** → *Carpeta* → `C:\inetpub\wwwroot\ExamenFinalDG` → **Publicar**.
3. Abre el **Administrador de IIS** → *Sitios → Default Web Site* → clic derecho en `ExamenFinalDG` → **Convertir en aplicación** (grupo *DefaultAppPool*, .NET CLR v4.0).
4. **Permiso en SQL:** el sitio en IIS se conecta como `IIS APPPOOL\DefaultAppPool`. Ejecuta esto en SSMS:
   ```sql
   CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS;
   USE ExamenFinalProductosDG;
   CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool];
   ALTER ROLE db_datareader ADD MEMBER [IIS APPPOOL\DefaultAppPool];
   ALTER ROLE db_datawriter ADD MEMBER [IIS APPPOOL\DefaultAppPool];
   ```
5. Abre `http://localhost/ExamenFinalDG/` y toma la captura.

## Entrega (según el examen)
- Pantallazos del código y de cada pantalla en ejecución, con tus datos visibles.
- Evidencia de la conexión a la BD (SSMS con la tabla y sus datos).
- Zip del código sin `bin`, `obj` ni `.vs`.
- Pega todo en el Word del examen.
