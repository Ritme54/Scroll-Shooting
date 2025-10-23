using UnityEngine;

public abstract class ShotGunBase : MonoBehaviour
{
    [SerializeField] protected float fireRate = 1f; // �ʴ� �߻� Ƚ��
    protected float lastFireTime = -999f;

    // �⺻: �ڵ� ���� ���� �� ��. ���� ��� ���⿡�� true ��ȯ
    public virtual bool SupportsAuto => false;

    // �ܺο��� ȣ���� �������̽� (WeaponManager���� ȣ��)
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

    // ���� �� �޼��常 ��ü Ŭ�������� �����ϵ��� ����
    protected abstract void FirePrimary();
}