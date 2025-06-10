using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int hp { get; private set; }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Abs(damage);
        hp = Mathf.Max(0, hp - damage);
        if (hp == 0)
        {
            Debug.Log($"Il giocatore {gameObject.name} è stato sconfitto");
            Destroy(gameObject);
        }
        Debug.Log($"La vita attuale del giocatore {gameObject.name} è pari a {Mathf.Max(0, hp)}");
    }
}
