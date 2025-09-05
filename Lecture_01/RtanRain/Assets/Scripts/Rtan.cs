using UnityEngine;

public class Rtan : MonoBehaviour
{
    float direction = 0.05f;

    SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        if (transform.position.x > 2.6f)
        {
            renderer.flipX = true;
            direction = -0.05f;
        }
        if (transform.position.x < -2.6f)
        {
            renderer.flipX = false;
            direction = 0.05f;
        }

        transform.position += Vector3.right * direction;
    }
}
