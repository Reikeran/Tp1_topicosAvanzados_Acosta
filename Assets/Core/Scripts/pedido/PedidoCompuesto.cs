using System.Collections.Generic;
using UnityEngine;

public class PedidoCompuesto : Pedido
{
    private List<Pedido> subPedidos = new();

    public PedidoCompuesto(string nombre)
    {
        Nombre = nombre;
        PrecioBase = 0;
    }

    public void Agregar(Pedido pedido)
    {
        subPedidos.Add(pedido);
        PrecioBase += pedido.PrecioBase;
    }

    public override void Preparar()
    {
        Debug.Log($"Preparando combo: {Nombre}");
        foreach (var pedido in subPedidos)
        {
            pedido.Preparar();
        }
    }

    public List<Pedido> GetSubPedidos()
    {
        return subPedidos;
    }
    public void Remover(Pedido pedido)
    {
        if (subPedidos.Contains(pedido))
        {
            subPedidos.Remove(pedido);
            PrecioBase -= pedido.PrecioBase;
        }
    }
}
