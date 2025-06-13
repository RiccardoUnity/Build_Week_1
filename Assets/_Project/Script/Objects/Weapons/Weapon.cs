using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int Damage = 10; // passato a bullet
    private float _fireRange;
    protected float fireRate = 0.5f;
    protected float _lastShotTime;
    private Transform _bullets;
    [SerializeField] protected Bullet BulletPrefab;
    protected Vector2 _lastMoveDirection = Vector2.right;
    protected PlayerController _playerController; 

    public void UpdateDirection(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            _lastMoveDirection = moveDirection;
        }
    }

    public virtual void Shoot()
    {
        if (Time.time - _lastShotTime > fireRate)
        {
            _lastShotTime = Time.time;
            Bullet b = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            b.ShootBullet(tag, _lastMoveDirection, Damage);
        }
    }

    void Start()
    {
        _playerController = GSU.Player.GetComponent<PlayerController>();
        
    }

    void Update()
    {
        UpdateDirection(_playerController.Dir);
        Shoot();
    }
}
