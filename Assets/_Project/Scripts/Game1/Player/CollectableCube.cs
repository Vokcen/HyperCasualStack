using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{

    #region Variables
    private bool isCollected;
    private int index;
    Collector _collector;
    [SerializeField] Movement movement;


    #endregion
    #region Monobehaviour CallBacks
    void Start()
    {
        _collector = GameObject.FindGameObjectWithTag("Collector").GetComponent<Collector>();
        isCollected = false;
    }

    private void Update()
    {
        if (transform.parent != null && isCollected)// E�er objenin parent objesi bo�(null)de�il ise ve isCollected==True ise �al���r
        {
            transform.localPosition = new Vector3(0, -index, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _collector.LessHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
        }
    

    }

    #endregion
    #region Public Methods
    public bool GetIsCollected()
    {
        return isCollected;
    }

    public void MakeCollected()
    {
        isCollected = true;
    }
    public void MakeIndex(int index)
    {
        this.index = index;
    }
    #endregion
}
