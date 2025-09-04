using UnityEngine;

public class Card : MonoBehaviour
{
    int idx = 0;

    [SerializeField] private SpriteRenderer front;

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
        front.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
}
