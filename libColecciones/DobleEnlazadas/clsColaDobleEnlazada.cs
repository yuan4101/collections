using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsColaDobleEnlazada<Tipo> : iTadDobleEnlazado<Tipo>, iCola<Tipo>
    {
        #region Atributos
        public int atrLongitud;
        public clsNodoDobleEnlazado<Tipo> atrPrimero;
        public clsNodoDobleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Metodos
        #region Constructores
        public clsColaDobleEnlazada()
        {
            atrLongitud = 0;
            atrPrimero = null;
            atrUltimo = null;
        }
        #endregion
        #region Accesores
        public int darLongitud()
        {
            return atrLongitud;
        }
        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion
        #region CRUDS
        public bool encolar(Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> objNodo = new clsNodoDobleEnlazado<Tipo>(prmItem);
            if (atrLongitud == 0)
            {
                atrPrimero = objNodo;
                atrUltimo = objNodo;
                atrLongitud++;
                return true;
            }
            else
            {
                atrUltimo.conectar(objNodo);
                atrUltimo = objNodo;
                atrLongitud++;
                return true;
            }
        }
        public bool desencolar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
                return false;

            prmItem = atrPrimero.darItem();

            if (atrLongitud == 1)
            {
                atrPrimero = null;
                atrUltimo = null;
                atrLongitud--;
                return true;
            }
            else
            {
                clsNodoDobleEnlazado<Tipo> varNodoDesconectado = null;
                atrPrimero.desconectar(ref varNodoDesconectado);
                atrPrimero = varNodoDesconectado.darSiguiente();
                atrLongitud--;
                return true;
            }
        }
        public bool revisar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
                return false;

            prmItem = atrPrimero.darItem();
            return true;
        }
        #endregion
        #endregion
    }
}