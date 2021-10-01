using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : iTadDobleEnlazado<Tipo>, iPila<Tipo>
    {
        #region Atributos
        public int atrLongitud;
        public clsNodoDobleEnlazado<Tipo> atrPrimero;
        public clsNodoDobleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Metodos
        #region Constructores
        public clsPilaDobleEnlazada()
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
        public bool apilar(Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> objNodo = new clsNodoDobleEnlazado<Tipo>(prmItem);
            if (atrLongitud == 0)
            {
                atrPrimero = objNodo;
                atrUltimo = atrPrimero;
                atrLongitud++;
                return true;
            }
            else
            {
                objNodo.conectar(atrPrimero);
                atrPrimero = objNodo;
                atrLongitud++;
                return true;
            }
        }
        public bool desapilar(ref Tipo prmItem)
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
