using Unity.VisualScripting;
using UnityEngine;

public class Robots : MonoBehaviour
{
    public float speed = 5f;         // ���� �̵� �ӵ� (Inspector ���� ����)
    public float lifetime = 10f;     // �ڵ� ����(����)

    private void Start()
    {
        // �ʿ��ϸ� ���� �� �ڵ� ����
        if (lifetime > 0f)
            Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // �� ������ �� �������� �̵� (Transform ���)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // �Ǵ� ���� �� �������� �̵��Ϸ���: transform.position += transform.forward * speed * Time.deltaTime;
    }
}
