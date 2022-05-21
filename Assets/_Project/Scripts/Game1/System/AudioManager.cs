using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource collect;
    public AudioSource less;
    public AudioSource win;
    public AudioSource lose;

    public static AudioManager instance;


    private void Awake()
    {
        if (instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(this);
        }
    }

}
