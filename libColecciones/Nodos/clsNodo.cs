using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> : iNodo<Tipo>
    {
        #region Atributos
        public Tipo atrItem;
        #endregion
        #region Metodos
        #region Constructores
        public clsNodo()
        {
            atrItem = default;
        }
        public clsNodo(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        #endregion
        #region Accesores
        public Tipo darItem()
        {
            return atrItem;
        }
        #endregion
        #region Mutadores
        public void poner(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        #endregion
        #endregion
    }
}