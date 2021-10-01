using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : iPila<Tipo>, iTadVectorial<Tipo> where Tipo: IComparable
    {
        #region Atributos
        private int atrCapacidad;
        private int atrLongitud;
        private Tipo[] atrItems;
        #endregion
        #region Metodos
        #region Constructores/Desctructores
        public clsPilaVector()
        {
            atrCapacidad = 100;
            atrItems = new Tipo[atrCapacidad];
        }
        public clsPilaVector(int prmCapacidad)
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
            atrLongitud = prmItems.Length;
            Array.Resize(ref prmItems, atrItems.Length);
            atrItems = prmItems;
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
        public bool apilar(Tipo prmItem)
        {
            if (estaLlena())
                return false;
            DesplazarDerecha(0);
            atrItems[0] = prmItem;
            atrLongitud++;
            return true;
        }
        public bool desapilar(ref Tipo prmItem)
        {
            if (estaVacia())
                return false;
            prmItem = atrItems[0];
            DesplazarIzquierda(0);
            atrLongitud--;
            return true;
        }
        public bool revisar(ref Tipo prmItem)
        {
            if (estaVacia())
                return false;
            prmItem = atrItems[0]; return true;
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