using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEnemy : Enemy
{
    [SerializeField] private float _teleportInterval = 3f;
    [SerializeField] private float _teleportRange = 10f;
    [SerializeField] private float _minDistanceFromPlayer = 2f;
    [SerializeField] private float _maxDistanceFromPlayer = 10f;

    private float _nextTeleportTime;

    protected override void Start()
    {
        base.Start(); // mi serve per inizializzare il player
        _nextTeleportTime = Time.time + _teleportInterval;
    }

    private void Update()
    {
        if (Time.time >= _nextTeleportTime)
        {
            Teleport();
            _nextTeleportTime = Time.time + _teleportInterval;
        }
    }

    private void Teleport()
    {
        Vector2 newPos;
        float distanceToPlayer;
        int tryCount = 0;

        do
        {
            newPos = new Vector2(
                transform.position.x + Random.Range(-_teleportRange, _teleportRange),
                transform.position.y + Random.Range(-_teleportRange, _teleportRange)
            );

            distanceToPlayer = Vector2.Distance(newPos, Player.transform.position);
            tryCount++;

            if (tryCount > 50)
            {
                Debug.LogWarning("BlinkEnemy: impossibile trovare una posizione valida, uso l'ultima trovata.");
                break;
            }
        }
        while (distanceToPlayer < _minDistanceFromPlayer || distanceToPlayer > _maxDistanceFromPlayer);

        transform.position = newPos;
    }

    public override void EnemyMovement() { }
    public override void EnemyMovement(Vector2 _) { }
}
