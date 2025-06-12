using UnityEngine;

public class TazEnemy : Enemy
{
    Vector2 _randomDirection;
    [SerializeField] private float _timeToChangeDirection;
    private float _lastChangeDirection;

    private void Start()
    {
        _randomDirection = RandomDirection(); // iniziale
        _lastChangeDirection = Time.time + _timeToChangeDirection;
    }


    private void FixedUpdate()
    {

        if (Time.time >= _lastChangeDirection)
        {
            _lastChangeDirection = Time.time + _timeToChangeDirection;
            _randomDirection = RandomDirection(); // cambia direzione solo ogni x secondi
        }

        EnemyMovement(_randomDirection); // muovi sempre nella direzione attuale

    }

    private Vector2 RandomDirection()
    {

        Vector2 _randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return _randomDirection;

    }
}
