using UnityEngine;

public class Card : MonoBehaviour
{
    int idx = 0;

    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;
    [SerializeField] private Animator anim;

    [SerializeField] private SpriteRenderer frontImg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }
}
