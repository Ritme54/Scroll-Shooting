using UnityEngine;

public class Bat : MonoBehaviour
{

    [SerializeField] float lenght;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float a = 2f;        

        float x = Mathf.PingPong(Time.time * a, lenght)-1;
        //float A = x - 1;
        transform.position = new Vector3(transform.position.x, x, transform.position.z);

    }
}
