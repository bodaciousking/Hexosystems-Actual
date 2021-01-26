using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MsgDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public Image displayImage;
    public static MsgDisplay instance;
    public Color textColor;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Too many message display scripts!");
            return;
        }
        instance = this;
    }
    public void DisplayMessage(string messageText)
    {
        StopCoroutine(FadeOutRoutine());
        displayText.gameObject.SetActive(true);
        displayText.text = messageText;
        displayText.color = Color.white;
        displayText.alpha = 255;
        FadeOut();
    }

    //Fade time in seconds
    float fadeOutTime = 0.5f;
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(1f);

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            displayText.color = Color.Lerp(textColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
        displayText.gameObject.SetActive(false);

    }
    void Start()
    {
        textColor = Color.white;

        //DisplayMessage("Place Your Cities");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
