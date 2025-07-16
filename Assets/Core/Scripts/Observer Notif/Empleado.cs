using UnityEngine;
public class Empleado : IObserver
{
    public string Nombre;

    public Empleado(string nombre)
    {
        Nombre = nombre;
    }

    public void Notificar(string mensaje)
    {
        Debug.Log($"[Empleado {Nombre}] {mensaje}");
    }
}
