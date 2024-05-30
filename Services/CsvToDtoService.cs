namespace DGII_Connect;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class CsvToDtoService : ICsvToDtoService
{
    public Factura LoadCsv(string encabezadoFilePath, string detalleFilePath)
    {
        var encabezadoLines = File.ReadAllLines(encabezadoFilePath);
        var detalleLines = File.ReadAllLines(detalleFilePath);
        List<DetalleBienesOServicios> detalle = GetDetalle(detalleLines);

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
            NumeroFacturaInterna = "",
            Sucursal = "",
            CodigoVendedor = "",
            Encabezado = new Encabezado
            {
                eNCF = values[0],
                TipoIngresos = values[1],
                IndicadorMontoGravado = "",
                TipoPago = values[2],
                FechaLimitePago = "",
                FormasPago = [new FormasPago { MontoPago = int.Parse(values[3]), FormaPago = values[4] }],
                TipoCuentaPago = "",
                NumeroCuentaPago = "",
                BancoPago = "",
                Comprador = values.GetComprador(), // Mock Comprador instance
                TotalPaginas = 1,
                Transporte = values.GetTransporte(), // Mock Transporte instance
                OtraMoneda = new OtraMoneda
                {
                    TipoMoneda = "",
                    TipoCambio = 0
                } // Mock OtraMoneda instance
            },
            DetalleBienesOServicios = detalle,
            DescuentosORecargos = [new DescuentosORecargos()],
            InformacionReferencia = new InformacionReferencia()
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
            CodigosItem =
            [
                new() { TipoCodigo = "", CodigoItem = "" }
            ],
            NombreItem = values[1],
            IndicadorBienoServicio = values[2],
            DescripcionItem = "",
            CantidadItem = decimal.Parse(values[3]),
            UnidadMedida = 0,
            CantidadReferencia = 0,
            UnidadReferencia = "",
            GradosAlcohol = 0,
            PrecioUnitarioReferencia = decimal.Parse(values[4]),
            FechaElaboracion = DateTime.MinValue,
            FechaVencimientoItem = DateTime.MinValue,
            Mineria = new Mineria(), // Mock Object
            SubDescuento = [new SubDescuento()], // Mock Object
            Subrecargo = [new Subrecargo()], // Mock Object
            PrecioUnitarioItem = 0,
            DescuentoMonto = 0
        };

        detalleList.Add(detalle);
    }

    return detalleList;

    }
}

    
