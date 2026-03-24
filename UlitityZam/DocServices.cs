using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace UlitityZam
{
    public class DocServices
    {
        private readonly string _rootPath;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="rootPath">Carpeta root</param>
        public DocServices(string rootPath)
        {            
            _rootPath = rootPath;
        }
        /// <summary>
        /// Sube el documento al servidor directamente a la carpeta declarada
        /// </summary>
        /// <param name="archivo">Fileupload.PostedFile archivo a subir</param>
        /// <param name="carpeta">Nonbre de la carpeta</param>
        /// <param name="idTipo">por defecto es 0, equivale el tipo de documeto</param>
        /// <returns>Objeto de tipo Documento</returns>        
        public Documento UpDoc(HttpPostedFile archivo, string carpeta, int idTipo = 0)
        {
            if (archivo == null || archivo.ContentLength == 0)
                throw new ArgumentException("El archivo no puede ser nulo o estar vacío");

            // Crear la carpeta de la solicitud si no existe
            string solicitudPath = Path.Combine(_rootPath, carpeta);
            if (!Directory.Exists(solicitudPath))
            {
                Directory.CreateDirectory(solicitudPath);
            }

            // Generar el nuevo nombre del archivo
            string extension = Path.GetExtension(archivo.FileName);
            string nombreGuardado = Guid.NewGuid().ToString() + extension;
            string rutaCompleta = Path.Combine(solicitudPath, nombreGuardado);

            // Guardar el archivo en la carpeta correspondiente
            archivo.SaveAs(rutaCompleta);

            // Crear la entidad de documento
            var documento = new Documento
            {
                NombreOriginal = archivo.FileName,
                NombreGuardado = nombreGuardado,
                Extension = extension,
                Ubicacion = rutaCompleta,
                Carpeta = carpeta,
                FechaSubida = DateTime.Now,
                IdTipo = idTipo
            };

            return documento;
        }
        /// <summary>
        /// Sube el documento al servidor directamente a la carpeta declarada
        /// </summary>
        /// <param name="archivo">Fileupload.PostedFile archivo a subir</param>
        /// <param name="carpeta">Nonbre de la carpeta</param>
        /// <param name="idTipo">Equivale el tipo de documeto</param>
        /// <returns>Objeto de tipo DocumentoGuid</returns>        
        public DocumentoGuid UpDoc(HttpPostedFile archivo, string carpeta, Guid idTipo)
        {
            if (archivo == null || archivo.ContentLength == 0)
                throw new ArgumentException("El archivo no puede ser nulo o estar vacío");

            // Crear la carpeta de la solicitud si no existe
            string solicitudPath = Path.Combine(_rootPath, carpeta);
            if (!Directory.Exists(solicitudPath))
            {
                Directory.CreateDirectory(solicitudPath);
            }

            // Generar el nuevo nombre del archivo
            string extension = Path.GetExtension(archivo.FileName);
            string nombreGuardado = Guid.NewGuid().ToString() + extension;
            string rutaCompleta = Path.Combine(solicitudPath, nombreGuardado);

            // Guardar el archivo en la carpeta correspondiente
            archivo.SaveAs(rutaCompleta);

            // Crear la entidad de documento
            var documento = new DocumentoGuid
            {
                NombreOriginal = archivo.FileName,
                NombreGuardado = nombreGuardado,
                Extension = extension,
                Ubicacion = rutaCompleta,
                Carpeta = carpeta,
                FechaSubida = DateTime.Now,
                IdTipo = idTipo
            };

            return documento;
        }


        public DocumentoGuid UpDoc(Stream archivoStream, string nombreOriginal, string carpeta, Guid idTipo)
        {
            if (archivoStream == null || archivoStream.Length == 0)
                throw new ArgumentException("El archivo no puede ser nulo o estar vacío");

            // Crear la carpeta si no existe
            string solicitudPath = Path.Combine(_rootPath, carpeta);
            if (!Directory.Exists(solicitudPath))
            {
                Directory.CreateDirectory(solicitudPath);
            }

            // Generar el nuevo nombre del archivo
            string extension = Path.GetExtension(nombreOriginal);
            string nombreGuardado = Guid.NewGuid().ToString() + extension;
            string rutaCompleta = Path.Combine(solicitudPath, nombreGuardado);

            // Guardar el archivo desde el stream
            using (var fileStream = File.Create(rutaCompleta))
            {
                archivoStream.CopyTo(fileStream);
            }

            // Crear la entidad de documento
            var documento = new DocumentoGuid
            {
                NombreOriginal = nombreOriginal,
                NombreGuardado = nombreGuardado,
                Extension = extension,
                Ubicacion = rutaCompleta,
                Carpeta = carpeta,
                FechaSubida = DateTime.Now,
                IdTipo = idTipo
            };

            return documento;
        }




        /// <summary>
        /// Sube el documento al servidor en la carpeta temp
        /// </summary>
        /// <param name="archivo">Fileupload.PostedFile archivo a subir</param>        
        /// <param name="idTipo">por defecto es 0, equivale el tipo de documeto</param>
        /// <returns>Objeto de tipo Documento</returns>        
        public Documento UpDocTemp(HttpPostedFile archivo,int idTipo = 0)
        {
            if (archivo == null || archivo.ContentLength == 0)
                throw new ArgumentException("El archivo no puede ser nulo o estar vacío");

            // Crear la carpeta temporal si no existe
            string temporalPath = Path.Combine(_rootPath, "temp");
            if (!Directory.Exists(temporalPath))
            {
                Directory.CreateDirectory(temporalPath);
            }

            // Generar el nuevo nombre del archivo
            string extension = Path.GetExtension(archivo.FileName);
            string nombreGuardado = Guid.NewGuid().ToString() + extension;
            string rutaCompleta = Path.Combine(temporalPath, nombreGuardado);

            // Guardar el archivo en la carpeta temporal
            archivo.SaveAs(rutaCompleta);

            // Crear la entidad de documento con la ruta temporal
            var documento = new Documento
            {
                NombreOriginal = archivo.FileName,
                NombreGuardado = nombreGuardado,
                Extension = extension,                
                Ubicacion = rutaCompleta,
                Carpeta = string.Empty,
                FechaSubida = DateTime.Now,
                IdTipo = idTipo
            };            

            return documento;
        }
        /// <summary>
        /// Sube el documento al servidor en la carpeta temp
        /// </summary>
        /// <param name="archivo">Fileupload.PostedFile archivo a subir</param>        
        /// <param name="idTipo">Equivale el tipo de documeto</param>
        /// <returns>Objeto de tipo DocumentoGuid</returns>   
        public DocumentoGuid UpDocTemp(HttpPostedFile archivo, Guid idTipo)
        {
            if (archivo == null || archivo.ContentLength == 0)
                throw new ArgumentException("El archivo no puede ser nulo o estar vacío");

            // Crear la carpeta temporal si no existe
            string temporalPath = Path.Combine(_rootPath, "temp");
            if (!Directory.Exists(temporalPath))
            {
                Directory.CreateDirectory(temporalPath);
            }

            // Generar el nuevo nombre del archivo
            string extension = Path.GetExtension(archivo.FileName);
            string nombreGuardado = Guid.NewGuid().ToString() + extension;
            string rutaCompleta = Path.Combine(temporalPath, nombreGuardado);

            // Guardar el archivo en la carpeta temporal
            archivo.SaveAs(rutaCompleta);

            // Crear la entidad de documento con la ruta temporal
            var documento = new DocumentoGuid
            {
                NombreOriginal = archivo.FileName,
                NombreGuardado = nombreGuardado,
                Extension = extension,
                Ubicacion = rutaCompleta,
                Carpeta = string.Empty,
                FechaSubida = DateTime.Now,
                IdTipo = idTipo
            };

            return documento;
        }

        /// <summary>
        /// Mueve el documentos descrito en el Objeto de la carpeta temp a la carpeta designada
        /// </summary>
        /// <param name="documento">Objeto documento</param>
        /// <param name="carpeta">Carpeta designada</param>
        /// <returns>Regresa el objeto con ya con la nueva ruta</returns>
        public Documento MoveDoc(Documento documento, string carpeta)
        {
            // Crear la carpeta de la solicitud si no existe
            string solicitudPath = Path.Combine(_rootPath, carpeta);
            if (!Directory.Exists(solicitudPath))
            {
                Directory.CreateDirectory(solicitudPath);
            }

            // Generar la nueva ruta completa
            string nuevaRutaCompleta = Path.Combine(solicitudPath, documento.NombreGuardado);

            // Mover el archivo de la carpeta temporal a la carpeta de la solicitud
            File.Move(documento.Ubicacion, nuevaRutaCompleta);

            // Actualizar la ruta en la entidad de documento
            documento.Ubicacion = nuevaRutaCompleta;
            documento.Carpeta = carpeta;

            return documento;            
        }
        /// <summary>
        /// Mueve el documentos descrito en el Objeto de la carpeta temp a la carpeta designada
        /// </summary>
        /// <param name="documento">Objeto documentoGuid</param>
        /// <param name="carpeta">Carpeta designada</param>
        /// <returns>Regresa el objeto con ya con la nueva ruta</returns>
        public DocumentoGuid MoveDoc(DocumentoGuid documento, string carpeta)
        {
            // Crear la carpeta de la solicitud si no existe
            string solicitudPath = Path.Combine(_rootPath, carpeta);
            if (!Directory.Exists(solicitudPath))
            {
                Directory.CreateDirectory(solicitudPath);
            }

            // Generar la nueva ruta completa
            string nuevaRutaCompleta = Path.Combine(solicitudPath, documento.NombreGuardado);

            // Mover el archivo de la carpeta temporal a la carpeta de la solicitud
            File.Move(documento.Ubicacion, nuevaRutaCompleta);

            // Actualizar la ruta en la entidad de documento
            documento.Ubicacion = nuevaRutaCompleta;
            documento.Carpeta = carpeta;

            return documento;
        }

        /// <summary>
        /// Elimina un archivo
        /// </summary>
        /// <param name="filePath">direccion del archivo</param>
        /// <returns></returns>
        public bool DeleteFile(string filePath)
        {
            try
            {
                // Verificar si el archivo existe antes de eliminarlo
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }
        /// <summary>
        /// Descargar el Documento 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>false: no se encontro el archivo</returns>
        public bool DownloadFile(string filePath,string nombre = null)
        {
            if (File.Exists(filePath))
            {
                
                string fileName = Path.GetFileName(filePath);
                string name = nombre ?? fileName;

                HttpContext.Current.Response.Clear();                
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment; filename={name}");                
                HttpContext.Current.Response.WriteFile(filePath);                
                HttpContext.Current.Response.End();

                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public class Documento
    {        
        public string NombreOriginal { get; set; }
        public string NombreGuardado { get; set; }
        public string Extension { get; set; }        
        public string Ubicacion { get; set; }
        public string Carpeta { get; set; }
        public DateTime FechaSubida { get; set; }
        public int IdTipo { get; set; }
    }
    public class DocumentoGuid
    {
        public string NombreOriginal { get; set; }
        public string NombreGuardado { get; set; }
        public string Extension { get; set; }
        public string Ubicacion { get; set; }
        public string Carpeta { get; set; }
        public DateTime FechaSubida { get; set; }
        public Guid IdTipo { get; set; }
    }
}
