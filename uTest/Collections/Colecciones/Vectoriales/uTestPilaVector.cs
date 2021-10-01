using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;

namespace uTest.Servicios.Colecciones.Vectoriales
{
    [TestClass]
    public class uTestPilaVector
    {
        #region Atributos de Prueba
        clsPilaVector<int> atrPilaDatos;
        int atrItem;
        int[] atrItems;
        #endregion
        #region Casos de Prueba
        #region Accesores
        [TestMethod]
        public void uTestDarCapacidad()
        {
            atrPilaDatos = new clsPilaVector<int>();
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            atrPilaDatos = new clsPilaVector<int>();
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestDarItems()
        {
            atrPilaDatos = new clsPilaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(true, atrPilaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItems()
        {
            atrPilaDatos = new clsPilaVector<int>(3);
            atrItems = new int[3] { 0, 1, 2 };
            atrPilaDatos.poner(atrItems);
            Assert.AreEqual(3, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Constructores
        #region Constructor No Parametrizado
        [TestMethod]
        public void uTestConstructorNoParametrizado()
        {
            atrPilaDatos = new clsPilaVector<int>();
            atrItems = new int[100];
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(100, atrPilaDatos.darItems().Length);
            Assert.AreEqual(true, atrPilaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #region Constructores Parametrizados
        [TestMethod]
        public void uTestConstructorParametrizadoPositivo()
        {
            atrPilaDatos = new clsPilaVector<int>(5);
            atrItems = new int[5];
            Assert.AreEqual(5, atrPilaDatos.darCapacidad());
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(5, atrPilaDatos.darItems().Length);
            Assert.AreEqual(true, atrPilaDatos.darItems().SequenceEqual(atrItems));
        }
        [TestMethod]
        public void uTestConstructorParametrizadoNegativo()
        {
            atrPilaDatos = new clsPilaVector<int>(-5);
            atrItems = new int[100];
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(100, atrPilaDatos.darItems().Length);
            Assert.AreEqual(true, atrPilaDatos.darItems().SequenceEqual(atrItems));
        }
        #endregion
        #endregion
        #region Apilar
        [TestMethod]
        public void uTestApilarItem()
        {
            atrPilaDatos = new clsPilaVector<int>();
            Assert.AreEqual(true, atrPilaDatos.apilar(2000));
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(2000, atrPilaDatos.darItems()[0]);
        }
        [TestMethod]
        public void uTestApilarItems()
        {
            atrPilaDatos = new clsPilaVector<int>();
            Assert.AreEqual(true, atrPilaDatos.apilar(2000));
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.apilar(5000));
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(5000, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(2000, atrPilaDatos.darItems()[1]);
        }
        [TestMethod]
        public void uTestApilarHastaLLenar()
        {
            atrPilaDatos = new clsPilaVector<int>(3);
            atrPilaDatos.poner(new int[3] { 1002, 1001, 1000 });
            Assert.AreEqual(false, atrPilaDatos.apilar(1003));
            Assert.AreEqual(3, atrPilaDatos.darLongitud());
            Assert.AreEqual(3, atrPilaDatos.darCapacidad());
            Assert.AreEqual(1000, atrPilaDatos.darItems()[atrPilaDatos.darLongitud() - 1]);
            Assert.AreEqual(1002, atrPilaDatos.darItems()[0]);
        }
        #endregion
        #region Desapilar
        [TestMethod]
        public void uTestDesapilarItem()
        {
            atrPilaDatos = new clsPilaVector<int>();
            atrPilaDatos.poner(new int[1] { 123 });
            atrItem = 0;
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(123, atrItem);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestDesapilarItems()
        {
            atrPilaDatos = new clsPilaVector<int>();
            atrPilaDatos.poner(new int[4] { 012, 789, 456, 123 });
            atrItem = 0;
            Assert.AreEqual(4, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(012, atrItem);
            Assert.AreEqual(3, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(789, atrItem);
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(456, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(123, atrPilaDatos.darItems()[atrPilaDatos.darLongitud() - 1]);
            Assert.AreEqual(123, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
        }
        [TestMethod]
        public void uTestDesapilarItemsCuandoVacia()
        {
            atrPilaDatos = new clsPilaVector<int>();
            Assert.AreEqual(false, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisar()
        {
            atrPilaDatos = new clsPilaVector<int>();
            atrPilaDatos.poner(new int[2] { 1, 2 });
            atrItem = 0;
            Assert.AreEqual(true, atrPilaDatos.revisar(ref atrItem));
            Assert.AreEqual(1, atrItem);
        }
        [TestMethod]
        public void uTestRevisarCuandoVacia()
        {
            atrPilaDatos = new clsPilaVector<int>();
            atrItem = 1;
            Assert.AreEqual(false, atrPilaDatos.revisar(ref atrItem));
            Assert.AreNotEqual(2, atrItem);
            Assert.AreEqual(1, atrItem);
        }
        #endregion
        #endregion
    }
}