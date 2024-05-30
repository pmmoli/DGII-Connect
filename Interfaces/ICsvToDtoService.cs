namespace DGII_Connect;

public interface ICsvToDtoService 
{
    ICompradorService CompradorService();
    Factura LoadCsv(string encabezadoFilePath, string detalleFilePath);
}
