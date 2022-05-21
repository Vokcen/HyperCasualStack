using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text _score;

    [SerializeField] GameObject startPanel;

    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] TMP_Text winScore;

    public static GameManager instance;

    public enum State
    {
        game,
        menu
    }
    public State state;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    private void Start()
    {

        state = State.menu;
    }

    void Update()
    {
        StartsPanel();



    }

    public void LosePanel()
    {

        losePanel.SetActive(true);

    }

    public void WinPanel(int score)
    { 
      winPanel.SetActive(true);
      winScore.SetText("Congratulations You Won!!! Touch The Screen Restart The Game Your Score : "+score.ToString());
    }

    private void StartsPanel()
    {
        if (state == State.menu)
        {
            if (Input.anyKey)
            {
                startPanel.SetActive(false);
                state = State.game;
            }
        }
    }

    public void SetScore(int score = 0)
    {
        _score.SetText("Score : " + score.ToString());
    }

}
