using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    [SerializeField] private GameObject normalCat;
    [SerializeField] private GameObject fatCat;
    [SerializeField] private GameObject pirateCat;

    [SerializeField] private GameObject retryBtn;

    [SerializeField] private RectTransform levelFront;
    [SerializeField] private Text levelTxt;

    private int level = 0;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1.0f);
    }

    private void MakeCat()
    {
        Instantiate(normalCat);

        if(level == 1)
        {
            int p = Random.Range(0, 10);
            if(p < 2) Instantiate(normalCat);
        }
        else if(level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if(level == 3)
        {
            Instantiate(fatCat);
        }
        else if(level >= 4)
        {
            Instantiate(pirateCat);
        }
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
