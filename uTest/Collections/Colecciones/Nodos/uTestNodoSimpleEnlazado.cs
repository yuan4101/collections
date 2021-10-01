using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Nodos;

namespace uTest.Servicios.Colecciones.Nodos
{
    [TestClass]
    public class uTestNodoSimpleEnlazado
    {
        #region Atributo de prueba
        clsNodoSimpleEnlazado<int> atrNodoSimpleEnlazado;
        clsNodoSimpleEnlazado<int> atrNodoSimpleEnlazado1;
        clsNodoSimpleEnlazado<int> atrNodoSimpleEnlazado2;
        #endregion
        #region Casos de prueba
        [TestMethod]
        public void uTestDarSiguienteYconstructorNoParametrizado()
        {
            atrNodoSimpleEnlazado = new clsNodoSimpleEnlazado<int>();
            Assert.AreEqual(atrNodoSimpleEnlazado.darItem(), 0);
            Assert.AreEqual(atrNodoSimpleEnlazado.darSiguiente(), null);
        }
        [TestMethod]
        public void uTestConstructorParametrizado()
        {
            atrNodoSimpleEnlazado = new clsNodoSimpleEnlazado<int>(1);
            Assert.AreEqual(atrNodoSimpleEnlazado.darItem(), 1);
            Assert.AreEqual(atrNodoSimpleEnlazado.darSiguiente(), null);
        }
        [TestMethod]
        public void uTestConectar()
        {
            atrNodoSimpleEnlazado = new clsNodoSimpleEnlazado<int>();
            atrNodoSimpleEnlazado1 = new clsNodoSimpleEnlazado<int>();
            Assert.AreEqual(true, atrNodoSimpleEnlazado.conectar(atrNodoSimpleEnlazado1));
            Assert.AreEqual(false, atrNodoSimpleEnlazado.conectar(null));
        }
        [TestMethod]
        public void uTestDesconectar()
        {
            atrNodoSimpleEnlazado = new clsNodoSimpleEnlazado<int>();
            atrNodoSimpleEnlazado1 = new clsNodoSimpleEnlazado<int>();
            Assert.AreEqual(false, atrNodoSimpleEnlazado.desconectar(ref atrNodoSimpleEnlazado2));
            Assert.AreEqual(null, atrNodoSimpleEnlazado2);
            Assert.AreEqual(true, atrNodoSimpleEnlazado.conectar(atrNodoSimpleEnlazado1));
            Assert.AreEqual(true, atrNodoSimpleEnlazado.desconectar(ref atrNodoSimpleEnlazado2));
            Assert.AreEqual(atrNodoSimpleEnlazado1, atrNodoSimpleEnlazado2);
        }
        #endregion
    }
}
