
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    [SerializeField] int count;
    [SerializeField] List<Weapon> weapons;
    [SerializeField] private GameObject FETPrefab;
    [SerializeField] private Transform muzzleTransform;

    [SerializeField] private float fallbackEffectDuration = 0.7f;

    private Coroutine disableEffectCoroutine;

    private void Start()
    {
        // ���� �ʱ�ȭ: weapons ���� �� �ʱ� Ȱ��ȭ(����)
        if (weapons == null) weapons = new List<Weapon>();
        if (weapons.Count > 0)
        {
            count = Mathf.Clamp(count, 0, weapons.Count - 1);
            for (int i = 0; i < weapons.Count; i++)
                if (weapons[i] != null)
                    weapons[i].gameObject.SetActive(i == count);
        }

        // FET�� �����Ϳ��� �Ҵ��ϼ���. (��� ������ ��ӵ�)
    }




    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          if(  Attack())
            {
                PlayEffectAtMuzzle();
            }
        

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }
    }


    private bool Attack()
    {
        if (count < 0 || count >= weapons.Count) return false;
        var w = weapons[count];
        if (w == null) return false;

        // �����ϸ� Weapon.Launch()�� bool�� �ٲ㼭 ���� �߻� ���� ���θ� ��ȯ�ϵ��� �ϸ� �� ��Ȯ�մϴ�.
        w.Launch();
        return true;
    }

    void Swap()
    {
        weapons[count].gameObject.SetActive(false);

        count = (count + 1) % weapons.Count;

        weapons[count].gameObject.SetActive(true);
    }

    private void PlayEffectAtMuzzle()
    {
        if (FETPrefab == null) return;
        var fx = Instantiate(FETPrefab, muzzleTransform.position, muzzleTransform.rotation);
        // WFX_Demo_DeleteAfterDelay�� �پ� ������ delay �� �ڵ� �ı���
    }
     

}

   