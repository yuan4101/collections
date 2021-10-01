using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> , iNodoDobleEnlazado<Tipo>
    {
        #region Atributos
        public clsNodoDobleEnlazado<Tipo> atrAnterior;
        public clsNodoDobleEnlazado<Tipo> atrSiguiente;
        #endregion
        #region Metodos
        #region Constructores
        public clsNodoDobleEnlazado()
        {
            atrAnterior = null;
            atrSiguiente = null;
        }
        public clsNodoDobleEnlazado(Tipo prmItem) : base(prmItem)
        {
            atrAnterior = null;
            atrSiguiente = null;
        }
        #endregion
        #region Accesores
        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            return atrAnterior;
        }
        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        #endregion
        #region Conectores
        public bool conectar(clsNodoDobleEnlazado<Tipo> prmNodo)
        {
            if (prmNodo == null)
                return false;

            atrSiguiente = prmNodo;
            prmNodo.atrAnterior = this;
            return true;
        }
        public bool desconectar(ref clsNodoDobleEnlazado<Tipo> prmNodo)
        {
            if (atrAnterior == null && atrSiguiente == null)
                return false;

            if (atrAnterior != null)
                atrAnterior.atrSiguiente = null;

            if (atrSiguiente != null)
                atrSiguiente.atrAnterior = null;

            prmNodo = this;
            return true;
        }
        #endregion
        #endregion
    }
}