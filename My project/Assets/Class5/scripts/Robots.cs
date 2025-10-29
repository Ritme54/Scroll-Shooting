using Unity.VisualScripting;
using UnityEngine;

public class Robots : MonoBehaviour
{
    public float speed = 5f;         // 전방 이동 속도 (Inspector 편집 가능)
    public float lifetime = 10f;     // 자동 삭제(선택)

    private void Start()
    {
        // 필요하면 수명 후 자동 제거
        if (lifetime > 0f)
            Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // 매 프레임 앞 방향으로 이동 (Transform 기반)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // 또는 월드 축 기준으로 이동하려면: transform.position += transform.forward * speed * Time.deltaTime;
    }
}
