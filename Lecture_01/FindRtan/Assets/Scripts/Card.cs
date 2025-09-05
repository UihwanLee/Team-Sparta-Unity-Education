using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;

    [SerializeField] private Animator anim;

    private AudioSource audioSource;
    public AudioClip clip;

    [SerializeField] private SpriteRenderer frontImg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImg.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if(GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);  // 오디오 소스 겹치지 않음

        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if(GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }

    public void DestoryCard()
    {
        Invoke("DestoryCardInvoke", 1.0f);
    }

    public void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
