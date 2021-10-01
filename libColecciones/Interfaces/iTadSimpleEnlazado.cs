using Servicios.Colecciones.Nodos;
namespace Servicios.Colecciones.Interfaces
{
    interface iTadSimpleEnlazado<Tipo> : iTad<Tipo>
    {
        clsNodoSimpleEnlazado<Tipo> darPrimero();
        clsNodoSimpleEnlazado<Tipo> darUltimo();
    }
}
