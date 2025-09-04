using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    [SerializeField] private GameObject normalCat;
    [SerializeField] private GameObject retryBtn;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeCat()
    {
        Instantiate(normalCat);
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
