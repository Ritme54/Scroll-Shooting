using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField] public GameObject robotPrefab; // �ν����Ϳ��� �Ҵ�
    [SerializeField] Transform robotTransform;
    [SerializeField] WaitForSeconds waitForSeconds;

    void Start()
    {

        StartCoroutine(Create());

    }
    private IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 6));
            Instantiate(robotPrefab);
        }

    }


}