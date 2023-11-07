using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public UniWebView uniWebView;
    public static UIController instance;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TMP_Text bestScoreBar;
    [SerializeField] private TMP_Text moneyBar;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private TMP_Text scoreBar;
    [SerializeField] public GameObject shopPanel;
    public static Action onScoreChange;
    private int currentScore;

    public GameObject StartPanel
    {
        get { return startPanel; }
        set { startPanel=value; }
    }

    private void Awake()
    {
        instance = this;
        PlayerController.onPlayerDeath += CheckBestScore;
        onScoreChange += ChangeScore;
        moneyBar.text = PlayerPrefs.GetInt("money",0).ToString();
    }
    public void UpdateMoney(int temp)
    {
        PlayerPrefs.SetInt("money", temp);
        PlayerPrefs.Save();
        moneyBar.text = temp.ToString();
    }
    private void OnDisable()
    {
        PlayerController.onPlayerDeath -= CheckBestScore;
        onScoreChange -= ChangeScore;
    }
    private void ChangeScore()
    {
        currentScore++;
        scoreBar.text =currentScore.ToString();
    }
    private void CheckBestScore()
    {
        deathPanel.SetActive(true);
        if (currentScore>PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("BestScore"));
        }
        bestScoreBar.text = "Best Score " + PlayerPrefs.GetInt("BestScore");
    }
    public void OpenShop()
    {
        CameraController.instance.MoveCameraToShop();
        shopPanel.SetActive(true);
        startPanel.SetActive(false);
    }
    public void CloseShop()
    {
        CameraController.instance.MoveCameraToStart();
        shopPanel.SetActive(false);
        startPanel.SetActive(true);
    }
    public void OpenWebview(string url)
    {
        var webviewObject = new GameObject("UniWebview");
        uniWebView = webviewObject.AddComponent<UniWebView>();
        uniWebView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        uniWebView.SetShowToolbar(true, false, true, true);
        uniWebView.Load(url);
        uniWebView.Show();
    }
}
