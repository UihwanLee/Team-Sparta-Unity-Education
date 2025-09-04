using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private GameObject hungryCat;
    [SerializeField] private GameObject fullCat;

    [SerializeField] private RectTransform front;

    private float full = 5.0f;
    private float energy = 0.0f;
    private float speed = 0.05f;

    public int type;

    private bool isFull = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector3(x, y, 0);

        if(type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if(type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(energy <full)
        {
            transform.position += Vector3.down * speed;

            if(transform.position.y < -16.0f)
            {
                GameManger.Instance.GameOver();
            }
        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                Destroy(collision.gameObject);
                if(energy == full)
                {
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManger.Instance.AddScore();
                    }     
                }
            }
        }
    }
}
