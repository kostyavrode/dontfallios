using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartText : MonoBehaviour
{
    public string text1;
    private string text2= "Great, do you know what to do? No? Then I'll tell you!";
    private string text3= "You need to accumulate enough gems to ransom all my friends from captivity. I hope you can make it. Good luck!";
    public TMP_Text textBar;
    public GameObject nextButton;
    public GameObject ssPanel;
    private int query;
    private bool isCanInteract;
    public void Start()
    {
        if (!PlayerPrefs.HasKey("start"))
        {
            ssPanel.SetActive(true);
            StartCoroutine(TextAllign(text1));
            query = 1 ;
            Debug.Log("query=" + query);
        }
    }
    private IEnumerator TextAllign(string tempText)
    {
        textBar.text = "";
        for (int i=0;i<tempText.Length;i++)
        {
            textBar.text += tempText[i];
            yield return new WaitForSeconds(0.03f);
        }
        nextButton.SetActive(true);
        tempText = "";
    }
    private IEnumerator TextAllign2()
    {
        string TText = "Great, do you know what to do? No? Then I'll tell you!";
        textBar.text = "";
        for (int i = 0; i < TText.Length; i++)
        {
            textBar.text += TText[i];
            yield return new WaitForSeconds(0.03f);
        }
        isCanInteract = true;
        nextButton.SetActive(true);
        
    }
    public void NextButton()
    {
        if (query == 1)
        {
            nextButton.SetActive(false);
            StartCoroutine(TextAllign2());
            query = 2;
            Debug.Log("query=" + query);
        }
        if (query == 2 && isCanInteract)
        {
            PlayerPrefs.SetString("start", "true");
            nextButton.SetActive(false);
            StartCoroutine(TextAllign(text3));
            query=3;
            Debug.Log("query=" + query);
        }
        else if (query>2)
        {
            Debug.Log("query=" + query);
            ssPanel.SetActive(false);
        }
    }
}
