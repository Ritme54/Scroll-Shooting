using UnityEngine;

public abstract class ShotGunBase : MonoBehaviour
{
    [SerializeField] protected float fireRate = 1f; // 초당 발사 횟수
    protected float lastFireTime = -999f;

    // 기본: 자동 연사 지원 안 함. 연사 허용 무기에서 true 반환
    public virtual bool SupportsAuto => false;

    // 외부에서 호출할 인터페이스 (WeaponManager에서 호출)
    public void HandlePrimaryInput(bool pressed, bool held, bool released)
    {
        if (pressed)
        {
            TryFirePrimary();
        }
        else if (held && SupportsAuto)
        {
            if (CanFire())
            {
                lastFireTime = Time.time;
                FirePrimary();
            }
        }
    }

    protected void TryFirePrimary()
    {
        if (CanFire())
        {
            lastFireTime = Time.time;
            FirePrimary();
        }
    }

    protected bool CanFire()
    {
        if (fireRate <= 0f) return true;
        return Time.time >= lastFireTime + (1f / fireRate);
    }

    // 오직 이 메서드만 구체 클래스에서 구현하도록 강제
    protected abstract void FirePrimary();
}