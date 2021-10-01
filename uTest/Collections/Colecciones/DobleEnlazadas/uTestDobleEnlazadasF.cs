using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;
using Servicios.Colecciones.Nodos;

namespace uTest.Servicios.Colecciones.DobleEnlazadas
{
    [TestClass]
    public class uTestPilaDobleEnlazadaF
    {
        #region Atributos de Prueba
        clsPilaDobleEnlazada<int> atrPilaDatos;
        #endregion
        #region casos de prueba
        #region Apilar
        [TestMethod]
        public void testApilarUnItem()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            bool varResultadoDeApilar;
            #endregion
            #region Probar
            varResultadoDeApilar = atrPilaDatos.apilar(2000);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDeApilar);
            Assert.AreEqual(2000, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void testApilarDosItems()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            #endregion
            #region Probar
            Assert.AreEqual(true, atrPilaDatos.apilar(999));
            Assert.AreEqual(true, atrPilaDatos.apilar(500));
            #endregion
            #region Comprobar
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(500, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(999, atrPilaDatos.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testApilarVariosItems()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            bool varResultadoDeApilar = true;
            #endregion
            #region Probar
            for (int varNumero = 0; varNumero < 500; varNumero++)
                varResultadoDeApilar = varResultadoDeApilar && atrPilaDatos.apilar(varNumero);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDeApilar);
            Assert.AreEqual(500, atrPilaDatos.darLongitud());
            Assert.AreEqual(499, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(0, atrPilaDatos.darUltimo().darItem());
            #endregion
        }
        #endregion
        #region Desapilar
        [TestMethod]
        public void testDesapilarConPilaVacia()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar
            varResultadoDesapilar = atrPilaDatos.desapilar(ref varElementoDesapilado);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultadoDesapilar);
            Assert.AreEqual(0, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            #endregion
        }
        [TestMethod]
        public void testDesapilarUnItemCaso1()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar
            varResultadoDesapilar = atrPilaDatos.desapilar(ref varElementoDesapilado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado);
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(2000, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDatos.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testDesapilarUnItemCaso2()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            atrPilaDatos.apilar(8000);
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar
            varResultadoDesapilar = atrPilaDatos.desapilar(ref varElementoDesapilado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(8000, varElementoDesapilado);
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(5000, atrPilaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDatos.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testDesapilarVaciarItemsCaso1()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDatos.apilar(2000);
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar
            varResultadoDesapilar = atrPilaDatos.desapilar(ref varElementoDesapilado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            #endregion
        }
        [TestMethod]
        public void testDesapilarVaciarItemsCaso2()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            bool varResultadoDesapilar;
            int varElementoDesapilado1 = 0;
            int varElementoDesapilado2 = 0;
            #endregion
            #region Probar
            varResultadoDesapilar = atrPilaDatos.desapilar(ref varElementoDesapilado1) && atrPilaDatos.desapilar(ref varElementoDesapilado2);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado1);
            Assert.AreEqual(2000, varElementoDesapilado2);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDatos.darPrimero());
            #endregion
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void testRevisarPilaConItems()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDatos.apilar(2000);
            atrPilaDatos.apilar(5000);
            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar
            varResultadoRevisar = atrPilaDatos.revisar(ref varElementoRevisado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoRevisar);
            Assert.AreEqual(5000, varElementoRevisado);
            #endregion
        }
        [TestMethod]
        public void testRevisarPilaVacia()
        {
            #region Inicializar
            atrPilaDatos = new clsPilaDobleEnlazada<int>();
            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar
            varResultadoRevisar = atrPilaDatos.revisar(ref varElementoRevisado);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultadoRevisar);
            Assert.AreEqual(default(int), varElementoRevisado);
            #endregion
        }
        #endregion
        #endregion
    }
    [TestClass]
    public class uTestColaDobleEnlazadaF
    {
        #region Atributos de Prueba
        clsColaDobleEnlazada<int> atrColaDatos;
        #endregion
        #region casos de prueba
        #region Encolar
        [TestMethod]
        public void testEncolarUnItem()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            bool varResultadoDeEncolar;
            #endregion
            #region Probar
            varResultadoDeEncolar = atrColaDatos.encolar(2000);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDeEncolar);
            Assert.AreEqual(2000, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrColaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void testEncolarDosItems()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            #endregion
            #region Probar
            Assert.AreEqual(true, atrColaDatos.encolar(999));
            Assert.AreEqual(true, atrColaDatos.encolar(500));
            #endregion
            #region Comprobar
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(999, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrColaDatos.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testEncolarLlenarCola()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            bool varResultadoDeEncolar = true;
            #endregion
            #region Probar
            for (int varNumero = 0; varNumero < 500; varNumero++)
                varResultadoDeEncolar = varResultadoDeEncolar && atrColaDatos.encolar(varNumero);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDeEncolar);
            Assert.AreEqual(500, atrColaDatos.darLongitud());
            Assert.AreEqual(0, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(499, atrColaDatos.darUltimo().darItem());
            #endregion
        }
        #endregion
        #region Desencolar
        [TestMethod]
        public void testDesencolarConColaVacia()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar
            varResultadoDesencolar = atrColaDatos.desencolar(ref varElementoDesencolado);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultadoDesencolar);
            Assert.AreEqual(0, varElementoDesencolado);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            #endregion
        }
        [TestMethod]
        public void testDesencolarUnItemCaso1()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar
            varResultadoDesencolar = atrColaDatos.desencolar(ref varElementoDesencolado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            Assert.AreEqual(5000, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(5000, atrColaDatos.darPrimero().darItem());
            #endregion
        }
        [TestMethod]
        public void testDesencolarUnItemCaso2()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            atrColaDatos.encolar(8000);
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar
            varResultadoDesencolar = atrColaDatos.desencolar(ref varElementoDesencolado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(5000, atrColaDatos.darPrimero().darItem());
            Assert.AreEqual(8000, atrColaDatos.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testDesencolarVaciarItemsCaso1()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            atrColaDatos.encolar(2000);
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar
            varResultadoDesencolar = atrColaDatos.desencolar(ref varElementoDesencolado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            #endregion
        }
        [TestMethod]
        public void testDesencolarVaciarItemsCaso2()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            bool varResultadoDesencolar;
            int varElementoDesencolado1 = 0;
            int varElementoDesencolado2 = 0;
            #endregion
            #region Probar
            varResultadoDesencolar = atrColaDatos.desencolar(ref varElementoDesencolado1) && atrColaDatos.desencolar(ref varElementoDesencolado2);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado1);
            Assert.AreEqual(5000, varElementoDesencolado2);
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            Assert.AreEqual(null, atrColaDatos.darPrimero());
            #endregion
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void testRevisarColaConItems()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            atrColaDatos.encolar(2000);
            atrColaDatos.encolar(5000);
            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar
            varResultadoRevisar = atrColaDatos.revisar(ref varElementoRevisado);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoRevisar);
            Assert.AreEqual(2000, varElementoRevisado);
            #endregion
        }
        [TestMethod]
        public void testRevisarColaVacia()
        {
            #region Inicializar
            atrColaDatos = new clsColaDobleEnlazada<int>();
            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar
            varResultadoRevisar = atrColaDatos.revisar(ref varElementoRevisado);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultadoRevisar);
            Assert.AreEqual(default(int), varElementoRevisado);
            #endregion
        }
        #endregion
        #endregion
    }
    [TestClass]
    public class uTestListaDobleEnlazadaF
    {
        #region Atributos de Prueba
        clsListaDobleEnlazada<int> atrLista;
        #endregion
        #region Casos de Prueba
        #region Agregar
        [TestMethod]
        public void testAgregarUnItem()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            bool varResultadoDeAgregar = false;
            #endregion
            #region Probar
            varResultadoDeAgregar = atrLista.agregar(2000);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDeAgregar);
            Assert.AreEqual(1, atrLista.darLongitud());
            Assert.AreEqual(2000, atrLista.darPrimero().darItem());
            #endregion
        }
        [TestMethod]
        public void testAgregar2Items()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            #endregion
            #region Probar
            Assert.AreEqual(true, atrLista.agregar(999));
            Assert.AreEqual(true, atrLista.agregar(500));
            #endregion
            #region Comprobar
            Assert.AreEqual(2, atrLista.darLongitud());
            Assert.AreEqual(999, atrLista.darPrimero().darItem());
            Assert.AreEqual(500, atrLista.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testAgregarMuchosItems()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            bool varResultadoDeAgregar = true;
            #endregion
            #region Probar
            for (int varNumero = 0; varNumero < 500; varNumero++)
                varResultadoDeAgregar = varResultadoDeAgregar && atrLista.agregar(varNumero);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoDeAgregar);
            Assert.AreEqual(500, atrLista.darLongitud());
            Assert.AreEqual(499, atrLista.darUltimo().darItem());
            Assert.AreEqual(0, atrLista.darPrimero().darItem());
            #endregion
        }
        #endregion
        #region Insertar 
        [TestMethod]
        public void testInsertarUnItemEnListaConIndiceValido()
        {
            #region Configurar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar
            bool varResultado = atrLista.insertar(1, 2);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultado);
            Assert.AreEqual(4, atrLista.darLongitud());
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testInsertarUnItemEnListaConIndiceInvalido()
        {
            #region Configurar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(3);
            #endregion
            #region Probar
            int varItemRemovido = 0;
            bool varResultado = atrLista.remover(2, ref varItemRemovido);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultado);
            Assert.AreEqual(2, atrLista.darLongitud());
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(3, atrLista.darUltimo().darItem());
            #endregion
        }
        #endregion
        #region Remover 
        [TestMethod]
        public void testExtraerUnItemEnLista()
        {
            #region Configurar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(3);
            int varItemRemovido = 0;
            #endregion
            #region Probar
            bool varResultado = atrLista.remover(1, ref varItemRemovido);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultado);
            Assert.AreEqual(1, atrLista.darLongitud());
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(1, atrLista.darUltimo().darItem());
            Assert.AreEqual(3, varItemRemovido);
            #endregion
        }
        [TestMethod]
        public void testExtraerUnItemEnListaVacia()
        {
            #region Configurar
            atrLista = new clsListaDobleEnlazada<int>();
            #endregion
            #region Probar
            int varItemRemovido = 0;
            bool varResultado = atrLista.remover(1, ref varItemRemovido);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultado);
            Assert.AreEqual(0, atrLista.darLongitud());
            #endregion
        }
        [TestMethod]
        public void testExtraerUnItemConIndiceInvalido()
        {
            #region Configurar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar
            int varItemRemovido = 0;
            bool varResultado = atrLista.remover(3, ref varItemRemovido);
            #endregion
            #region Comprobar
            Assert.AreEqual(false, varResultado);
            Assert.AreEqual(3, atrLista.darLongitud());
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion
        }
        #endregion
        #region Modificar
        [TestMethod]
        public void testModificarEnColeccionVacia()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, atrLista.modificar(0, -1));
            #endregion
        }
        [TestMethod]
        public void testModificarPrimero()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar
            atrLista.modificar(0, -1);
            #endregion
            #region Comprobar
            Assert.AreEqual(-1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testModificarUltimo()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar
            atrLista.modificar(3, -1);
            #endregion
            #region Comprobar
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(-1, atrLista.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testModificarEnMedio()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar
            atrLista.modificar(2, -1);
            #endregion
            #region Comprobar
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(-1, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion
        }
        #endregion
        #region Recuperar
        [TestMethod]
        public void testRecuperarEnColeccionVacia()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            int varItem = 0;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, atrLista.recuperar(0, ref varItem));
            Assert.AreEqual(0, varItem);
            #endregion
        }
        [TestMethod]
        public void testRecuperarPrimero()
        {
            #region Inicializar
            int varItem = 0;
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrLista.recuperar(0, ref varItem));
            Assert.AreEqual(1, varItem);
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testRecuperarUltimo()
        {
            #region Inicializar
            int varItem = 0;
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrLista.recuperar(atrLista.darLongitud() - 1, ref varItem));
            Assert.AreEqual(4, varItem);
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion

        }
        [TestMethod]
        public void testRecuperarEnMedio()
        {
            #region Inicializar
            int varItem = 0;
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar
            #endregion
            #region Comprobar
            Assert.AreEqual(true, atrLista.recuperar(2, ref varItem));
            Assert.AreEqual(3, varItem);
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion

        }
        #endregion
        #region Encontrar
        [TestMethod]
        public void testEncontrarEnColeccionVacia()
        {
            #region Inicializar
            atrLista = new clsListaDobleEnlazada<int>();
            int varItem = 0;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, atrLista.encontrar(0, ref varItem));
            Assert.AreEqual(0, varItem);
            #endregion
        }
        [TestMethod]
        public void testEncontrarPrimero()
        {
            #region Inicializar
            int varItem = 0;
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrLista.encontrar(1, ref varItem));
            Assert.AreEqual(0, varItem);
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion
        }
        [TestMethod]
        public void testEncontrarUltimo()
        {
            #region Inicializar
            int varItem = 0;
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrLista.encontrar(4, ref varItem));
            Assert.AreEqual(3, varItem);
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion

        }
        [TestMethod]
        public void testEncontrarEnMedio()
        {
            #region Inicializar
            int varItem = 0;
            atrLista = new clsListaDobleEnlazada<int>();
            atrLista.agregar(1);
            atrLista.agregar(2);
            atrLista.agregar(3);
            atrLista.agregar(4);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrLista.encontrar(2, ref varItem));
            Assert.AreEqual(1, varItem);
            Assert.AreEqual(1, atrLista.darPrimero().darItem());
            Assert.AreEqual(2, atrLista.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(3, atrLista.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(4, atrLista.darUltimo().darItem());
            #endregion

        }
        #endregion
        #endregion
    }
    [TestClass]
    public class uTestNodoF
    {
        clsNodoDobleEnlazado<int> Nodo1 = new clsNodoDobleEnlazado<int>(1);
        clsNodoDobleEnlazado<int> nodo2 = new clsNodoDobleEnlazado<int>(2);
       [TestMethod]
       public void NodoDoble()
        {
            Nodo1.conectar(nodo2);
            Assert.AreEqual(2, Nodo1.darSiguiente().darItem());
            Assert.AreEqual(1, nodo2.darAnterior().darItem());
        } 
        
    }
}
