using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] float _speed = 2;

    Vector2 _dir;
    Vector2 Dir => _dir.normalized;

    public LifeController _lifeController { get; set; }
    public PlayerController _player { get; private set; }

    Rigidbody2D _rb;
    [SerializeField] int _dmg;
    public int Dmg => _dmg;

    //[SerializeField] Bullet _bulletPrefab;
    //public Bullet BulletPrefab => _bulletPrefab;

    [SerializeField] float FollowRange = 10f;

    void Awake()
    {

        _lifeController = GetComponent<LifeController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        _player = GameUtility.GameStaticUtility.Player.GetComponent<PlayerController>();
    }


    public virtual bool CheckPlayerInRange()
    {
        if (_player == null) return false;
        float sqrDistance = (_player.transform.position - transform.position).sqrMagnitude;
        return sqrDistance < FollowRange * FollowRange;
    }

    public virtual bool CheckPlayerInRange(out Vector2 playerDirection)
    {
        if (_player == null)
        {
            playerDirection = Vector2.zero;
            return false;
        }

        playerDirection = _player.transform.position - transform.position;
        return playerDirection.sqrMagnitude < FollowRange * FollowRange;
    }
    virtual public void EnemyMovement()
    {
        if (_rb == null) return;
        if (_dir != Vector2.zero)
        {
            _rb.MovePosition(_rb.position + Dir * (_speed * Time.fixedDeltaTime));
        }


    }

    virtual public void EnemyMovement(Vector2 _dir)
    {
        if (_rb == null)
        {
            return;
        }

        if (_dir != Vector2.zero)
        {

            _rb.MovePosition(_rb.position + _dir.normalized * (_speed * Time.fixedDeltaTime));

        }
    }


    virtual public void EnemyAttack()
    {

    }

    public void Setdirection(Vector2 dir)
    {
        _dir = dir.normalized;
    }

    void OnDestroy()
    {
        GameUtility.GameStaticUtility.RemoveEnemy(this);
    }

}
