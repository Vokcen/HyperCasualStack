using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private float upDownSpeed;

    [SerializeField]
    private float rigtLeftSpeed;
    #endregion
    #region MonoBehaviour CallBacks
    void Start()
    {
        
    }

  
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * rigtLeftSpeed * Time.deltaTime;
        this.transform.Translate(horizontal, 0, upDownSpeed * Time.deltaTime);
    }
    #endregion
}
