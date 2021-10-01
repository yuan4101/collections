using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTest.Servicios.Colecciones.DobleEnlazadas
{
    [TestClass]
    public class uTestPilaDobleEnlazada
    {
        #region Atributos de prueba
        clsPilaDobleEnlazada<int> atrPilaDatos;
        #endregion
        #region Casos de prueba
        #region Apilar
        [TestMethod]
        public void uTestApilarUnItem()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            Assert.AreEqual(true, atrPilaDatos.apilar(2000));
            Assert.AreEqual(2000, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestApilarDosItems()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            Assert.AreEqual(true, atrPilaDatos.apilar(999));
            Assert.AreEqual(true, atrPilaDatos.apilar(500));
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(500, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(999, atrPilaDatos.darUltimo().darItem());
        }
        [TestMethod]
        public void uTestApilarVariosItems()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            bool varResultadoDeApilar = true;
            for (int varNumero = 0; varNumero < 500; varNumero++)
                varResultadoDeApilar = varResultadoDeApilar && atrPilaDatos.apilar(varNumero);
            Assert.AreEqual(true, varResultadoDeApilar);
            Assert.AreEqual(500, atrPilaDatos.darLongitud());
            Assert.AreEqual(499, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(0, atrPilaDatos.darUltimo().darItem());
        }
        #endregion
        #region Desapilar
        [TestMethod]
        public void uTestDesapilarConPilaVacia()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoDesapilado = 0;
            Assert.AreEqual(false, atrPilaDatos.desapilar(ref varElementoDesapilado));
            Assert.AreEqual(0, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDatos.darUltimo());
        }
        [TestMethod]
        public void uTestDesapilarUnItemCaso1()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoDesapilado = 0;
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref varElementoDesapilado));
            Assert.AreEqual(5000, varElementoDesapilado);
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(2000, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDatos.darUltimo().darItem());
        }
        [TestMethod]
        public void uTestDesapilarUnItemCaso2()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoDesapilado = 0;
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            atrPilaDatos.apilar(8000);
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref varElementoDesapilado));
            Assert.AreEqual(8000, varElementoDesapilado);
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(5000, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDatos.darUltimo().darItem());
        }
        [TestMethod]
        public void uTestDesapilarVaciarItemsCaso1()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoDesapilado = 0;
            atrPilaDatos.apilar(2000);
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref varElementoDesapilado));
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDatos.darUltimo());
        }
        [TestMethod]
        public void uTestDesapilarVaciarItemsCaso2()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoDesapilado1 = 0;
            int varElementoDesapilado2 = 0;
            bool varResultadoDesapilar;
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            varResultadoDesapilar = atrPilaDatos.desapilar(ref varElementoDesapilado1) && atrPilaDatos.desapilar(ref varElementoDesapilado2);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado1);
            Assert.AreEqual(2000, varElementoDesapilado2);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDatos.darUltimo());
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisarPilaConItems()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoRevisado = 0;
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            Assert.AreEqual(true, atrPilaDatos.revisar(ref varElementoRevisado));
            Assert.AreEqual(5000, varElementoRevisado);
        }
        [TestMethod]
        public void uTestRevisarPilaVacia()
        {
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            int varElementoRevisado = 0;
            Assert.AreEqual(false, atrPilaDatos.revisar(ref varElementoRevisado));
            Assert.AreEqual(0, varElementoRevisado);
        }
        #endregion
        #endregion
    }
}
