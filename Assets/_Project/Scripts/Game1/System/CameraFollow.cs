using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region  Variables
    [SerializeField] GameObject target;
    [SerializeField] Vector3 distance;

    #endregion


    #region MonoBehaviour CallBacks
    void LateUpdate()
    {

        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime);
    }
    #endregion
}
