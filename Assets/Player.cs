using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if  (collision.gameObject.CompareTag("Finish"))
        {
            Model.inst().isTotallyPaused = true;
            View.inst().uiController.showScreen(1);
        }
    }
}
