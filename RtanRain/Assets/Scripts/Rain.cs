using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 5);

        if(type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if(type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        // 빨간 빗방울 만들기
        else if (type == 4)
        {
            size = 0.8f;
            score = -5;
            renderer.color = new Color(1f, 100 / 255f, 100 / 255f, 1f);
        }


        transform.localScale = new Vector3(size, size, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Rtan과 땅과의 충돌처리
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}