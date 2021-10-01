namespace Servicios.Colecciones.Interfaces
{
    interface iTadVectorial<Tipo> : iTad<Tipo>
    {
        int darCapacidad();
        Tipo[] darItems();
        void poner(Tipo[] prmItems);
        bool ordenarBurbuja(bool prmPorDescendente);
        bool ordenarCoctel(bool prmPorDescendente);
        bool ordenarSeleccion(bool prmPorDescendente);
        bool ordenarInsercion(bool prmPorDescendente);
        bool ordenarMezcla(bool prmPorDescendente, int prmIdxInicial, int prmIdxFinal);
        bool ordenarQuick(bool prmPorDescendente, int prmIdxInicial, int prmIdxFinal);
        
    }
}
