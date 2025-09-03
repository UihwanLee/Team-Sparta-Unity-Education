using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject rain;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1.0f);
    }

    public void MakeRain()
    {
        // 비 생성기
        Instantiate(rain);
    }
}
