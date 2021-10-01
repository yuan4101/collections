using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoSimpleEnlazado<Tipo> : clsNodo<Tipo> , iNodoSimpleEnlazado<Tipo>
    {
        #region Atributos
        public clsNodoSimpleEnlazado<Tipo> atrSiguiente;
        #endregion
        #region Metodos
        #region Constructores
        public clsNodoSimpleEnlazado()
        {
            atrSiguiente = null;
        }
        public clsNodoSimpleEnlazado(Tipo prmItem) : base(prmItem)
        {
            atrSiguiente = null;
        }
        #endregion
        #region Accesores
        public clsNodoSimpleEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        #endregion
        #region Conectores
        public bool conectar(clsNodoSimpleEnlazado<Tipo> prmNodo)
        {
            if (prmNodo == null)
                return false;

            atrSiguiente = prmNodo;
            return true;
        }
        public bool desconectar(ref clsNodoSimpleEnlazado<Tipo> prmNodo)
        {
            if (atrSiguiente == null)
                return false;

            prmNodo = atrSiguiente;
            atrSiguiente = null;
            return true;
        }
        #endregion
        #endregion
    }
}