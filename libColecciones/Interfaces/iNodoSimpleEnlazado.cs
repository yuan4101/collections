using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Interfaces
{
    interface iNodoSimpleEnlazado<Tipo> : iNodo<Tipo>
    {
        clsNodoSimpleEnlazado<Tipo> darSiguiente();
        bool conectar(clsNodoSimpleEnlazado<Tipo> prmNodo);
        bool desconectar(ref clsNodoSimpleEnlazado<Tipo> prmNodo);
    }
}