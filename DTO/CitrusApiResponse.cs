using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII_Connect;

    public class CitrusApiResponse
    {
        public static readonly string ESTATUS_ERROR_VALIDACION_API = "Error Interno";
        public static readonly string ESTADO_ECF_NO_ENVIADO_DGII = "No Enviado a DGII";
        public static readonly string ERROR_COMUNICACION_API = "Error de Comunicación con Citrus eCF API";


        public int TransaccionId { get; set; }
        public string? eNCF { get; set; }
        public string? TrackId { get; set; }
        public string? Estatus { get; set; }
        public string? EstadoeCF { get; set; }
        public string? Mensaje { get; set; }
        public string? UrlCodigoQr { get; set; }
        public string? CodigoSeguridad { get; set; }
        public DateTime? FechaFirmaDigital { get; set; }
    }