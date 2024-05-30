namespace DGII_Connect;

public interface ICsvToDtoService
{
    Factura LoadCsv(string encabezadoFilePath, string detalleFilePath);
}
