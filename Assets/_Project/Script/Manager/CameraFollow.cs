using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target; // Il target da seguire



    // Update is called once per frame
    void Update()
    {

        if (_target != null) // Controlla se il target è stato assegnato
        {
            Vector3 newPosition = _target.position; // Prende la posizione del target

            newPosition.z = transform.position.z; // Mantiene la stessa profondità della camera

            transform.position = newPosition; // Aggiorna la posizione della camera
        }

        else
        {
            transform.position = new Vector3(0f, 0f, transform.position.z);  // Se il target non è assegnato, imposta la posizione della camera al centro della scena
        }

    }
}
