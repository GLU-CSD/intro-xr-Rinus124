using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameActive = true;
    private int score = 0;
    private float scoreTimer = 0f;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject gameOverUI;

    void Update()
    {
        if (gameActive)
        {
            scoreTimer += Time.deltaTime;
            scoreText.text = "Score: " + score;

            if (scoreTimer >= 1f)
            {
                score++;
                scoreTimer = 0f;
            }
        }
    }

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Debug.Log("ending game");
        gameActive = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
        }


        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

