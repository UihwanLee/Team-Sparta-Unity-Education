using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private GameObject food;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f);
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;

        if(x > 8.5f)
        {
            x = 8.5f;
        }
        if(x < -8.5f)
        {
            x = -8.5f;
        }

        transform.position = new Vector2(x, transform.position.y);
    }

    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;
        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
