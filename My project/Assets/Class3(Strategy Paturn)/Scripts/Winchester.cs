using UnityEngine;

public class Winchester : Weapon
{
    public override void Launch()
    {
        Debug.Log("Winchester Lanch");
        Instantiate(bullet, muzzlePosition.position, transform.rotation);


    }
}