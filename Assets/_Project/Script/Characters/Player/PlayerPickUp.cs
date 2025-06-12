using GameUtility;
using System;
using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform _weapons;   //Padre di tutte le armi in Player
    [SerializeField] private Weapon[] _weaponsAsset;

    void OnValidate()
    {
        Array.Resize<Weapon>(ref _weaponsAsset, Enum.GetValues(typeof(PickUpType)).Length - 1);
    }

    void Awake()
    {
        //Setto una volta per tutte il Player della scena in GSU
        GSU.Player = this.transform;

        //Controllo che non ci siano referenze null in _weaponsAsset
        foreach (Weapon weapon in _weaponsAsset)
        {
            if (weapon == null)
            {
                Debug.LogError("Mancano referenze per le weapon nel Player!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D pickUpCollider)
    {
        if (_weaponsAsset.Length > 0 && pickUpCollider.CompareTag(GSU.PickUpTag))
        {
            PickUp pickUp = pickUpCollider.GetComponent<PickUp>();
            PickUpType type = pickUp.GetPickUpType();

            if (type != PickUpType.None)
            {
                Instantiate(_weaponsAsset[(int)pickUp.GetPickUpType() - 1], _weapons);
            }

            Destroy(pickUp.gameObject);
        }
    }
}
