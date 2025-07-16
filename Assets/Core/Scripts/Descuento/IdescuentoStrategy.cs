public interface IDescuentoStrategy
{
    float AplicarDescuento(float precio);
}

public class DescuentoPorMembresia : IDescuentoStrategy
{
    public float AplicarDescuento(float precio) => precio * 0.9f;
}

public class SinDescuento : IDescuentoStrategy
{
    public float AplicarDescuento(float precio) => precio;
}
public class DescuentoPorVolumen : IDescuentoStrategy
{
    public float AplicarDescuento(float precio) => precio >= 500 ? precio * 0.8f : precio;
}