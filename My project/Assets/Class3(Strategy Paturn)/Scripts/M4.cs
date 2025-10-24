using UnityEngine;

public class M4 : Weapon
{
    public override void Launch()
    {
        Debug.Log("M4 Launch");
        Instantiate(bullet, muzzlePosition.position, transform.rotation);

    }
}