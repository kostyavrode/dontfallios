using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButtons : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void StartButton()
    {
        GameManager.onGameStarted?.Invoke();
    }
    public void ShopButton()
    {
        
    }
}
