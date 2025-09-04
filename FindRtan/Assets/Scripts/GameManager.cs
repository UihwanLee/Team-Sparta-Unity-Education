using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    [SerializeField] private Text timeTxt;
    [SerializeField] private GameObject endTxt;

    public int cardCount = 0;

    private float time = 30.0f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if(time <= 0)
        {
            EndGame();
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                EndGame();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    public void EndGame()
    {
        Time.timeScale = 0.0f;
        endTxt.SetActive(true);
    }
}
