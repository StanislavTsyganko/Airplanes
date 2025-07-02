using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

// Класс для взрыва
public class Explosion : MonoBehaviour
{

    public AudioClip explosionSound;  // Звук взрыва
    private AudioSource audioSource;  // Источник звук

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Инициализируем AudioSource
    }
    public virtual void Explode(Vector3 position)
    {
        // Создаем эффект взрыва

        // Воспроизводим звук взрыва
        if (audioSource != null && explosionSound != null)
        {
            audioSource.volume = 1.0f;  // Устанавливаем громкость на 100%

            audioSource.PlayOneShot(explosionSound);  // Воспроизведение звука взрыва
        }
        GameObject explosion = Instantiate(Resources.Load<GameObject>("explode1"), position, Quaternion.identity);
    }
}