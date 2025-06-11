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

    [SerializeField] Bullet _bulletPrefab;
    public Bullet BulletPrefab => _bulletPrefab;

    [SerializeField] float FollowRange = 10f;

    void Awake()
    {

        _lifeController = GetComponent<LifeController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player = FindAnyObjectByType<PlayerController>();
    }

    void FixedUpdate() 
    { 

       

    }


    public virtual bool CheckPlayerInRange()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < FollowRange)
        {
            return true;
        }

        return false;
    }


    public virtual bool CheckPlayerInRange(out Vector2 playerDirection)
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < FollowRange)
        {
            playerDirection = _player.transform.position - transform.position;
            return true;
        }

        playerDirection = Vector2.zero;
        return false;
    }

    virtual public void EnemyMovement()
    {
        if (_dir != Vector2.zero)
        {
            _rb.MovePosition(_rb.position + Dir * (_speed * Time.fixedDeltaTime));
        }
    }

    virtual public void EnemyMovement(Vector2 _dir)
    {
        if (_dir != Vector2.zero)
        {

            _rb.MovePosition(_rb.position + _dir * (_speed * Time.fixedDeltaTime));

        }
    }


    virtual public void EnemyAttack()
    {

    }

    public void Setdirection(Vector2 dir)
    {
        float sqrLenght = dir.sqrMagnitude;
        if (sqrLenght > 1)
        {
            dir = dir / Mathf.Sqrt(sqrLenght);
        }

        _dir = dir;
    }

}
