using UnityEngine;
using TMPro;
using System.Collections;

public class IntroTextController : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float fadeDuration = 1f; // врем€ дл€ fade in/out
    public float showDuration = 3f; // сколько секунд текст полностью видим

    void Start()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        introText.text = GetIntroText(sceneName);
        StartCoroutine(ShowIntroWithFade());
    }

    IEnumerator ShowIntroWithFade()
    {
        introText.gameObject.SetActive(true);

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(1f);

        // ∆дем showDuration секунд
        yield return new WaitForSeconds(showDuration);

        // Fade out
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = 1f - t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0f);
        introText.gameObject.SetActive(false);
    }

    void SetAlpha(float alpha)
    {
        Color c = introText.color;
        c.a = alpha;
        introText.color = c;
    }

    string GetIntroText(string sceneName)
    {
        switch (sceneName)
        {
            case "02_Level1":
                return "Level 1 Ч Introduction\r\n\r\nMutated creatures are swarming the area. Survive the incoming waves and use weapon pickups scattered across the map to increase your damage.\r\n\r\nDefeated enemies drop energy fragments. Collect them to fill the bar and choose one of three upgrades.\r\n\r\nStay alive until the timer runs out to reach the next area.";
            case "03_Level2_Boss":
                return "Level 2 Ч Introduction\r\n\r\nThe infection is spreading and the enemy waves are growing stronger. Keep moving, collect weapon pickups, and defeat enemies to gain upgrades, and heal yourself.\r\n\r\nAfter some time, a powerful Rat Boss will appear. Watch out for the toxic swamp pools it creates.\r\n\r\nSurvive the encounter and hold out until the timer ends.";
            default:
                return "Welcome to the level!";
        }
    }
}