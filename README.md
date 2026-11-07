# Examen Final Programación II – Tema II: Sistema de Productos

**Alumna:** Daniela Paola Grajeda Sandoval · **Carné:** 0900-25-15929 · **Sección:** A

Aplicación web para registrar, listar y eliminar productos, guardados en SQL Server.

## Tecnología
- ASP.NET Web Forms (.aspx con code-behind y Site.Master), .NET Framework 4.8, C#
- Bootstrap 5 (archivos locales en `Content/` y `Scripts/`)
- SQL Server Express con ADO.NET y consultas parametrizadas
- Sin paquetes NuGet

## Estructura
| Proyecto | Capa | Contenido |
|---|---|---|
| `CapaEntidadesDG` | Entidades | `clsProductoDG` |
| `CapaDatosDG` | Datos | `clsConexionDG`, `clsProductoDatosDG` |
| `CapaNegocioDG` | Negocio | `clsProductoNegocioDG`, `clsResultadoDG` |
| `WebExamenFinalDG` | Presentación | `Site.Master`, `Default.aspx`, `About.aspx`, `Contact.aspx`, `clsConfiguracionAlumnoDG` |
| `BaseDatosDG` | Base de datos | `scrExamenFinalProductosDG.sql` |

**Estándares**
- Los identificadores propios terminan en `DG`.
- Prefijos de tipo y ámbito: `cls`, `Fnc`, `Pro`, `lstr`, `ldec`, `pobj`, `txt`, `btn`, `gv`, etc.
- Documentación con comentarios XML (`///`).
- Archivos en UTF-8 y `fileEncoding="utf-8"` en `Web.config`.

## Funcionalidad
- **Inicio:** registro de producto (código, nombre, precio en $, existencias) e inventario con la acción **Eliminar**, que pide confirmación.
- **Validaciones:** campos obligatorios, formato de código, precio con máximo 2 decimales y existencias enteras. Se revisan en el navegador y en el servidor. No se permiten códigos duplicados.
- **Acerca de:** descripción de la aplicación.
- **Contacto:** datos del alumno leídos de `appSettings` en `Web.config`.

## Requisitos
- Visual Studio 2022 con la carga de trabajo **ASP.NET y desarrollo web** y el paquete de destino de .NET Framework 4.8
- SQL Server Express y SQL Server Management Studio
- IIS, solo para la publicación

## Base de datos
1. Abrir `BaseDatosDG/scrExamenFinalProductosDG.sql` en SSMS y ejecutarlo.
2. El script crea la base `ExamenFinalProductosDG`, la tabla `dbo.tblProductoDG` y los datos de ejemplo, solo si no existen. No elimina información.

## Configuración (`WebExamenFinalDG/Web.config`)
- **Cadena de conexión `cnnExamenDG`:** `Data Source=ML-RefVm-941826\SQLEXPRESS;Initial Catalog=ExamenFinalProductosDG;Integrated Security=True`. Ajustar `Data Source` al servidor local.
- **`appSettings`:** `AlumnoNombreDG`, `AlumnoCarneDG`, `AlumnoSeccionDG`, `AlumnoCursoDG`, y `AlumnoCorreoDG` (opcional; si queda vacío no se muestra).

## Compilación y ejecución local
1. Abrir `ExamenFinalProductos_DanielaGrajedaDG.sln`.
2. Establecer `WebExamenFinalDG` como proyecto de inicio y `Default.aspx` como página de inicio.
3. Compilar con **Ctrl+Shift+B** y ejecutar con **Ctrl+F5**. La aplicación corre en IIS Express en `http://localhost:51240/`.

IIS Express sirve solo para desarrollo. La publicación en IIS se describe abajo.

## Publicación en IIS
1. **Habilitar IIS** en *Activar o desactivar las características de Windows* (en Windows Server: *Agregar roles y características*, rol *Servidor web (IIS)*) con:
   - Herramientas de administración web → Consola de administración de IIS
   - Servicios World Wide Web → Características de desarrollo de aplicaciones: **ASP.NET 4.8** (o 4.x), **Extensibilidad de .NET 4.8**, **Extensiones ISAPI**, **Filtros ISAPI**
   - Servicios World Wide Web → Características HTTP comunes: **Documento predeterminado**, **Contenido estático**
2. **Publicar:** en Visual Studio, *WebExamenFinalDG → Publicar → Carpeta → `C:\inetpub\ProductosDG`*, configuración **Release**.
3. **Grupo de aplicaciones:** en el Administrador de IIS (`inetmgr`), crear el grupo `ProductosDG` con *.NET CLR v4.0* y modo *Integrado*.
4. **Sitio:** crear el sitio `ProductosDG` con ruta física `C:\inetpub\ProductosDG`, grupo `ProductosDG`, enlace http y puerto **8085**.
5. **Permisos de carpeta:** dar a `IIS AppPool\ProductosDG` *Lectura y ejecución* sobre `C:\inetpub\ProductosDG`.
6. **Permisos en SQL Server** (SQL Express en el mismo equipo; ejecutar en SSMS como administrador):
```sql
USE master;
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'IIS APPPOOL\ProductosDG')
    CREATE LOGIN [IIS APPPOOL\ProductosDG] FROM WINDOWS;
GO
USE ExamenFinalProductosDG;
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = N'IIS APPPOOL\ProductosDG')
    CREATE USER [IIS APPPOOL\ProductosDG] FOR LOGIN [IIS APPPOOL\ProductosDG];
GRANT SELECT, INSERT, DELETE ON dbo.tblProductoDG TO [IIS APPPOOL\ProductosDG];
GO
```
7. **Verificar:** abrir `http://localhost:8085/`.

## Entregables
- Capturas del código
- Capturas de cada pantalla en ejecución (IIS Express e IIS)
- Evidencia de la conexión a la base de datos (tabla consultada en SSMS)
- Código en ZIP, sin `bin`, `obj` ni `.vs`
