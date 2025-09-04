using UnityEngine;
using UnityEngine.UI;

public class GamManager : MonoBehaviour
{
    [SerializeField] private Text timeTxt;

    private float time = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
}
