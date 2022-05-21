using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    #region Variables

    public float upDownSpeed;

    [SerializeField]
    private float rigtLeftSpeed;
    #endregion
    #region MonoBehaviour CallBacks



    void Update()
    {
        if (GameManager.instance.state == GameManager.State.game)
        {
            Move();
        }


    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * rigtLeftSpeed * Time.deltaTime;
        this.transform.Translate(horizontal, 0, upDownSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speed"))
        {
            if (upDownSpeed == 10)
            {
                upDownSpeed = 15;
            }
            else
            {
                upDownSpeed = 10;
            }


        }
    }
    #endregion
}
