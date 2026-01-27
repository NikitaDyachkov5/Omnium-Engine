using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField] 
    private Text centerText;

    private Coroutine currentMessageCoroutine;

    public void ShowCenterMessage(string message, float delay = 0f)
    {
        centerText.text = message;
        centerText.gameObject.SetActive(true);

        if(currentMessageCoroutine != null)
            StopCoroutine(currentMessageCoroutine);

        if(delay > 0f)
            currentMessageCoroutine = StartCoroutine(HideCenterAfterDelay(delay));
    }

    public void HideCenterMessage()
    {
        if (currentMessageCoroutine != null)
            StopCoroutine(currentMessageCoroutine);

        centerText.gameObject.SetActive(false);
    }

    private IEnumerator HideCenterAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        centerText.gameObject.SetActive(false);
        currentMessageCoroutine = null;
    }

    public void ShowScore(int score)
    {
        scoreText.text = $"Score {score}";
    }

}
