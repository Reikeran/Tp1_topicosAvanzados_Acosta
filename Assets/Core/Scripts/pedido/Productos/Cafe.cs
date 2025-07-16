using UnityEngine;
public class Cafe : Pedido, IConTiempo
{
    public float TiempoPreparacion => 3f;

    public Cafe()
    {
        Nombre = "Caf�";
        PrecioBase = 150;
    }

    public override void Preparar()
    {
        Debug.Log("Preparando caf�...");
    }
}
