using static UnityEngine.Rendering.DebugUI;

public static class ProductoFactory
{
    public static Pedido CrearProducto(ProductoTipo tipo)
    {
        return tipo switch
        {
            ProductoTipo.Cafe => new Cafe(),
            ProductoTipo.Pastel => new Torta(),
            _ => null
        };
    }
}
