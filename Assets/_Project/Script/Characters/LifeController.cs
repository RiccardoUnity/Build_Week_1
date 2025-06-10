using UnityEngine;
using UnityEngine.Rendering;

public class LifeController : MonoBehaviour
{
    [SerializeField] public int Hp { get; private set; }

    [SerializeField] private int _maxHp = 100;
    public int MaxHp => _maxHp;

    private void Start()
    {
        Hp = _maxHp;

    }


    public void TakeDamage(int damage)
    {
        damage = Mathf.Abs(damage);
        Hp = Mathf.Max(0, Hp - damage);

        if (Hp == 0)
        {
            Debug.Log($"Il giocatore {gameObject.name} è stato sconfitto");
            Destroy(gameObject);
        }
        Debug.Log($"La vita attuale del giocatore {gameObject.name} è pari a {Mathf.Max(0, Hp)}");
    }
}
