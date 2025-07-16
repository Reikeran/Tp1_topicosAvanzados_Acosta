using System.Collections.Generic;

public class NotifyManager
{
    private List<IObserver> observadores = new();

    public void Suscribir(IObserver obs) => observadores.Add(obs);

    public void NotificarTodos(string mensaje)
    {
        foreach (var obs in observadores)
            obs.Notificar(mensaje);
    }

    public void MarcarPedidoListo(Pedido pedido)
    {
        NotificarTodos($"El pedido '{pedido.Nombre}' está listo.");
    }
}