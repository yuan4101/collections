using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : iLista<Tipo>, iTadVectorial<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private int atrCapacidad;
        private int atrLongitud;
        private Tipo[] atrItems;
        #endregion
        #region Metodos
        #region Constructores/Desctructores
        public clsListaVector()
        {
            atrCapacidad = 100;
            atrItems = new Tipo[atrCapacidad];
        }
        public clsListaVector(int prmCapacidad)
        {
            try
            {
                atrCapacidad = prmCapacidad;
                atrItems = new Tipo[atrCapacidad];
            }
            catch
            {
                atrCapacidad = 100;
                atrItems = new Tipo[atrCapacidad];
            }
        }
        #endregion
        #region Accesores
        public int darCapacidad()
        {
            return atrCapacidad;
        }
        public int darLongitud()
        {
            return atrLongitud;
        }
        public Tipo[] darItems()
        {
            return atrItems;
        }
        public bool estaVacia()
        {
            if (atrLongitud == 0)
                return true;
            else
                return false;
        }
        public bool estaLlena()
        {
            if (atrCapacidad == atrLongitud)
                return true;
            else
                return false;
        }
        #endregion
        #region Mutadores
        public void poner(Tipo[] prmItems)
        {
            if (prmItems.Length >= atrCapacidad)
            {
                Array.Resize(ref prmItems, atrCapacidad);
                atrLongitud = prmItems.Length;
                atrItems = prmItems;
            }
            else
            {
                atrLongitud = prmItems.Length;
                Array.Resize(ref prmItems, atrCapacidad);
                atrItems = prmItems;
            }

        }
        private void DesplazarDerecha(int prmIndice)
        {
            for (int i = atrLongitud; i > prmIndice; i--)
                atrItems[i] = atrItems[i - 1];
        }
        private void DesplazarIzquierda(int prmIndice)
        {
            for (int i = prmIndice; i < atrLongitud - 1; i++)
                atrItems[i] = atrItems[i + 1];
        }
        #endregion
        #region CRUDS
        public bool agregar(Tipo prmItem)
        {
            if (estaLlena())
                return false;
            atrItems[atrLongitud] = prmItem;
            atrLongitud++;
            return true;
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            if (estaLlena())
                return false;
            if (prmIndice < 0 || prmIndice >= atrCapacidad)
                return false;
            DesplazarDerecha(prmIndice);
            atrItems[prmIndice] = prmItem;
            atrLongitud++;
            return true;
        }
        public bool remover(int prmIndice, ref Tipo prmItem)
        {
            if (estaVacia())
                return false;
            if (prmIndice < 0 || prmIndice >= atrCapacidad)
                return false;
            prmItem = atrItems[prmIndice];
            DesplazarIzquierda(prmIndice);
            atrLongitud--;
            return true;
        }
        public bool modificar(int prmIndice, Tipo prmItem)
        {
            if (estaVacia())
                return false;
            if (prmIndice < 0 || prmIndice >= atrCapacidad)
                return false;
            atrItems[prmIndice] = prmItem;
            return true;
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            if (estaVacia())
                return false;
            if (prmIndice < 0 || prmIndice >= atrCapacidad)
                return false;
            prmItem = atrItems[prmIndice];
            return true;
        }
        public bool encontrar(Tipo prmItem, ref int prmIndice)
        {
            if (estaVacia())
                return false;
            for (int i = 0; i < atrLongitud; i++)
                if (atrItems[i].Equals(prmItem))
                {
                    prmIndice = i; return true;
                }
            return false;
        }
        #endregion
        #region Ordenamiento
        public bool ordenarBurbuja(bool prmPorDescendente)
        {
            if (prmPorDescendente)
                for (int varContador0 = 1; varContador0 <= atrLongitud - 1; varContador0++)
                {
                    for (int varContador1 = 0; varContador1 <= atrLongitud - varContador0 - 1; varContador1++)
                    {
                        if (atrItems[varContador1].CompareTo(atrItems[varContador1 + 1]) <= 0)
                        {
                            Tipo varAux = atrItems[varContador1];
                            atrItems[varContador1] = atrItems[varContador1 + 1];
                            atrItems[varContador1 + 1] = varAux;
                        }
                    }
                }
            else
                for (int varContador0 = 1; varContador0 <= atrLongitud - 1; varContador0++)
                {
                    for (int varContador1 = 0; varContador1 <= atrLongitud - varContador0 - 1; varContador1++)
                    {
                        if (atrItems[varContador1].CompareTo(atrItems[varContador1 + 1]) > 0)
                        {
                            Tipo varAux = atrItems[varContador1];
                            atrItems[varContador1] = atrItems[varContador1 + 1];
                            atrItems[varContador1 + 1] = varAux;
                        }
                    }
                }
            return true;
        }
        public bool ordenarCoctel(bool prmPorDescendente)
        {
            return false;
        }
        public bool ordenarSeleccion(bool prmPorDescendente)
        {
            return false;
        }
        public bool ordenarInsercion(bool prmPorDescendente)
        {
            return false;
        }
        public bool ordenarMezcla(bool prmPorDescendente, int prmIdxInicial, int prmIdxFinal)
        {
            return false;
        }
        public bool ordenarQuick(bool prmPorDescendente, int prmIdxInicial, int prmIdxFinal)
        {
            return false;
        }
        #endregion
        #endregion
    }
}