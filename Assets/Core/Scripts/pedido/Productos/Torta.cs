using UnityEngine;
public class Torta : Pedido, IConTiempo
{
    public float TiempoPreparacion => 5f;

    public Torta()
    {
        Nombre = "Torta";
        PrecioBase = 250;
    }

    public override void Preparar()
    {
        Debug.Log("Preparando Torta...");
    }
}