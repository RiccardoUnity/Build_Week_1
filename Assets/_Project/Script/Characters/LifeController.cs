using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class LifeController : MonoBehaviour
{
    public int Hp { get; private set; }

    [SerializeField] private int _maxHp = 100;
    [SerializeField] private float _advisorTime = 0.2f;

    [SerializeField] PickUp prefabPickUp;

    private float _timer = 0;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        Hp = _maxHp;

        _renderer = GetComponentInChildren<SpriteRenderer>();

    }

    void Update()
    {

        if (_renderer == null) return;


        if (_timer > 0)
        {

            _timer -= Time.deltaTime;

        }

        else if (_renderer.color != Color.white)

        {

            _renderer.color = Color.white;

        }


    }


    public void TakeDamage(int damage)
    {
        damage = Mathf.Abs(damage);
        Hp = Mathf.Max(0, Hp - damage);

        if (Hp == 0)
        {
            if (tag.Equals(GSU.PlayerTag))
                GSU.ReloadScene();
            else
                DropObject(); 

            Destroy(gameObject, 0.1f);
        }

        FlashColor(Color.red); // lampeggia di rosso quando subisce danni

        if (tag.Equals(GSU.PlayerTag))
        {
            Debug.Log($"La vita attuale del giocatore {gameObject.name} è pari a {Hp}");
        }
    }

    public void AddHp(int healAmount)
    {
        healAmount = Mathf.Abs(healAmount); // sicurezza: valore positivo
        Hp = Mathf.Min(Hp + healAmount, _maxHp); // limite massimo

        FlashColor(Color.green); // lampeggia di verde quando guarisce

        Debug.Log($"La vita attuale di {gameObject.name} è {Hp}");
    }

    private void FlashColor(Color color)
    {
        if (_renderer != null)
        {
            _renderer.color = color;
            _timer = _advisorTime;
        }
    }

    public void DropObject()
    {

            int i = Random.Range(0, 100);
            if (i <= 15)
            {
                Instantiate(prefabPickUp, transform.position, Quaternion.identity);
            }

    }
}
