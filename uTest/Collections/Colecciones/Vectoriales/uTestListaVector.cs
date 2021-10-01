using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;
using System.Linq;

namespace uTest.Servicios.Colecciones.Vectoriales
{
    [TestClass]
    public class uTestListaVector
    {
        #region Atributos de Prueba
        clsListaVector<int> atrListaDatos;
        int atrItem, atrIndice;
        int[] atrItems;
        #endregion
        #region Casos de Prueba
        #region Accesores
        [TestMethod]
        public void uTestDarCapacidad()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(0, atrListaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestDarItems()
        {
            atrListaDatos = new clsListaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItems()
        {
            atrListaDatos = new clsListaVector<int>(3);
            atrItems = new int[3] { 0, 1, 2 };
            atrListaDatos.poner(atrItems);
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Constructores
        #region Constructor No Parametrizado
        [TestMethod]
        public void uTestConstructorNoParametrizado()
        {
            atrListaDatos = new clsListaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darItems().Length);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Constructores Parametrizados
        [TestMethod]
        public void uTestConstructorParametrizadoPositivo()
        {
            atrListaDatos = new clsListaVector<int>(5);
            atrItems = new int[5];
            Assert.AreEqual(5, atrListaDatos.darCapacidad());
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(5, atrListaDatos.darItems().Length);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(atrItems));
        }
        [TestMethod]
        public void uTestConstructorParametrizadoNegativo()
        {
            atrListaDatos = new clsListaVector<int>(-5);
            atrItems = new int[100];
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darItems().Length);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #endregion
        #region Agregar
        [TestMethod]
        public void uTestAgregarItem()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(true, atrListaDatos.agregar(2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.darItems()[0]);
        }
        [TestMethod]
        public void uTestAgregarItems()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(true, atrListaDatos.agregar(2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.agregar(5000));
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.darItems()[0]);
            Assert.AreEqual(5000, atrListaDatos.darItems()[1]);
        }
        [TestMethod]
        public void uTestAgregarHastaLLenar()
        {
            atrListaDatos = new clsListaVector<int>(3);
            atrListaDatos.poner(new int[3] { 1002, 1001, 1000 });
            Assert.AreEqual(false, atrListaDatos.agregar(1003));
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(3, atrListaDatos.darCapacidad());
            Assert.AreEqual(1000, atrListaDatos.darItems()[atrListaDatos.darLongitud() - 1]);
            Assert.AreEqual(1002, atrListaDatos.darItems()[0]);
        }
        #endregion
        #region Insertar
        [TestMethod]
        public void uTestInsertarItem()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(true, atrListaDatos.insertar(0, 2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.darItems()[0]);
        }
        [TestMethod]
        public void uTestInsertarItemIndiceFueraDeRango()
        {
            atrListaDatos = new clsListaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(false, atrListaDatos.insertar(-5, 2000));
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(false, atrListaDatos.insertar(100, 2000));
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(atrItems));
        }
        [TestMethod]
        public void uTestInsertarItems()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(true, atrListaDatos.insertar(0, 2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.insertar(1, 5000));
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.insertar(1, 3000));
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.darItems()[0]);
            Assert.AreEqual(3000, atrListaDatos.darItems()[1]);
            Assert.AreEqual(5000, atrListaDatos.darItems()[2]);
        }
        [TestMethod]
        public void uTestInsertarHastaLLenar()
        {
            atrListaDatos = new clsListaVector<int>(3);
            atrListaDatos.poner(new int[3] { 1000, 1001, 1002 });
            Assert.AreEqual(false, atrListaDatos.insertar(0, 1003));
            Assert.AreEqual(false, atrListaDatos.insertar(1, 1003));
            Assert.AreEqual(false, atrListaDatos.insertar(2, 1003));
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(3, atrListaDatos.darCapacidad());
            Assert.AreEqual(1002, atrListaDatos.darItems()[atrListaDatos.darLongitud() - 1]);
            Assert.AreEqual(1000, atrListaDatos.darItems()[0]);
        }
        #endregion
        #region Remover
        [TestMethod]
        public void uTestRemoverItem()
        {
            atrListaDatos = new clsListaVector<int>(3);
            atrListaDatos.poner(new int[3] { 123, 456, 9 });
            atrItem = 0;
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(1, ref atrItem));
            Assert.AreEqual(456, atrItem);
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(123, atrListaDatos.darItems()[0]);
            Assert.AreEqual(9, atrListaDatos.darItems()[1]);
        }
        [TestMethod]
        public void uTestRemoverItems()
        {
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[4] { 012, 789, 456, 123 });
            atrItem = 0;
            Assert.AreEqual(4, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(2, ref atrItem));
            Assert.AreEqual(456, atrItem);
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(0, ref atrItem));
            Assert.AreEqual(012, atrItem);
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(789, atrListaDatos.darItems()[0]);
            Assert.AreEqual(123, atrListaDatos.darItems()[atrListaDatos.darLongitud() - 1]);
            Assert.AreEqual(123, atrListaDatos.darItems()[1]);
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestRemoverItemsFueraDeRango()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(false, atrListaDatos.remover(0, ref atrItem));
            Assert.AreEqual(false, atrListaDatos.remover(-5, ref atrItem));
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        #endregion
        #region Modificar
        [TestMethod]
        public void uTestModificarItem()
        {
            atrListaDatos = new clsListaVector<int>();
            int[] varAuxItems = new int[100];
            varAuxItems[0] = 1003;
            varAuxItems[1] = 1004;
            varAuxItems[2] = 1005;
            atrListaDatos.poner(new int[3] { 1000, 1001, 1002 });
            Assert.AreEqual(true, atrListaDatos.modificar(0, 1003));
            Assert.AreEqual(true, atrListaDatos.modificar(1, 1004));
            Assert.AreEqual(true, atrListaDatos.modificar(2, 1005));
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varAuxItems));
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        public void uTestModificarItemFueraDeRango()
        {
            atrListaDatos = new clsListaVector<int>();
            Assert.AreEqual(false, atrListaDatos.modificar(0, 1000));
            Assert.AreEqual(false, atrListaDatos.modificar(-5, 1000));
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(new int[100]));
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        #endregion
        #region Recuperar
        [TestMethod]
        public void uTestRecuperar()
        {
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[3] { 4, 7, 2});
            atrItem = 0;
            Assert.AreEqual(true, atrListaDatos.recuperar(1, ref atrItem));
            Assert.AreEqual(7, atrItem);
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestRecuperarFueraDeRango()
        {
            atrListaDatos = new clsListaVector<int>();
            atrItem = 1;
            Assert.AreEqual(false, atrListaDatos.recuperar(0, ref atrItem));
            Assert.AreNotEqual(0, atrItem);
            Assert.AreEqual(1, atrItem);
            Assert.AreEqual(false, atrListaDatos.recuperar(-5, ref atrItem));
            Assert.AreNotEqual(0, atrItem);
            Assert.AreEqual(1, atrItem);
        }
        #endregion
        #region Encontrar
        [TestMethod]
        public void uTestEncontrar()
        {
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[3] { 4, 7, 2 });
            atrIndice = 0;
            Assert.AreEqual(true, atrListaDatos.encontrar(7, ref atrIndice));
            Assert.AreEqual(1, atrIndice);
            Assert.AreEqual(true, atrListaDatos.encontrar(2, ref atrIndice));
            Assert.AreEqual(2, atrIndice);
            Assert.AreEqual(true, atrListaDatos.encontrar(4, ref atrIndice));
            Assert.AreEqual(0, atrIndice);
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestEncontrarFueraDeRango()
        {
            atrListaDatos = new clsListaVector<int>();
            atrIndice = -1;
            Assert.AreEqual(false, atrListaDatos.encontrar(5, ref atrIndice));
            Assert.AreEqual(-1, atrIndice);
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
        }
        #endregion
        #region Ordenamiento
        [TestMethod]
        public void uTestOrdenarBurbuja()
        {
            atrListaDatos = new clsListaVector<int>();
            #region Datos del vector a comparar
            int[] varListaDatosAux = new int[100];
            varListaDatosAux[0] = 1;
            varListaDatosAux[1] = 2;
            varListaDatosAux[2] = 4;
            varListaDatosAux[3] = 4;
            varListaDatosAux[4] = 5;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 6;
            varListaDatosAux[8] = 6;
            varListaDatosAux[9] = 7;
            varListaDatosAux[10] = 8;
            varListaDatosAux[11] = 9;
            #endregion
            atrListaDatos.poner(new int[12] { 5, 4, 7, 6, 1, 5, 8, 6, 9, 2, 4, 5 });
            atrListaDatos.ordenarBurbuja(false);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
            Assert.AreEqual(12, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            atrListaDatos.agregar(999);
            varListaDatosAux[12] = 999;
            Assert.AreEqual(13, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
        }
        [TestMethod]
        public void uTestOrdenarSeleccion()
        {
            atrListaDatos = new clsListaVector<int>();
            #region Datos del vector a comparar
            int[] varListaDatosAux = new int[100];
            varListaDatosAux[0] = 1;
            varListaDatosAux[1] = 2;
            varListaDatosAux[2] = 4;
            varListaDatosAux[3] = 4;
            varListaDatosAux[4] = 5;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 6;
            varListaDatosAux[8] = 6;
            varListaDatosAux[9] = 7;
            varListaDatosAux[10] = 8;
            varListaDatosAux[11] = 9;
            #endregion
            atrListaDatos.poner(new int[12] { 5, 4, 7, 6, 1, 5, 8, 6, 9, 2, 4, 5 });
            atrListaDatos.ordenarSeleccion(false);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
            Assert.AreEqual(12, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            atrListaDatos.agregar(999);
            varListaDatosAux[12] = 999;
            Assert.AreEqual(13, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
        }
        [TestMethod]
        public void uTestOrdenarInsercion()
        {
            atrListaDatos = new clsListaVector<int>();
            #region Datos del vector a comparar
            int[] varListaDatosAux = new int[100];
            varListaDatosAux[0] = 1;
            varListaDatosAux[1] = 2;
            varListaDatosAux[2] = 4;
            varListaDatosAux[3] = 4;
            varListaDatosAux[4] = 5;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 6;
            varListaDatosAux[8] = 6;
            varListaDatosAux[9] = 7;
            varListaDatosAux[10] = 8;
            varListaDatosAux[11] = 9;
            #endregion
            atrListaDatos.poner(new int[12] { 5, 4, 7, 6, 1, 5, 8, 6, 9, 2, 4, 5 });
            atrListaDatos.ordenarInsercion(false);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
            Assert.AreEqual(12, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            atrListaDatos.agregar(999);
            varListaDatosAux[12] = 999;
            Assert.AreEqual(13, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
        }
        [TestMethod]
        public void uTestOrdenarCoctel()
        {
            atrListaDatos = new clsListaVector<int>();
            #region Datos del vector a comparar
            int[] varListaDatosAux = new int[100];
            varListaDatosAux[0] = 1;
            varListaDatosAux[1] = 2;
            varListaDatosAux[2] = 4;
            varListaDatosAux[3] = 4;
            varListaDatosAux[4] = 5;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 6;
            varListaDatosAux[8] = 6;
            varListaDatosAux[9] = 7;
            varListaDatosAux[10] = 8;
            varListaDatosAux[11] = 9;
            #endregion
            atrListaDatos.poner(new int[12] { 5, 4, 7, 6, 1, 5, 8, 6, 9, 2, 4, 5 });
            atrListaDatos.ordenarCoctel(false);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
            Assert.AreEqual(12, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            atrListaDatos.agregar(999);
            varListaDatosAux[12] = 999;
            Assert.AreEqual(13, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
        }
        [TestMethod]
        public void uTestOrdenarMezcla()
        {
            atrListaDatos = new clsListaVector<int>();
            #region Datos del vector a comparar
            int[] varListaDatosAux = new int[100];
            varListaDatosAux[0] = 9;
            varListaDatosAux[1] = 8;
            varListaDatosAux[2] = 7;
            varListaDatosAux[3] = 6;
            varListaDatosAux[4] = 6;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 5;
            varListaDatosAux[8] = 4;
            varListaDatosAux[9] = 4;
            varListaDatosAux[10] = 2;
            varListaDatosAux[11] = 1;
            /*
            varListaDatosAux[0] = 1;
            varListaDatosAux[1] = 2;
            varListaDatosAux[2] = 4;
            varListaDatosAux[3] = 4;
            varListaDatosAux[4] = 5;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 6;
            varListaDatosAux[8] = 6;
            varListaDatosAux[9] = 7;
            varListaDatosAux[10] = 8;
            varListaDatosAux[11] = 9;
            */
            #endregion
            atrListaDatos.poner(new int[12] { 5, 4, 7, 6, 1, 5, 8, 6, 9, 2, 4, 5 });
            atrListaDatos.ordenarMezcla(true, 0, 11);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
            Assert.AreEqual(12, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            atrListaDatos.agregar(999);
            varListaDatosAux[12] = 999;
            Assert.AreEqual(13, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
        }
        [TestMethod]
        public void uTestOrdenarQuick()
        {
            atrListaDatos = new clsListaVector<int>();
            #region Datos del vector a comparar
            int[] varListaDatosAux = new int[100];
            varListaDatosAux[0] = 9;
            varListaDatosAux[1] = 8;
            varListaDatosAux[2] = 7;
            varListaDatosAux[3] = 6;
            varListaDatosAux[4] = 6;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 5;
            varListaDatosAux[8] = 4;
            varListaDatosAux[9] = 4;
            varListaDatosAux[10] = 2;
            varListaDatosAux[11] = 1;
            /*
            varListaDatosAux[0] = 1;
            varListaDatosAux[1] = 2;
            varListaDatosAux[2] = 4;
            varListaDatosAux[3] = 4;
            varListaDatosAux[4] = 5;
            varListaDatosAux[5] = 5;
            varListaDatosAux[6] = 5;
            varListaDatosAux[7] = 6;
            varListaDatosAux[8] = 6;
            varListaDatosAux[9] = 7;
            varListaDatosAux[10] = 8;
            varListaDatosAux[11] = 9;
            */
            #endregion
            atrListaDatos.poner(new int[12] { 5, 4, 7, 6, 1, 5, 8, 6, 9, 2, 4, 5 });
            atrListaDatos.ordenarQuick(true, 0, 11);
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
            Assert.AreEqual(12, atrListaDatos.darLongitud());
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            atrListaDatos.agregar(999);
            varListaDatosAux[12] = 999;
            Assert.AreEqual(13, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.darItems().SequenceEqual(varListaDatosAux));
        }
        #endregion
        #endregion
    }
}