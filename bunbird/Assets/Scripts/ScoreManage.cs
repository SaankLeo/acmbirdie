using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
public class ScoreManage : MonoBehaviour
{
    public static ScoreManage instance;

    public Slider scoreSlider;
    public int currentScore = 0;
    public int maxScore = 100;

    public GameObject playerSamosa;
    public Transform instantiatePoint;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("ScoreManage is alive!");

        scoreSlider.minValue = 0;
        scoreSlider.maxValue = maxScore;
        scoreSlider.value = 0;
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        scoreSlider.value = currentScore;

        Debug.Log("Score now = " + currentScore);
    }

    private void Update()
    {
        if (currentScore >= maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
        Debug.Log("game is over");
    }

    public void InstantiatePlayer()
    {
        Instantiate(playerSamosa, instantiatePoint.position, instantiatePoint.rotation);
        Debug.Log("aslkdfjsdkl");
    }
}
