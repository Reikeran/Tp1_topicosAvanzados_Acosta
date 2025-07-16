using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalOrderUI : MonoBehaviour
{

    [SerializeField] private TMP_Text clienteText;
    [SerializeField] private TMP_Text totalText;
    [SerializeField] private TMP_Text estadoText;
    [SerializeField] private Button eliminarButton;
    private ICommand eliminarCommand;

    private PedidoController controller;
    private Pedido pedido;

    public void SetData(Pedido pedido, string cliente, float total, string estado, ICommand eliminarCommand)
    {
        this.pedido = pedido;


        this.eliminarCommand = eliminarCommand;

        clienteText.text = $"Cliente: {cliente}";
        totalText.text = $"Total: ${total}";
        estadoText.text = estado;

        eliminarButton.onClick.RemoveAllListeners();
        eliminarButton.onClick.AddListener(() => eliminarCommand.Execute());
    }

    public void ActualizarEstado(string nuevoEstado)
    {
        estadoText.text = nuevoEstado;
    }

   
}
