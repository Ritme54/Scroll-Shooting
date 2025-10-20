using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Golem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float a = 1f;
        float lenght = 1f;

        float x = Mathf.PingPong(Time.time*a, lenght);
        transform.localScale = new Vector3(x,x,x); 

        
        
        
    }
}
