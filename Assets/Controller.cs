using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setLevel(Model.level-1);
    }

    public static void setLevel(int levelIndex)
    {
        for (int i=0;i< Model.inst().levels.Length;i++)
        {
            Model.inst().levels[i].SetActive(levelIndex == i);
            if (levelIndex == i)
            {
                View.inst().player.transform.SetParent(Model.inst().levels[i].transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
