using System;
using UnityEngine;
using GameUtility;
using GSU = GameUtility.GameStaticUtility;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CircleCollider2D))]
public class PickUp : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D;

    private PickUpType _type = PickUpType.None;

    void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        tag = GSU.PickUpTag;

        _type = (PickUpType)Random.Range(1, Enum.GetValues(typeof(PickUpType)).Length);
    }

    public PickUpType GetPickUpType() => _type;
}
