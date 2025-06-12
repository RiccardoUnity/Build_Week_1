using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private int _healAmount = 1; // Di quanto curare il personaggio quando entra in contatto con l'oggetto Healer

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return; // Controllo se l'oggetto con cui collido ha il tag "Player"

        if (collision.gameObject.CompareTag("Player"))
        {
            LifeController player = collision.gameObject.GetComponent<LifeController>();
            if (player != null)
            {
                player.AddHp(_healAmount); //Uso il metodo AddHp del LifeController per curare il personaggio
                Debug.Log($"Il personaggio ha ricevuto {_healAmount} punti vita!");
                Destroy(gameObject); // Distrogg l'oggetto Healer dopo aver curato il personaggio
            }
        }
    }
}
