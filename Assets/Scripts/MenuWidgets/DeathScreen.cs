using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Button focusedButton;
    public float fadeInSpeed;
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerEvents.OnPlayerDeath += OnGameOver;
        this.enabled = false;
    }


    void OnGameOver()
    {
        this.enabled = true;
        focusedButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasGroup.alpha < 1)
            canvasGroup.alpha += Time.deltaTime * fadeInSpeed;
    }

    public void OnReloadSave()
    {
        PersistantSaveInfo.ShouldLoadLevel = true;
        SceneManager.LoadScene("GameScene");
    }

    public void OnRestartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void OnDestroy()
    {
        PlayerEvents.OnPlayerDeath -= OnGameOver;
    }
}
