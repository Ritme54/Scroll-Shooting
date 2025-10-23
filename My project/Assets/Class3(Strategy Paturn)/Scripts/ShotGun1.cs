using UnityEngine;

public class ShotGun1 : ShotGunBase
{
    protected override void FirePrimary()
    {
        Debug.Log("[ShotGun1] Primary: 단발 발사");
    }

    // 필요하다면 아래처럼 보조 메서드를 추가 (하지만 추상으로 강제하지 않음)
    public void DoSomeExtra() { /* ... */ }
}