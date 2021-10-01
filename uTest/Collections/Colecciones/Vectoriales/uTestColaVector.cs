using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;

namespace uTest.Servicios.Colecciones.Vectoriales
{
    [TestClass]
    public class uTestColaVector
    {
        #region Atributos de Prueba
        clsColaVector<int> atrColaDatos;
        int atrItem;
        int[] atrItems;
        #endregion
        #region Casos de Prueba
        #region Accesores
        [TestMethod]
        public void uTestDarCapacidad()
        {
            atrColaDatos = new clsColaVector<int>();
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            atrColaDatos = new clsColaVector<int>();
            Assert.AreEqual(0, atrColaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestDarItems()
        {
            atrColaDatos = new clsColaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(true, atrColaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItems()
        {
            atrColaDatos = new clsColaVector<int>(3);
            atrItems = new int[3] { 0, 1, 2 };
            atrColaDatos.poner(atrItems);
            Assert.AreEqual(3, atrColaDatos.darLongitud());
            Assert.AreEqual(true, atrColaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Constructores
        #region Constructor No Parametrizado
        [TestMethod]
        public void uTestConstructorNoParametrizado()
        {
            atrColaDatos = new clsColaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(100, atrColaDatos.darItems().Length);
            Assert.AreEqual(true, atrColaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Constructores Parametrizados
        [TestMethod]
        public void uTestConstructorParametrizadoPositivo()
        {
            atrColaDatos = new clsColaVector<int>(5);
            atrItems = new int[5];
            Assert.AreEqual(5, atrColaDatos.darCapacidad());
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(5, atrColaDatos.darItems().Length);
            Assert.AreEqual(true, atrColaDatos.darItems().SequenceEqual(atrItems));
        }
        [TestMethod]
        public void uTestConstructorParametrizadoNegativo()
        {
            atrColaDatos = new clsColaVector<int>(-5);
            atrItems = new int[100];
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(100, atrColaDatos.darItems().Length);
            Assert.AreEqual(true, atrColaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #endregion
        #region Encolar
        [TestMethod]
        public void uTestEncolarItem()
        {
            atrColaDatos = new clsColaVector<int>();
            Assert.AreEqual(true, atrColaDatos.encolar(2000));
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            Assert.AreEqual(2000, atrColaDatos.darItems()[0]);
        }
        [TestMethod]
        public void uTestEncolarItems()
        {
            atrColaDatos = new clsColaVector<int>();
            Assert.AreEqual(true, atrColaDatos.encolar(2000));
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            Assert.AreEqual(true, atrColaDatos.encolar(5000));
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(2000, atrColaDatos.darItems()[0]);
            Assert.AreEqual(5000, atrColaDatos.darItems()[1]);
        }
        [TestMethod]
        public void uTestEncolarHastaLLenar()
        {
            atrColaDatos = new clsColaVector<int>(3);
            atrColaDatos.poner(new int[3] { 1000, 1001, 1002 });
            Assert.AreEqual(false, atrColaDatos.encolar(1003));
            Assert.AreEqual(3, atrColaDatos.darLongitud());
            Assert.AreEqual(3, atrColaDatos.darCapacidad());
            Assert.AreEqual(1002, atrColaDatos.darItems()[atrColaDatos.darLongitud() - 1]);
            Assert.AreEqual(1000, atrColaDatos.darItems()[0]);
        }
        #endregion
        #region Desencolar
        [TestMethod]
        public void uTestDesencolarItem()
        {
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[1] { 123 });
            atrItem = 0;
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            Assert.AreEqual(true, atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(123, atrItem);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestDesencolarItems()
        {
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[4] { 012, 789, 456, 123 });
            atrItem = 0;
            Assert.AreEqual(4, atrColaDatos.darLongitud());
            Assert.AreEqual(true, atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(012, atrItem);
            Assert.AreEqual(3, atrColaDatos.darLongitud());
            Assert.AreEqual(true, atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(789, atrItem);
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(456, atrColaDatos.darItems()[0]);
            Assert.AreEqual(123, atrColaDatos.darItems()[atrColaDatos.darLongitud() - 1]);
            Assert.AreEqual(123, atrColaDatos.darItems()[1]);
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestDesencolarItemsCuandoVacia()
        {
            atrColaDatos = new clsColaVector<int>();
            Assert.AreEqual(false, atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisar()
        {
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[2] { 1, 2 });
            atrItem = 0;
            Assert.AreEqual(true, atrColaDatos.revisar(ref atrItem));
            Assert.AreEqual(1, atrItem);
        }
        [TestMethod]
        public void uTestRevisarCuandoVacia()
        {
            atrColaDatos = new clsColaVector<int>();
            atrItem = 1;
            Assert.AreEqual(false, atrColaDatos.revisar(ref atrItem));
            Assert.AreNotEqual(2, atrItem);
            Assert.AreEqual(1, atrItem);
        }
        #endregion
        #endregion
    }
}