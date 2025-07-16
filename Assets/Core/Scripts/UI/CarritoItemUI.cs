using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarritoItemUI : MonoBehaviour
{
    
    [SerializeField] private TMP_Text nombreTexto;
    [SerializeField] private TMP_Text precioTexto;
    [SerializeField] private Image icono;
    [SerializeField] private Button botonEliminar;
    private ICommand eliminarCommand;

    private Pedido pedido;
    private PedidoController controller;

    public void Inicializar(Pedido pedido, PedidoController controller)
    {
        this.pedido = pedido;
        eliminarCommand = new EliminarProductoCommand(pedido, controller);

        nombreTexto.text = pedido.Nombre;
        precioTexto.text = $"${pedido.PrecioBase}";
        

        botonEliminar.onClick.RemoveAllListeners();
        botonEliminar.onClick.AddListener(() => eliminarCommand.Execute());
    }
    
}
