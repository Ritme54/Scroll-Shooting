using UnityEngine;

public class ShotGun2 : ShotGunBase
{
    public override bool SupportsAuto => true; // 연사 허용

    protected override void FirePrimary()
    {
        Debug.Log("[ShotGun2] Primary: 단발/연사 발사");
    }
}