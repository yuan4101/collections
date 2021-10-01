﻿using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsColaSimpleEnlazada<Tipo> : iTadSimpleEnlazado<Tipo>, iCola<Tipo>
    {
        #region Atributos
        public int atrLongitud;
        public clsNodoSimpleEnlazado<Tipo> atrPrimero;
        public clsNodoSimpleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Metodos
        #region Constructores
        public clsColaSimpleEnlazada()
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
        public bool encolar(Tipo prmItem)
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
        public bool desencolar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
                return false;

            if (atrLongitud == 1)
            {
                prmItem = atrPrimero.darItem();
                atrPrimero = null;
                atrUltimo = null;
                atrLongitud--;
                return true;
            }
            else
            {
                prmItem = atrPrimero.darItem();
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