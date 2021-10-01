namespace Servicios.Colecciones.Interfaces
{
    public interface iCola<Tipo>
    {
        bool encolar(Tipo prmItem);
        bool desencolar(ref Tipo prmItem);
        bool revisar(ref Tipo prmItem);
    }
}