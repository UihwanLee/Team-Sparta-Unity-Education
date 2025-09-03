using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject endPannel;
    [SerializeField] private GameObject square;
    [SerializeField] private Text timeTxt;
    [SerializeField] private Text nowScore;

    bool isPlay = true;

    float time = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0f, 1f);   
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    public void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        Time.timeScale = 0.0f;
        nowScore.text = time.ToString("N2");
        endPannel.SetActive(true);
    }
}
