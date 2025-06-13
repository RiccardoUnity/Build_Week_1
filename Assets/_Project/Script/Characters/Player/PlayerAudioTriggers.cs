using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class PlayerAudioTriggers : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heal"))
        {
            AudioManager.Instance.PlayHealPickupSFX();
        }

        if (other.CompareTag(GSU.PickUpTag))
        {
            AudioManager.Instance.PlayEquipPickupSFX();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GSU.EnemyTag))
        {
            AudioManager.Instance.PlayHitSFX();
        }
    }
}
