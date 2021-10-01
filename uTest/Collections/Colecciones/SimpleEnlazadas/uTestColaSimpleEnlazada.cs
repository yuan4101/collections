using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.SimpleEnlazadas;

namespace uTest.Servicios.Colecciones.SimpleEnlazadas
{
    [TestClass]
    public class uTestColaSimpleEnlazada
    {
        #region Atributos de prueba
        clsColaSimpleEnlazada<int> atrColaDatos;
        #endregion
        #region Casos de prueba
        #region Encolar
        [TestMethod]
        public void uTestEncolarUnItem()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            Assert.AreEqual(true, atrColaDatos.encolar(2000));
            Assert.AreEqual(2000, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrColaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrColaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestEncolarDosItems()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            Assert.AreEqual(true, atrColaDatos.encolar(999));
            Assert.AreEqual(true, atrColaDatos.encolar(500));
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(999, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrColaDatos.darUltimo().darItem());
        }
        [TestMethod]
        public void uTestEncolarVariosItems()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            bool varResultadoDeApilar = true;
            for (int varNumero = 0; varNumero < 500; varNumero++)
                varResultadoDeApilar = varResultadoDeApilar && atrColaDatos.encolar(varNumero);
            Assert.AreEqual(true, varResultadoDeApilar);
            Assert.AreEqual(500, atrColaDatos.darLongitud());
            Assert.AreEqual(0, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(499, atrColaDatos.darUltimo().darItem());
        }
        #endregion
        #region Desencolar
        [TestMethod]
        public void uTestDesencolarConColaVacia()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoDesencolado = 0;
            Assert.AreEqual(false, atrColaDatos.desencolar(ref varElementoDesencolado));
            Assert.AreEqual(0, varElementoDesencolado);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            Assert.AreEqual(null, atrColaDatos.darUltimo());
        }
        [TestMethod]
        public void uTestDesencolarUnItemCaso1()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoDesapilado = 0;
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            Assert.AreEqual(true, atrColaDatos.desencolar(ref varElementoDesapilado));
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            Assert.AreEqual(5000, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(5000, atrColaDatos.darUltimo().darItem());
        }
        [TestMethod]
        public void uTestDesencolarUnItemCaso2()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoDesapilado = 0;
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            atrColaDatos.encolar(8000);
            Assert.AreEqual(true, atrColaDatos.desencolar(ref varElementoDesapilado));
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(5000, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(8000, atrColaDatos.darUltimo().darItem());
        }
        [TestMethod]
        public void uTestDesencolarVaciarItemsCaso1()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoDesapilado = 0;
            atrColaDatos.encolar(2000);
            Assert.AreEqual(true, atrColaDatos.desencolar(ref varElementoDesapilado));
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            Assert.AreEqual(null, atrColaDatos.darUltimo());
        }
        [TestMethod]
        public void uTestDesencolarVaciarItemsCaso2()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoDesapilado1 = 0;
            int varElementoDesapilado2 = 0;
            bool varResultadoDesencolar;
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            varResultadoDesencolar = atrColaDatos.desencolar(ref varElementoDesapilado1) && atrColaDatos.desencolar(ref varElementoDesapilado2);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesapilado1);
            Assert.AreEqual(5000, varElementoDesapilado2);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            Assert.AreEqual(null, atrColaDatos.darUltimo());
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisarPilaConItems()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoRevisado = 0;
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            Assert.AreEqual(true, atrColaDatos.revisar(ref varElementoRevisado));
            Assert.AreEqual(2000, varElementoRevisado);
        }
        [TestMethod]
        public void uTestRevisarPilaVacia()
        {
            atrColaDatos = new clsColaSimpleEnlazada<int>();
            int varElementoRevisado = 0;
            Assert.AreEqual(false, atrColaDatos.revisar(ref varElementoRevisado));
            Assert.AreEqual(0, varElementoRevisado);
        }
        #endregion
        #endregion
    }
}