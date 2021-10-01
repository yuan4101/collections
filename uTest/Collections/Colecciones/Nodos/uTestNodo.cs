using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Nodos;

namespace uTest.Servicios.Colecciones.Nodos
{
    [TestClass]
    public class uTestNodo
    {
        #region Atributo de prueba
        clsNodo<int> atrNodo;
        #endregion
        #region Casos de prueba
        [TestMethod]
        public void uTestDarYponer()
        {
            atrNodo = new clsNodo<int>(5);
            Assert.AreEqual(atrNodo.darItem(), 5);
            atrNodo.poner(10);
            Assert.AreEqual(atrNodo.darItem(), 10);
        }
        [TestMethod]
        public void uTestConstructorNoParametrizado()
        {
            atrNodo = new clsNodo<int>();
            Assert.AreEqual(atrNodo.darItem(), 0);
        }
        [TestMethod]
        public void uTestConstructorParametrizado()
        {
            atrNodo = new clsNodo<int>(1);
            Assert.AreEqual(atrNodo.darItem(), 1);
        }
        #endregion
    }
}
