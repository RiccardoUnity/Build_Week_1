using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class Weapon : MonoBehaviour
{
    protected int _damage; // passato a bullet
    private float _fireRange;
    protected float fireRate = 0.5f;
    protected float _lastShotTime;
    private Transform _bullets;
    [SerializeField] protected Bullet BulletPrefab;
    private Vector2 _lastMoveDirection;
    private PlayerController _playerController; 

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
            b.ShootBullet(tag, _lastMoveDirection, _damage);
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
