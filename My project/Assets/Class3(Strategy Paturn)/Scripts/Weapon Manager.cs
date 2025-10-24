
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
        // 안전 초기화: weapons 보정 및 초기 활성화(선택)
        if (weapons == null) weapons = new List<Weapon>();
        if (weapons.Count > 0)
        {
            count = Mathf.Clamp(count, 0, weapons.Count - 1);
            for (int i = 0; i < weapons.Count; i++)
                if (weapons[i] != null)
                    weapons[i].gameObject.SetActive(i == count);
        }

        // FET는 에디터에서 할당하세요. (없어도 동작은 계속됨)
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

        // 가능하면 Weapon.Launch()를 bool로 바꿔서 실제 발사 성공 여부를 반환하도록 하면 더 정확합니다.
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
        // WFX_Demo_DeleteAfterDelay가 붙어 있으면 delay 후 자동 파괴됨
    }
     

}

   