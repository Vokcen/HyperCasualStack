using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    #region Variables

    private GameObject mainCube;

   [SerializeField] private int height;

    #endregion
    #region MonoBehaviour Callbacks
    void Start()
    {
        mainCube = GameObject.FindGameObjectWithTag("MainCube");
    }
    private void Update()
    {
        mainCube.transform.position = new Vector3(mainCube.transform.position.x, height + 1, mainCube.transform.position.z);
        transform.localPosition = new Vector3(0, -height, 0);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collect") && !other.GetComponent<CollectableCube>().GetIsCollected())
        {
            height+=1;
            other.gameObject.GetComponent<CollectableCube>().MakeCollected();
            other.gameObject.GetComponent<CollectableCube>().MakeIndex(height-1);
            other.gameObject.transform.parent = mainCube.transform;

        }
    }
    #endregion

    #region Public Method

    public void LessHeight()
    {
        height--;
    }
    #endregion
}
