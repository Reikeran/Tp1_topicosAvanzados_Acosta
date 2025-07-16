using System.Collections.Generic;

public class CarritoManager
{
    private PedidoCompuesto carrito;
    private IDescuentoStrategy descuentoActual = new SinDescuento();

    public CarritoManager(string nombrePedidoInicial)
    {
        carrito = new PedidoCompuesto(nombrePedidoInicial);
    }

    public void AgregarProducto(Pedido pedido)
    {
        carrito.Agregar(pedido);
    }

    public void RemoverProducto(Pedido pedido)
    {
        carrito.Remover(pedido);
    }

    public PedidoCompuesto ObtenerCarrito() => carrito;

    public void CrearNuevoCarrito(string nombre)
    {
        carrito = new PedidoCompuesto(nombre);
    }

    public void ConfigurarDescuento(IDescuentoStrategy descuento)
    {
        descuentoActual = descuento;
    }

    public float CalcularTotalConDescuento()
    {
        float totalSinDescuento = 0;
        foreach (var p in carrito.GetSubPedidos())
            totalSinDescuento += p.PrecioBase;

        return descuentoActual.AplicarDescuento(totalSinDescuento);
    }

    public bool EstaVacio()
    {
        return carrito.GetSubPedidos().Count == 0;
    }
}
