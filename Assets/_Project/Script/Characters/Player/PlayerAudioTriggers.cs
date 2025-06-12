using UnityEngine;

public class PlayerAudioTriggers : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heal"))
        {
            AudioManager.Instance.PlayHealPickupSFX();
        }

        if (other.CompareTag("Equip"))
        {
            AudioManager.Instance.PlayEquipPickupSFX();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlayHitSFX();
        }
    }
}
