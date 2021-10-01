using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsPilaSimpleEnlazada<Tipo> : iTadSimpleEnlazado<Tipo>, iPila<Tipo>
    {
        #region Atributos
        int atrLongitud;
        clsNodoSimpleEnlazado<Tipo> atrPrimero;
        clsNodoSimpleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Metodos
        #region Constructores
        public clsPilaSimpleEnlazada()
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
        public clsNodoSimpleEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoSimpleEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion
        #region CRUDS
        public bool apilar(Tipo prmItem)
        {
            clsNodoSimpleEnlazado<Tipo> objNodo = new clsNodoSimpleEnlazado<Tipo>(prmItem);
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
                atrPrimero = atrPrimero.darSiguiente();
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