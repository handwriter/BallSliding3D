using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private static View me;
    public UIController uiController;
    public GameObject player;

    public static View inst()
    {
        if (me == null)
        {
            me = GameObject.Find("View").GetComponent<View>();
        }
        return me;
    }
}
