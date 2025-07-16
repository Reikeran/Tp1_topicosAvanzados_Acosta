public class DescuentoCombinado : IDescuentoStrategy
{
    private readonly IDescuentoStrategy primero;
    private readonly IDescuentoStrategy segundo;

    public DescuentoCombinado(IDescuentoStrategy primero, IDescuentoStrategy segundo)
    {
        this.primero = primero;
        this.segundo = segundo;
    }

    public float AplicarDescuento(float precio)
    {
        float parcial = primero.AplicarDescuento(precio);
        return segundo.AplicarDescuento(parcial);
    }
}