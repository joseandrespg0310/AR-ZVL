using UnityEngine;
using UnityEngine.UI;

public class TurnBasedCombatSystem : MonoBehaviour
{
    public Text messageText; // Texto para mostrar mensajes.

    // Vida inicial de los personajes
    public int zombieHealth = 200;
    public int wolfHealth = 200;

    public Animator zombieAnimator; // Controlador de animaciones del zombie.
    public Animator wolfAnimator;   // Controlador de animaciones del lobo.

    // Botones de ataque para el zombie
    public Button ataqueRapidoZombieButton;
    public Button mordiscoZombieButton;
    public Button golpeViolentoZombieButton;

    // Botones de ataque para el lobo
    public Button ataqueRapidoLoboButton;
    public Button mordidaLoboButton;
    public Button rugidoLoboButton;

    private bool isZombieTurn; // Controla de quién es el turno

    void Start()
    {
        // Deshabilitar botones del lobo al inicio (zombie ataca primero)
        ToggleWolfButtons(false);

        // Decidir quién ataca primero aleatoriamente
        isZombieTurn = Random.Range(0, 2) == 0;

        if (isZombieTurn)
        {
            messageText.text = "Primero ataca el Zombie!";
        }
        else
        {
            messageText.text = "Primero ataca el Lobo!";
            Invoke("WolfTurn", 2f); // Después de mostrar el mensaje, el lobo ataca
        }

        // Asignar listeners a los botones de ataque del zombie
        ataqueRapidoZombieButton.onClick.AddListener(() => PerformZombieAttack("Ataque Rapido"));
        mordiscoZombieButton.onClick.AddListener(() => PerformZombieAttack("Mordisco"));
        golpeViolentoZombieButton.onClick.AddListener(() => PerformZombieAttack("Golpe Violento"));

        // Asignar listeners a los botones de ataque del lobo
        ataqueRapidoLoboButton.onClick.AddListener(() => PerformWolfAttack("Puño Rapido"));
        mordidaLoboButton.onClick.AddListener(() => PerformWolfAttack("Mordida"));
        rugidoLoboButton.onClick.AddListener(() => PerformWolfAttack("Rugido"));
    }

    void PerformZombieAttack(string attackType)
    {
        if (!isZombieTurn) return; // Solo permite al zombie atacar si es su turno

        int damage = 0;
        string message = "";

        switch (attackType)
        {
            case "Ataque Rapido":
                damage = 40;
                message = "Es efectivo";
                zombieAnimator.Play("Ataque Rapido");
                break;
            case "Mordisco":
                damage = 20;
                message = "Es poco efectivo";
                zombieAnimator.Play("Mordisco");
                break;
            case "Golpe Violento":
                damage = 60;
                message = "Es muy efectivo";
                zombieAnimator.Play("Golpe Violento");
                break;
        }

        // Reducir la vida del lobo
        wolfHealth -= damage;
        messageText.text = message;

        // Verificar si el lobo ha sido derrotado
        if (wolfHealth <= 0)
        {
            messageText.text = "El lobo ha sido derrotado!";
            return;
        }

        // Cambiar turno al lobo
        isZombieTurn = false;
        ToggleZombieButtons(false);
        Invoke("WolfTurn", 2f);
    }

    void PerformWolfAttack(string attackType)
    {
        if (isZombieTurn) return; // Solo permite al lobo atacar si es su turno

        int damage = 0;
        string message = "";

        switch (attackType)
        {
            case "Puño Rapido":
                damage = 60;
                message = "Es muy efectivo";
                wolfAnimator.Play("Puño Rapido");
                break;
            case "Mordida":
                damage = 20;
                message = "Es poco efectivo";
                wolfAnimator.Play("Mordida");
                break;
            case "Rugido":
                damage = 40;
                message = "Es efectivo";
                wolfAnimator.Play("Rugido");
                break;
        }

        // Reducir la vida del zombie
        zombieHealth -= damage;
        messageText.text = message;

        // Verificar si el zombie ha sido derrotado
        if (zombieHealth <= 0)
        {
            messageText.text = "El zombie ha sido derrotado!";
            return;
        }

        // Cambiar turno al zombie
        isZombieTurn = true;
        ToggleWolfButtons(false);
        ToggleZombieButtons(true);
    }

    void WolfTurn()
    {
        messageText.text = "Turno del Lobo";
        ToggleWolfButtons(true);
    }

    void ToggleZombieButtons(bool state)
    {
        ataqueRapidoZombieButton.interactable = state;
        mordiscoZombieButton.interactable = state;
        golpeViolentoZombieButton.interactable = state;
    }

    void ToggleWolfButtons(bool state)
    {
        ataqueRapidoLoboButton.interactable = state;
        mordidaLoboButton.interactable = state;
        rugidoLoboButton.interactable = state;
    }
}
