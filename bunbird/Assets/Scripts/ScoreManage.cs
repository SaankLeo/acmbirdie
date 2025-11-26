using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    public static ScoreManage instance;

    public Slider scoreSlider;
    public int currentScore = 0;
    public int maxScore = 100;

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
}
