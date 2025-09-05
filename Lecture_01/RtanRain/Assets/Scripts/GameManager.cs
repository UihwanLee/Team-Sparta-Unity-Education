using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject rain;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text totalScoreTxt;
    [SerializeField] private Text timeTxt;

    private int totalScore;
    private float totalTime = 30.0f;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1.0f);
        endPanel.SetActive(false);
    }

    private void Update()
    {
        if(totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0f;
            endPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        timeTxt.text = totalTime.ToString("N2");
    }

    public void MakeRain()
    {
        // 비 생성기
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }
}
