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
    Color textColor;

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
        displayText.text = messageText;
        displayText.color = textColor;
        FadeOut();
    }

    //Fade time in seconds
    public float fadeOutTime = 3;
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            displayText.color = Color.Lerp(textColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }
    void Start()
    {
        textColor = displayText.color;

        DisplayMessage("Place Your Cities");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
