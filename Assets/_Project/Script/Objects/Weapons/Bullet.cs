using UnityEngine;

public class Bullet : MonoBehaviour
{
    private string _originTag;             // chi spara 
    [SerializeField] private float _speed = 10f;             // Velocità proiettile
    [SerializeField] private float _lifeTime = 5f;           // Durata prima che si autodistrugga
    private int _damage = 1;                // Danno inflitto
    [SerializeField] private string _enemyTag = "Enemy";     // Il tag che identifica il bersaglio
    [SerializeField] private string _playerTag = "Player";   // Il tag che identifica il player

    private Rigidbody2D _rb2D;
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime); // Dopo lifeTime secondi si autodistrugge
    }

    public void ShootBullet (string origin, Vector2 force, int damage)
    {
        _originTag = origin;
        _damage = damage;
        _rb2D.AddForce(force * _speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeController lifeController = GetComponent<LifeController>();
        if (lifeController != null)
        {
            //Enemy spara al Player o Player spara ad Enemy
            if ((other.CompareTag(_enemyTag) && _originTag == _playerTag) || (other.CompareTag(_playerTag) && _originTag == _enemyTag))
            {
                lifeController.TakeDamage(_damage);
            }
        }

        Destroy(gameObject); // Distrugge il proiettile
    }
}
