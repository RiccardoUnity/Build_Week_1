using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class Enemy : MonoBehaviour
{
    public Movement _movement { get; private set; }
    public LifeController _lifeController { get; set; }
    public PlayerController _player { get; private set; }

    [SerializeField] Bullet _bulletPrefab;

    [SerializeField] float _followRange = 10f;

    void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>();
        _movement = GetComponent<Movement>();
        _lifeController = GetComponent<LifeController>();
    }

    void FixedUpdate()
    {
        if (CheckPlayerInRange()) { EnemyMovement(); }
    }


    public bool CheckPlayerInRange()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _followRange)
        {
            return true;
        }

        return false;
    }

    virtual public void EnemyMovement()
    {

    }

    virtual public void EnemyAttack()
    {
    }

    //virtual public void EnemyDeath()
    //{
        
    //}

}
