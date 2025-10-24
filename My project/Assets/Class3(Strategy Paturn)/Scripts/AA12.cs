using UnityEngine;

public class AA12 : Weapon
{
    public override void Launch()
    {
        Debug.Log("AA12 Launch");
        Instantiate(bullet, muzzlePosition.position, transform.rotation);

    }
}