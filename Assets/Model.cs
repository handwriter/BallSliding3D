using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private static Model me;
    public bool isPaused;
    public bool isTotallyPaused;
    public GameObject[] levels;

    public static int bril
    {
        get
        {
            if (!PlayerPrefs.HasKey("bril"))
            {
                PlayerPrefs.SetInt("bril", 0);
            }
            return PlayerPrefs.GetInt("bril");
        }
        set
        {
            PlayerPrefs.SetInt("bril", value);
        }
    }

    public static int level
    {
        get
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                PlayerPrefs.SetInt("level", 1);
            }
            return PlayerPrefs.GetInt("level");
        }
        set
        {
            PlayerPrefs.SetInt("level", value);
        }
    }



    public static Model inst()
    {
        if (me == null)
        {
            me = GameObject.Find("Model").GetComponent<Model>();
        }
        return me;
    }
}
