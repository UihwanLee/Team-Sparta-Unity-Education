using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         float x = Random.Range(-3.0f, 3.0f);
         float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector2(x, y);

        float size = Random.Range(-0.5f, 1.5f);

        transform.localScale = new Vector2(size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
