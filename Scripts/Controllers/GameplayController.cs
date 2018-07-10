using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    //instance variables.
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Text scoreText, pauseText;

    private int score;

    // Use this for initialization
    void Start()
    {
        //Reason why it doesn't follow documented design structure is because of personal opinion (added 'M' feels tacky).
        scoreText.text = "" + score;
        StartCoroutine(CountScore());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.6f);

        score++;
        //Reason why it doesn't follow documented design structure is because of personal opinion (added 'M' feels tacky).
        scoreText.text = "" + score;
        StartCoroutine(CountScore());//Faster performance if we do countScore as Coroutine than have it stuck on update.
    }

    private void OnEnable()
    {//Calls endGame event from PlayerDeath script to instantiate.
        PlayerDeath.endGame += PlayerDiedEndGame;
    }

    private void OnDisable()
    {//Calls endGame event from PlayerDeath script to disable.
        PlayerDeath.endGame -= PlayerDiedEndGame;
    }

    void PlayerDiedEndGame()
    {//Treated as delegate to PlayerDeath Script.
        if (!(PlayerPrefs.HasKey("Score")))
        {//Sets up score on first run of game.
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {//Check if we've beaten our high score. If so, update to new one.
            int hiScore = PlayerPrefs.GetInt("Score");
            if (hiScore < score)
            {
                PlayerPrefs.SetInt("Score", score);
            }
        }

        //Saves memory if we re-use and re-purpose assets.
        pauseText.text = "GAME OVER";
        pausePanel.SetActive(true);
        //Re-purposes Resume Button to Restart the Game.
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => RestartGame());

        Time.timeScale = 0f;//Stops Game Clock since player died.
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;//Stops Game Clock since game is paused.
        pausePanel.SetActive(true);
        //Re-purposes Resume Button to Resume the Game.
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => ResumeGame());
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;//Need to set it back to 1 if we go back to main menu and restart the game.
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;//Restarts Game Clock and Game proper.
        SceneManager.LoadScene("Gameplay");
    }
}
