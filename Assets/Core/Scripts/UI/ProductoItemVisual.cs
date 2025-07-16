using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ProductoTipo
{
    Cafe,
    Pastel,
    
}
public class ProductoUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image imagenProducto;
    [SerializeField] private TMP_Text nombreTexto;
    [SerializeField] private TMP_Text precioTexto;
    [SerializeField] private Button botonAgregar;

    [Header("Datos del producto")]
    [SerializeField] private ProductoTipo tipoProducto;
    [SerializeField] private Sprite icono;

    private PedidoController controller;
    private Pedido productoData;

    public void Inicializar(PedidoController controller)
    {
        this.controller = controller;
    }
    void Start()
    {
        controller = FindFirstObjectByType<PedidoController>();

        productoData = ProductoFactory.CrearProducto(tipoProducto);

        if (productoData == null)
        {
            Debug.LogError($"Producto no encontrado: {tipoProducto}");
            return;
        }

        
        nombreTexto.text = productoData.Nombre;
        precioTexto.text = $"${productoData.PrecioBase}";
        imagenProducto.sprite = icono;

        botonAgregar.onClick.AddListener(() => controller.AgregarProducto(tipoProducto));
    }
}
