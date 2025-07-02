using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

// ����� ��� ������
public class Explosion : MonoBehaviour
{

    public AudioClip explosionSound;  // ���� ������
    private AudioSource audioSource;  // �������� ����

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // �������������� AudioSource
    }
    public virtual void Explode(Vector3 position)
    {
        // ������� ������ ������

        // ������������� ���� ������
        if (audioSource != null && explosionSound != null)
        {
            audioSource.volume = 1.0f;  // ������������� ��������� �� 100%

            audioSource.PlayOneShot(explosionSound);  // ��������������� ����� ������
        }
        GameObject explosion = Instantiate(Resources.Load<GameObject>("explode1"), position, Quaternion.identity);
    }
}