using UnityEngine;

public class BulletManager : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float destroyTime;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed*Time.deltaTime);
      
        
        
    }


   
}
