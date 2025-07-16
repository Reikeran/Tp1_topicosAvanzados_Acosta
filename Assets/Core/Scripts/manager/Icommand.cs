using UnityEngine;

public interface ICommand
{
    void Execute();
}
public class EliminarProductoCommand : ICommand
{
    private Pedido pedido;
    private PedidoController controller;

    public EliminarProductoCommand(Pedido pedido, PedidoController controller)
    {
        this.pedido = pedido;
        this.controller = controller;
    }

    public void Execute()
    {
        controller.EliminarProductoDelCarrito(pedido);
    }
}

public class EliminarPedidoCommand : ICommand
{
    private readonly Pedido pedido;
    private readonly PedidoController controller;
    private readonly GameObject uiObject;

    public EliminarPedidoCommand(Pedido pedido, PedidoController controller, GameObject uiObject)
    {
        this.pedido = pedido;
        this.controller = controller;
        this.uiObject = uiObject;
    }

    public void Execute()
    {
        controller.EliminarPedidoProcesado(pedido);
        GameObject.Destroy(uiObject);
    }
}
