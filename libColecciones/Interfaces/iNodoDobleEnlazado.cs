using Servicios.Colecciones.Nodos;
namespace Servicios.Colecciones.Interfaces
{
    interface iNodoDobleEnlazado<Tipo> : iNodo<Tipo>
    {
        clsNodoDobleEnlazado<Tipo> darAnterior();
        clsNodoDobleEnlazado<Tipo> darSiguiente();
        bool conectar(clsNodoDobleEnlazado<Tipo> prmNodo);
        bool desconectar(ref clsNodoDobleEnlazado<Tipo> prmNodo);
    }
}
