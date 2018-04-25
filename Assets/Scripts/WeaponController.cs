using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject AmmoPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(AmmoPrefab, Muzzle.transform.position, Muzzle.transform.rotation);
        }
    }
}
