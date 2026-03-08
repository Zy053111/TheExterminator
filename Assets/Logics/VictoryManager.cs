using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryPanel;

    public AudioClip victoryClip;       // звук победы
    public AudioSource audioSource;     // источник звука, можно на этом же объекте

    public void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
            PlayVictorySound();
        }
    }
    void PlayVictorySound()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource != null && victoryClip != null)
        {
            audioSource.PlayOneShot(victoryClip, 1f);
        }
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        GameFlowManager.Instance.BackToMenu();
    }
}