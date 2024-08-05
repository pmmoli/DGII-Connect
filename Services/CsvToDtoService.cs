namespace DGII_Connect;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class CsvToDtoService(ICompradorService compradorService) : ICsvToDtoService
{
    private readonly ICompradorService _compradorService = compradorService;

    public ICompradorService CompradorService()
    {
        return _compradorService;
    }
    public Factura LoadCsv(string encabezadoFilePath, string detalleFilePath)
    {
        Logger.LogInfo("path: " + encabezadoFilePath);
        var encabezadoLines = FileReader.ReadJsonFile(encabezadoFilePath);
        var detalleLines = FileReader.ReadJsonFile(detalleFilePath);
        List<DetalleBienesOServicios> detalle;
        Factura? factura = null;
        Logger.LogInfo("Loading Json File");

        // if (encabezadoLines.Length == 0)
        // {
        //     throw new InvalidOperationException("The CSV file is empty.");
        // }
        var line = encabezadoLines[0];

        var values = line.Split(',');

        //if (values.Length != 4)
        //    throw new InvalidOperationException("The CSV file format does not match the POCO structure.");
        // 
        //forget about validation for now
        //
        switch (values[0])
        {
            case "32":
                // Handle option1
                detalle = GetDetalle(detalleLines);
                factura = CreateFacturaConsumidorFromValues(values,detalle);
                break;

            case "31":
                detalle = GetDetalle(detalleLines);
                factura = CreateFacturaCreditoFiscalFromValues(values,detalle);
                break;

            default:
                // Handle unknown options
                detalle = GetDetalle(detalleLines);
                factura = CreateFacturaConsumidorFromValues(values,detalle);
                break;
        }

        Logger.LogInfo($"Json Loaded");
        return factura;
   
    }
    private Factura CreateFacturaConsumidorFromValues(string[] values, List<DetalleBienesOServicios> detalle)
    {
        var factura = new Factura
        {
            Fecha = DateTime.Today,
            Encabezado = new Encabezado
            {
                TipoeCF = "32",
                TipoIngresos = values[2],
                IndicadorMontoGravado = values[1],
                TipoPago = values[3],
                Comprador = _compradorService.GetComprador(values[4], values[5])
            },
            DetalleBienesOServicios = detalle
        };
        return factura;
    }
        private Factura CreateFacturaCreditoFiscalFromValues(string[] values, List<DetalleBienesOServicios> detalle)
    {
        var factura = new Factura
        {
            Fecha = DateTime.Today,
            Encabezado = new Encabezado
            {
                TipoeCF = "31",
                FechaVencimientoSecuencia = DateTime.Today.ToString(),
                TipoIngresos = values[2],
                IndicadorMontoGravado = values[1],
                TipoPago = values[3],
                FechaLimitePago = values[6],
                Comprador = _compradorService.GetComprador(values[4], values[5])
            },
            DetalleBienesOServicios = detalle
        };
        return factura;
    }
    private static List<DetalleBienesOServicios> GetDetalle(string[] lines)
    {
        var detalleList = new List<DetalleBienesOServicios>();

    foreach (var line in lines)
    {
        var values = line.Split(',');

        var detalle = new DetalleBienesOServicios
        {
            IndicadorFacturacion = values[0],
            //CodigosItem = [new CodigosItem()],
            NombreItem = values[1],
            IndicadorBienoServicio = values[2],
            //DescripcionItem = "",
            CantidadItem = decimal.Parse(values[3]), 
            //UnidadMedida = 0,
            //CantidadReferencia = 0,
            //UnidadReferencia = "",
            //GradosAlcohol = 0,
            //ImpuestoAdicional = "",
            PrecioUnitarioReferencia = decimal.Parse(values[4]),
            //FechaElaboracion = DateTime.MinValue,
            //FechaVencimientoItem = DateTime.MinValue,
            // Mineria = new Mineria(), // Mock Object
            // SubCantidad = "",
            //SubDescuento = "",
            // Subrecargo = "",
            PrecioUnitarioItem = decimal.Parse(values[4]),
            DescuentoMonto = decimal.Parse(values[5])
        };

        detalleList.Add(detalle);
    }

    return detalleList;

    }
}

    
