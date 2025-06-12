using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class Bullet : MonoBehaviour
{
    private string _originTag;             // chi spara 
    [SerializeField] private float _speed = 5f;             // Velocità proiettile
    [SerializeField] private float _lifeTime = 5f;           // Durata prima che si autodistrugga
    private int _damage = 1;                // Danno inflitto

    private Rigidbody2D _rb2D;

    //Chiamato quando viene istanziato
    public void ShootBullet(string originTag, Vector2 force, int damage)
    {
        _originTag = originTag;
        _damage = damage;
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.AddForce(force * _speed, ForceMode2D.Impulse);
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime); // Dopo lifeTime secondi si autodistrugge
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeController lifeController = GetComponent<LifeController>();
        if (lifeController != null)
        {
            //Enemy spara al Player o Player spara ad Enemy
            if ((other.CompareTag(GSU.EnemyTag) && _originTag == GSU.PlayerTag) || (other.CompareTag(GSU.PlayerTag) && _originTag == GSU.EnemyTag))
            {
                lifeController.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
