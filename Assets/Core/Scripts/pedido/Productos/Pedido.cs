using UnityEngine;
public abstract class Pedido
{
    public string Nombre { get; protected set; }
    public float PrecioBase { get; protected set; }
    public IDescuentoStrategy DescuentoStrategy { get; set; } = new SinDescuento();

    public virtual float CalcularPrecioFinal() => DescuentoStrategy.AplicarDescuento(PrecioBase);
    public abstract void Preparar();
}
