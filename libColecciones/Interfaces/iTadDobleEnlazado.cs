using Servicios.Colecciones.Nodos;
namespace Servicios.Colecciones.Interfaces
{
    interface iTadDobleEnlazado<Tipo> : iTad<Tipo>
    {
        clsNodoDobleEnlazado<Tipo> darPrimero();
        clsNodoDobleEnlazado<Tipo> darUltimo();
    }
}