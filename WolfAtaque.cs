using UnityEngine;
using UnityEngine.UI;

public class WolfSystem : MonoBehaviour
{
    public Text messageText; // Texto donde se mostrarán los mensajes.
    public int enemyHealth = 200; // Vida inicial del enemigo.

    public Animator animator; // Controlador de animaciones del monstruo.

    // Botones
    public Button ataqueRapidoButton;
    public Button mordidaButton;
    public Button rugidoButton;

    // Métodos para los ataques
    void Start()
    {
        // Asignar listeners a los botones
        ataqueRapidoButton.onClick.AddListener(() => PerformAttack("Puño Rapido"));
        mordidaButton.onClick.AddListener(() => PerformAttack("Mordida"));
        rugidoButton.onClick.AddListener(() => PerformAttack("Rugido"));
    }

    void PerformAttack(string attackType)
    {
        int damage = 0;
        string message = "";

        // Elegir el ataque basado en el tipo seleccionado
        switch (attackType)
        {
            case "Puño Rapido":
                damage = 60;
                message = "Es muy efectivo";
                animator.Play("Puño Rapido"); // Reproduce la animación del ataque rápido
                break;
            case "Mordida":
                damage = 20;
                message = "Es poco efectivo";
                animator.Play("Mordida"); // Reproduce la animación de mordisco
                break;
            case "Rugido":
                damage = 40;
                message = "Es efectivo";
                animator.Play("Rugido"); // Reproduce la animación de golpe violento
                break;
        }

        // Reducir la vida del enemigo
        enemyHealth -= damage;

        // Mostrar el mensaje en pantalla
        messageText.text = message;

        // Verificar si el enemigo ha sido derrotado
        if (enemyHealth <= 0)
        {
            messageText.text = "El enemigo ha sido derrotado!";
        }
    }
}