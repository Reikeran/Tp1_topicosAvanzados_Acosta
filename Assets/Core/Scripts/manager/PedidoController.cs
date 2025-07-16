using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PedidoController : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField inputClienteNombre;
    public GameObject pedidoResumenPrefab;
    public Transform pedidosContent;
    public Toggle membresiaToggle;
    public string Empleado;

    private CarritoManager carritoManager;
    private PedidoUIManager uiManager;

    private List<Pedido> pedidosProcesados = new();
    private int numeroPedido = 1;

    void Start()
    {
        carritoManager = new CarritoManager($"Pedido #{numeroPedido}");
        uiManager = GetComponent<PedidoUIManager>();
        if (uiManager == null)
            Debug.LogError("PedidoUIManager no encontrado en el mismo GameObject.");

        uiManager.Inicializar(this);
        ActualizarUI();
    }

    public void AgregarProducto(ProductoTipo tipo)
    {
        Pedido nuevo = ProductoFactory.CrearProducto(tipo);
        if (nuevo != null)
        {
            carritoManager.AgregarProducto(nuevo);
            ActualizarUI();
        }
    }

    public void EliminarProductoDelCarrito(Pedido pedido)
    {
        carritoManager.RemoverProducto(pedido);
        ActualizarUI();
    }

    public void PlaceOrder()
    {
        if (carritoManager.EstaVacio()) return;

        string cliente = string.IsNullOrWhiteSpace(inputClienteNombre.text) ? "Anónimo" : inputClienteNombre.text;

        // descuentos
        IDescuentoStrategy descuento = membresiaToggle.isOn
            ? new DescuentoCombinado(new DescuentoPorVolumen(), new DescuentoPorMembresia())
            : new DescuentoPorVolumen();

        carritoManager.ConfigurarDescuento(descuento);

        var carritoActual = carritoManager.ObtenerCarrito();

        float totalConDescuento = carritoManager.CalcularTotalConDescuento();

        
        NotifyManager notifyManager = new NotifyManager();
        notifyManager.Suscribir(new Cliente(cliente));
        notifyManager.Suscribir(new Empleado(Empleado));

        
        GameObject resumenGO = Instantiate(pedidoResumenPrefab, pedidosContent);
        FinalOrderUI resumenUI = resumenGO.GetComponent<FinalOrderUI>();
        var eliminarCommand = new EliminarPedidoCommand(carritoActual, this, resumenGO);
        resumenUI.SetData(carritoActual, cliente, totalConDescuento, "Preparando...", eliminarCommand);

        pedidosProcesados.Add(carritoActual);

        StartCoroutine(PrepararPedido(carritoActual, resumenUI, notifyManager));

        
        inputClienteNombre.text = "";
        membresiaToggle.isOn = false;

        carritoManager.CrearNuevoCarrito($"Pedido #{++numeroPedido}");
        ActualizarUI();
    }

    private IEnumerator PrepararPedido(Pedido pedido, FinalOrderUI resumenUI, NotifyManager notifyManager)
    {
        pedido.Preparar();

        float tiempoTotal = 0;
        if (pedido is PedidoCompuesto compuesto)
        {
            foreach (var p in compuesto.GetSubPedidos())
                tiempoTotal += p is IConTiempo t ? t.TiempoPreparacion : 2f;
        }
        else
        {
            tiempoTotal = pedido is IConTiempo t ? t.TiempoPreparacion : 2f;
        }

        yield return new WaitForSeconds(tiempoTotal);

        notifyManager.MarcarPedidoListo(pedido);
        resumenUI.ActualizarEstado("Listo");
    }

    public void EliminarPedidoProcesado(Pedido pedido)
    {
        if (pedidosProcesados.Contains(pedido))
            pedidosProcesados.Remove(pedido);
    }

    private void ActualizarUI()
    {
        float totalConDescuento = carritoManager.CalcularTotalConDescuento();
        uiManager.ActualizarCarritoUI(carritoManager.ObtenerCarrito(), totalConDescuento);
    }
}
