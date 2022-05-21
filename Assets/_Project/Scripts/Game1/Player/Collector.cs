using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    #region Variables

    private GameObject mainCube;
    public int score = 1;
    [SerializeField] private int height;

bool isState=false;

    #endregion
    #region MonoBehaviour Callbacks
    void Start()
    {
        mainCube = GameObject.FindGameObjectWithTag("MainCube");
       
       
    }
    private void Update()
    {
        Transforms();

        GameOver();
    }

    private void GameOver()
    {
        if (score <= 0 && !isState)
        {
            AudioManager.instance.lose.Play();
            GameManager.instance.state = GameManager.State.menu;
            GameManager.instance.LosePanel();
            isState = true;


        }
    }

    private void Transforms()
    {
        mainCube.transform.position = new Vector3(mainCube.transform.position.x, height + 1, mainCube.transform.position.z);
        transform.localPosition = new Vector3(0, -height, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collect") && !other.GetComponent<CollectableCube>().GetIsCollected())
        {
            AudioManager.instance.collect.Play();
            height += 1;
            GameManager.instance.SetScore(score += 1);
            other.gameObject.GetComponent<CollectableCube>().MakeCollected();
            other.gameObject.GetComponent<CollectableCube>().MakeIndex(height - 1);
            other.gameObject.transform.parent = mainCube.transform;

        }

        if (other.CompareTag("Finish"))
        {
            GameManager.instance.state=GameManager.State.menu;
            GameManager.instance.WinPanel(score);
            AudioManager.instance.win.Play();

        }
    }
    #endregion

    #region Public Method

    public void LessHeight()
    {
        AudioManager.instance.less.Play();
        GameManager.instance.SetScore(score += -1);
        height--;
    }
    #endregion
}
