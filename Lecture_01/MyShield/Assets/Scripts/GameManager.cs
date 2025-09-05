using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject endPannel;
    [SerializeField] private GameObject square;
    [SerializeField] private Text timeTxt;
    [SerializeField] private Text nowScore;
    [SerializeField] private Text bestScore;

    [SerializeField] private Animator anim;

    bool isPlay = true;

    float time = 0.0f;

    string key = "bestScore";

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
        anim.SetBool("isDie", true);

        Invoke("TimeStop", 0.5f);

        nowScore.text = time.ToString("N2");

        if(PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if(best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString();
        }


        endPannel.SetActive(true);
    }

    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
