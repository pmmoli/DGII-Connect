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
        var encabezadoLines = FileReader.ReadJsonFile(encabezadoFilePath);
        var detalleLines = FileReader.ReadJsonFile(detalleFilePath);
        List<DetalleBienesOServicios> detalle = GetDetalle(detalleLines);
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

        var factura = new Factura
        {
            
            Fecha = DateTime.Today,
            // NumeroFacturaInterna = "",
            // Sucursal = "",
            // CodigoVendedor = "",
            Encabezado = new Encabezado
            {
                eNCF = values[0],
                TipoIngresos = values[1],
                IndicadorMontoGravado = "0",
                // InformacionesAdicionales = new InformacionesAdicionales(),
                TipoPago = values[2],
                // FechaLimitePago = "",
                // FormasPago = [new FormasPago { MontoPago = int.Parse(values[5]), FormaPago = values[6] }],
                //TipoCuentaPago = "",
                //NumeroCuentaPago = "",
                //BancoPago = "",
                Comprador = _compradorService.GetComprador(values[3],values[4]), // Mock Comprador instance
                // TotalPaginas = 1,
                // Transporte = values.GetTransporte(), // Mock Transporte instance
                // OtraMoneda = new OtraMoneda
                // {
                //     TipoMoneda = "DOP",
                //     TipoCambio = 0
                // } // Mock OtraMoneda instance
 // Mock OtraMoneda instance
            },
            DetalleBienesOServicios = detalle,
            //DescuentosORecargos = [new DescuentosORecargos()],
            // DescuentosORecargos = "",
            // InformacionReferencia = new InformacionReferencia()
        };
        Logger.LogInfo($"Json Loaded");
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

    
