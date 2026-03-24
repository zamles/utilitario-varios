# 🧰 Utilitarios Varios - Herramientas de Desarrollo

> Colección de utilidades reutilizables para acelerar el desarrollo de soluciones empresariales con .NET, SQL Server y herramientas varias.

![Estado](https://img.shields.io/badge/estado-mantenimiento-green)
![Licencia](https://img.shields.io/badge/licencia-MIT-green)
![C#](https://img.shields.io/badge/C%23-.NET%206+-239120?logo=csharp)
![SQL](https://img.shields.io/badge/SQL-Server%202014+-CC2927?logo=microsoftsqlserver)
![PowerBI](https://img.shields.io/badge/Power%20BI-F2C811?logo=powerbi&logoColor=black)

---

## 🎯 Propósito del Repositorio

Este repositorio centraliza **utilidades reutilizables** desarrolladas durante mi experiencia como Analista Programador, diseñadas para:

- ✅ **Acelerar el desarrollo**: Funciones comunes listas para usar
- ✅ **Estandarizar prácticas**: Patrones consistentes en múltiples proyectos
- ✅ **Reducir código repetitivo**: Helpers para operaciones frecuentes

### 📦 Categorías de Utilidades

| Categoría | Descripción | Tecnologías |
|-----------|-------------|-------------|
| 🔐 **Security** | Helpers para almacenamiento de logs de errores o eventos | C# |
| 📁 **File Utils** | Lectura/escritura de documentos | C# |

---

## 🚀 Utilidades Destacadas

```csharp
// Ejemplo: Extensiones para manipulación de documentos y logs
 public class DocServices
    {
   /// <summary>
        /// Sube el documento al servidor directamente a la carpeta declarada
        /// </summary>
        /// <param name="archivo">Fileupload.PostedFile archivo a subir</param>
        /// <param name="carpeta">Nonbre de la carpeta</param>
        /// <param name="idTipo">por defecto es 0, equivale el tipo de documeto</param>
        /// <returns>Objeto de tipo Documento</returns>        
        public Documento UpDoc(HttpPostedFile archivo, string carpeta, int idTipo = 0) { ... }
    
    /// <summary>
        /// Sube el documento al servidor directamente a la carpeta declarada
        /// </summary>
        /// <param name="archivo">Fileupload.PostedFile archivo a subir</param>
        /// <param name="carpeta">Nonbre de la carpeta</param>
        /// <param name="idTipo">Equivale el tipo de documeto</param>
        /// <returns>Objeto de tipo DocumentoGuid</returns>        
        public DocumentoGuid UpDoc(HttpPostedFile archivo, string carpeta, Guid idTipo) { ... }
  }

public class MyLogs
  {
   /// <summary>
        /// Escribe los logs 
        /// </summary>
        /// <param name="message">mensaje a escribir</param>
        /// <param name="clase">nombre de la clase a la que pertencen</param>
        public void WriteLog(string message, string clase) { ... }
  }
