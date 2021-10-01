using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTest.Servicios.Colecciones.DobleEnlazadas
{
    [TestClass]
    public class uTestListaDobleEnlazada
    {
        #region Atributos de prueba
        public clsListaDobleEnlazada<int> atrListaDatos;
        #endregion
        #region Casos de prueba
        #region Agregar
        [TestMethod]
        public void uTestAgregarUnItem()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            Assert.AreEqual(true, atrListaDatos.agregar(2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.atrPrimero.darItem());
            Assert.AreEqual(2000, atrListaDatos.atrUltimo.darItem());
        }
        [TestMethod]
        public void uTestAgregarDosItems()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            Assert.AreEqual(true, atrListaDatos.agregar(2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.agregar(5000));
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.atrPrimero.atrItem);
            Assert.AreEqual(5000, atrListaDatos.atrUltimo.atrItem);
        }
        [TestMethod]
        public void uTestAgregarVariosItems()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            bool varBoolResultado = true;
            for (int varContador = 0; varContador < 5; varContador++)
                varBoolResultado = varBoolResultado && atrListaDatos.agregar(varContador);
            Assert.AreEqual(true, varBoolResultado);
            Assert.AreEqual(0, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrListaDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(4, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(5, atrListaDatos.darLongitud());
        }
        #endregion
        #region Insertar
        [TestMethod]
        public void uTestInsertarFueraDeRangoConListaVacia()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            Assert.AreEqual(false, atrListaDatos.insertar(-1, 1000));
            Assert.AreEqual(false, atrListaDatos.insertar(0, 2000));
            Assert.AreEqual(false, atrListaDatos.insertar(1, 3000));
        }
        [TestMethod]
        public void uTestInsertarFueraDeRangoConListaLlena()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(4000);
            Assert.AreEqual(false, atrListaDatos.insertar(-1, 1000));
            Assert.AreEqual(false, atrListaDatos.insertar(1, 3000));
            Assert.AreEqual(4000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(4000, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrListaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestInsertarUnItem()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(4000);
            Assert.AreEqual(true, atrListaDatos.insertar(0, 2000));
            Assert.AreEqual(2000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(4000, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(2, atrListaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestInsertarVariosItems()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            for (int varContador = 0; varContador < 5; varContador++)
                atrListaDatos.agregar(varContador);
            Assert.AreEqual(5, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.insertar(4, 10));
            Assert.AreEqual(true, atrListaDatos.insertar(4, 9));
            Assert.AreEqual(true, atrListaDatos.insertar(4, 8));
            Assert.AreEqual(0, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(4, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(8, atrListaDatos.darPrimero().darSiguiente().darSiguiente().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(8, atrListaDatos.darLongitud());
        }
        #endregion
        #region Remover
        [TestMethod]
        public void uTestRemoverFueraDeRangoConListaVacia()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            int varItemRemovido = 0;
            Assert.AreEqual(false, atrListaDatos.remover(-1, ref varItemRemovido));
            Assert.AreEqual(false, atrListaDatos.remover(0, ref varItemRemovido));
            Assert.AreEqual(false, atrListaDatos.remover(1, ref varItemRemovido));
            Assert.AreEqual(0, varItemRemovido);
        }
        [TestMethod]
        public void uTestRemoverFueraDeRangoConListaLlena()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(4000);
            int varItemRemovido = 0;
            Assert.AreEqual(false, atrListaDatos.remover(-1, ref varItemRemovido));
            Assert.AreEqual(false, atrListaDatos.remover(1, ref varItemRemovido));
            Assert.AreEqual(4000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(4000, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(0, varItemRemovido);
        }
        [TestMethod]
        public void uTestRemoverUnItem()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(4000);
            int varItemRemovido = 0;
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(0, ref varItemRemovido));
            Assert.AreEqual(null, atrListaDatos.darPrimero());
            Assert.AreEqual(null, atrListaDatos.darUltimo());
            Assert.AreEqual(0, atrListaDatos.darLongitud());
            Assert.AreEqual(4000, varItemRemovido);
        }
        [TestMethod]
        public void uTestRemoverVariosItems()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            int varItemRemovido = 0;
            for (int varContador = 1; varContador < 6; varContador++)
                atrListaDatos.agregar(varContador);
            Assert.AreEqual(5, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(4, ref varItemRemovido));
            Assert.AreEqual(5, varItemRemovido);
            Assert.AreEqual(4, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(true, atrListaDatos.remover(3, ref varItemRemovido));
            Assert.AreEqual(4, varItemRemovido);
            Assert.AreEqual(3, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(true, atrListaDatos.remover(1, ref varItemRemovido));
            Assert.AreEqual(2, varItemRemovido);
            Assert.AreEqual(1, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(3, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(0, ref varItemRemovido));
            Assert.AreEqual(1, varItemRemovido);
            Assert.AreEqual(3, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(3, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(true, atrListaDatos.remover(0, ref varItemRemovido));
            Assert.AreEqual(3, varItemRemovido);
            Assert.AreEqual(null, atrListaDatos.darPrimero());
            Assert.AreEqual(null, atrListaDatos.darUltimo());
            Assert.AreEqual(0, atrListaDatos.darLongitud());
        }
        #endregion
        #region Modificar
        [TestMethod]
        public void uTestModificarFueraDeRangoConListaVacia()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            Assert.AreEqual(false, atrListaDatos.modificar(-1, 1000));
            Assert.AreEqual(false, atrListaDatos.modificar(0, 2000));
            Assert.AreEqual(false, atrListaDatos.modificar(1, 3000));
            Assert.AreEqual(0, atrListaDatos.darLongitud());
        }
        [TestMethod]
        public void uTestModificarUnItemEnListaLlena()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(4000);
            Assert.AreEqual(true, atrListaDatos.modificar(0, 2000));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrListaDatos.darUltimo().darItem());
            atrListaDatos.agregar(5000);
            Assert.AreEqual(true, atrListaDatos.modificar(1, 3000));
            Assert.AreEqual(2000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(3000, atrListaDatos.darUltimo().darItem());
            Assert.AreEqual(2, atrListaDatos.darLongitud());
        }
        #endregion
        #region Recuperar
        [TestMethod]
        public void uTestRecuperarFueraDeRangoConListaVacia()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            int varItemRecuperado = 0;
            Assert.AreEqual(false, atrListaDatos.recuperar(-1, ref varItemRecuperado));
            Assert.AreEqual(false, atrListaDatos.recuperar(0, ref varItemRecuperado));
            Assert.AreEqual(false, atrListaDatos.recuperar(1, ref varItemRecuperado));
            Assert.AreEqual(0, varItemRecuperado);
            Assert.AreEqual(null, atrListaDatos.darPrimero());
            Assert.AreEqual(null, atrListaDatos.darUltimo());
        }
        [TestMethod]
        public void uTestRecuperarFueraDeRangoConListaLlena()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(2000);
            int varItemRecuperado = 0;
            Assert.AreEqual(false, atrListaDatos.recuperar(-1, ref varItemRecuperado));
            Assert.AreEqual(false, atrListaDatos.recuperar(1, ref varItemRecuperado));
            Assert.AreEqual(true, atrListaDatos.recuperar(0, ref varItemRecuperado));
            Assert.AreEqual(2000, varItemRecuperado);
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrListaDatos.darUltimo().darItem());
        }
        #endregion
        #region Encontrar
        [TestMethod]
        public void uTestEncontrarConListaVacia()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            int varIndiceItemEncontrado = 0;
            Assert.AreEqual(false, atrListaDatos.encontrar(-1, ref varIndiceItemEncontrado));
            Assert.AreEqual(false, atrListaDatos.encontrar(0, ref varIndiceItemEncontrado));
            Assert.AreEqual(false, atrListaDatos.encontrar(1, ref varIndiceItemEncontrado));
            Assert.AreEqual(0, varIndiceItemEncontrado);
            Assert.AreEqual(null, atrListaDatos.darPrimero());
            Assert.AreEqual(null, atrListaDatos.darUltimo());
        }
        [TestMethod]
        public void uTestEncontrarFueraDeRangoConListaLlena()
        {
            atrListaDatos = new clsListaDobleEnlazada<int>();
            atrListaDatos.agregar(1000);
            atrListaDatos.agregar(2000);
            atrListaDatos.agregar(3000);
            int varIndiceItemEncontrado = 0;
            Assert.AreEqual(false, atrListaDatos.encontrar(-1, ref varIndiceItemEncontrado));
            Assert.AreEqual(false, atrListaDatos.encontrar(1, ref varIndiceItemEncontrado));
            Assert.AreEqual(true, atrListaDatos.encontrar(1000, ref varIndiceItemEncontrado));
            Assert.AreEqual(0, varIndiceItemEncontrado);
            Assert.AreEqual(true, atrListaDatos.encontrar(3000, ref varIndiceItemEncontrado));
            Assert.AreEqual(2, varIndiceItemEncontrado);
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            Assert.AreEqual(1000, atrListaDatos.darPrimero().darItem());
            Assert.AreEqual(3000, atrListaDatos.darUltimo().darItem());
        }
        #endregion
        #endregion
    }
}