using UnityEngine;
using TMPro;
using System.Collections;

public class IntroTextController : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float showTime = 4f;

    void Start()
    {
        StartCoroutine(ShowIntro());
    }

    IEnumerator ShowIntro()
    {
        introText.gameObject.SetActive(true);
        yield return new WaitForSeconds(showTime);
        introText.gameObject.SetActive(false);
    }
}