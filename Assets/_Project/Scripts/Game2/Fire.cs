using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    #region Variables

    [SerializeField] GameObject projectile;
 

    [SerializeField] float forcePower;
    #endregion
    #region MonoBehaviour CallBacks
    private void Awake()
    {
       
    }

  
    private void Update()
    {

        FireProjectile();
    }

    #endregion
    #region Private Regions

    private void FireProjectile()
    {
        if (Input.GetMouseButtonDown(0))
        {
           GameObject bullet= Instantiate(projectile, transform.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward *forcePower,ForceMode.Impulse);
        }
    }
    #endregion
}
