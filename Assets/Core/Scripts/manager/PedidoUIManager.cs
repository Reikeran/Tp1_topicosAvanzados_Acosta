using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PedidoUIManager : MonoBehaviour
{
    public Transform carritoContent; 
    public GameObject carritoItemPrefab;
    public TMP_Text totalText;

    private PedidoController controller;

    public void Inicializar(PedidoController controller)
    {
        this.controller = controller;

    }

    public void ActualizarCarritoUI(PedidoCompuesto carrito, float totalConDescuento)
    {
        
        foreach (Transform hijo in carritoContent)
            GameObject.Destroy(hijo.gameObject);

        if (carrito != null && carrito.GetSubPedidos().Count > 0)
        {
            foreach (var p in carrito.GetSubPedidos())
            {
                GameObject nuevoItem = GameObject.Instantiate(carritoItemPrefab, carritoContent);
                nuevoItem.GetComponent<CarritoItemUI>().Inicializar(p, controller);
            }
            totalText.text = $"Total: ${totalConDescuento:F2}";
        }
        else
        {
            totalText.text = "Total: $0.00";
        }
    }
}
