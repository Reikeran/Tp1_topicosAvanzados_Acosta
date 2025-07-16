using UnityEngine;
public class Cliente : IObserver
{
    public string Nombre;

    public Cliente(string nombre)
    {
        Nombre = nombre;
    }

    public void Notificar(string mensaje)
    {
        Debug.Log($"[Cliente {Nombre}] {mensaje}");
    }
}