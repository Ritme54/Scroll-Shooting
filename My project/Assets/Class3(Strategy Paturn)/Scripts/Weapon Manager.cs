using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private ShotGunBase currentWeapon;
    [SerializeField] private ShotGunBase[] weapons;

    private void Update()
    {
        bool pressed = Input.GetMouseButtonDown(0);
        bool held = Input.GetMouseButton(0);
        bool released = Input.GetMouseButtonUp(0);

        currentWeapon?.HandlePrimaryInput(pressed, held, released);

        if (Input.GetKeyDown(KeyCode.Mouse0)) EquipByIndex(0);
        if (Input.GetKeyDown(KeyCode.Mouse0)) EquipByIndex(1);
        if (Input.GetKeyDown(KeyCode.Mouse0)) EquipByIndex(2);
    }

    public void EquipByIndex(int idx)
    {
        if (weapons == null || idx < 0 || idx >= weapons.Length) return;
        currentWeapon = weapons[idx];
        Debug.Log("ÀåÂø: " + (currentWeapon != null ? currentWeapon.name : "¾øÀ½"));
    }
}