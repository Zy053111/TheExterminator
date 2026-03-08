using UnityEngine;

public class BossSound : MonoBehaviour
{
    public AudioClip roarClip;         // звук рыка
    public AudioSource audioSource;    // источник звука на боссе
    public float minTime = 5f;         // минимальный интервал между рыками
    public float maxTime = 15f;        // максимальный интервал

    private float timer;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        ResetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            PlayRoar();
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer = Random.Range(minTime, maxTime);
    }

    void PlayRoar()
    {
        if (audioSource != null && roarClip != null)
        {
            audioSource.PlayOneShot(roarClip, 1f);
        }
    }
}