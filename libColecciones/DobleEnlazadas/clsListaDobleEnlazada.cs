using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsListaDobleEnlazada<Tipo> : iTadDobleEnlazado<Tipo>, iLista<Tipo>
    {
        #region Atributos
        public int atrLongitud;
        public clsNodoDobleEnlazado<Tipo> atrPrimero;
        public clsNodoDobleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Metodos
        #region Constructores
        public clsListaDobleEnlazada()
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
        public bool agregar(Tipo prmItem)
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
        public bool encontrar(Tipo prmItem, ref int prmIndice)
        {
            clsNodoDobleEnlazado<Tipo> varReferencia = atrPrimero;

            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (prmItem.Equals(varReferencia.darItem()))
                {
                    prmIndice = varIndice;
                    return true;
                }
                varReferencia = varReferencia.darSiguiente();
            }
            return false;
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            if (atrLongitud == 0)
                return false;
            if (prmIndice < 0 || prmIndice >= atrLongitud)
                return false;

            clsNodoDobleEnlazado<Tipo> objNodo = new clsNodoDobleEnlazado<Tipo>(prmItem);
            clsNodoDobleEnlazado<Tipo> varReferencia = atrPrimero;

            if (prmIndice == 0)
            {
                objNodo.conectar(atrPrimero);
                atrPrimero = objNodo;
                atrLongitud++;
                return true;
            }
            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (varIndice == prmIndice)
                {
                    varReferencia.darAnterior().conectar(objNodo);
                    objNodo.conectar(varReferencia);
                    atrLongitud++;
                    return true;
                }
                varReferencia = varReferencia.darSiguiente();
            }
            return false;
        }
        public bool modificar(int prmIndice, Tipo prmItem)
        {
            if (atrLongitud == 0)
                return false;
            if (prmIndice < 0 || prmIndice >= atrLongitud)
                return false;

            clsNodoDobleEnlazado<Tipo> varReferencia = atrPrimero;

            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (varIndice == prmIndice)
                {
                    varReferencia.poner(prmItem);
                    return true;
                }
                varReferencia = varReferencia.darSiguiente();
            }
            return false;
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varReferencia = atrPrimero;

            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (varIndice == prmIndice)
                {
                    prmItem = varReferencia.darItem();
                    return true;
                }
                varReferencia = varReferencia.darSiguiente();
            }
            return false;
        }
        public bool remover(int prmIndice, ref Tipo prmItem)
        {
            if (atrLongitud == 0)
                return false;
            if (prmIndice < 0 || prmIndice >= atrLongitud)
                return false;

            clsNodoDobleEnlazado<Tipo> varReferencia = atrPrimero;
            clsNodoDobleEnlazado<Tipo> varNodoDesconectado = null;

            if (prmIndice == 0)
            {
                prmItem = atrPrimero.darItem();
                if (atrLongitud == 1)
                {
                    atrPrimero = null;
                    atrUltimo = null;
                    atrLongitud--;
                    return true;
                }
                atrPrimero.desconectar(ref varNodoDesconectado);
                atrPrimero = varNodoDesconectado.darSiguiente();
                atrLongitud--;
                return true;
            }
            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (varIndice == prmIndice)
                {
                    prmItem = varReferencia.darItem();
                    if (prmIndice == atrLongitud - 1)
                    {
                        varReferencia.desconectar(ref varNodoDesconectado);
                        atrUltimo = varNodoDesconectado.darAnterior();
                        atrLongitud--;
                        return true;
                    }
                    varReferencia.darAnterior().conectar(varReferencia.darSiguiente());
                    atrLongitud--;
                    return true;
                }
                varReferencia = varReferencia.darSiguiente();
            }
            return false;
        }
        #endregion
        #endregion
    }
}
