namespace Servicios.Colecciones.Interfaces
{
    interface iNodo<Tipo>
    {
        Tipo darItem();
        void poner(Tipo prmItem);
    }
}