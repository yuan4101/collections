using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsListaSimpleEnlazada<Tipo> : iTadSimpleEnlazado<Tipo>, iLista<Tipo>
    {
        #region Atributos
        public int atrLongitud;
        public clsNodoSimpleEnlazado<Tipo> atrPrimero;
        public clsNodoSimpleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Metodos
        #region Constructores
        public clsListaSimpleEnlazada()
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
        public bool agregar(Tipo prmItem)
        {
            clsNodoSimpleEnlazado<Tipo> objNodo = new clsNodoSimpleEnlazado<Tipo>(prmItem);
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
            clsNodoSimpleEnlazado<Tipo> varReferencia = atrPrimero;

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

            clsNodoSimpleEnlazado<Tipo> objNodo = new clsNodoSimpleEnlazado<Tipo>(prmItem);
            clsNodoSimpleEnlazado<Tipo> varReferencia = atrPrimero;

            if (prmIndice == 0)
            {
                objNodo.conectar(atrPrimero);
                atrPrimero = objNodo;
                atrLongitud++;
                return true;
            }
            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (varIndice == prmIndice - 1)
                {
                    objNodo.conectar(varReferencia.darSiguiente());
                    varReferencia.conectar(objNodo);
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

            clsNodoSimpleEnlazado<Tipo> varReferencia = atrPrimero;

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
            clsNodoSimpleEnlazado<Tipo> varReferencia = atrPrimero;

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

            clsNodoSimpleEnlazado<Tipo> varReferencia = atrPrimero;
            clsNodoSimpleEnlazado<Tipo> varNodoSiguiente = new clsNodoSimpleEnlazado<Tipo>();

            if (prmIndice == 0)
            {
                prmItem = atrPrimero.darItem();
                atrPrimero.desconectar(ref varNodoSiguiente);
                if (atrLongitud == 1)
                {
                    atrPrimero = null;
                    atrUltimo = null;
                    atrLongitud--;
                    return true;
                }
                atrPrimero = varNodoSiguiente;
                atrLongitud--;
                return true;
            }
            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (varIndice == prmIndice - 1)
                {
                    prmItem = varReferencia.darSiguiente().darItem();
                    varReferencia.darSiguiente().desconectar(ref varNodoSiguiente);
                    varReferencia.conectar(varNodoSiguiente);
                    if (prmIndice == atrLongitud - 1)
                    {
                        varReferencia.desconectar(ref varNodoSiguiente);
                        atrUltimo = varReferencia;
                    }
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