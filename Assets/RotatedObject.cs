using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotatedObject : MonoBehaviour
{
    private Vector3 startMousePosition;
    public GameObject player;
    int UILayer;

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

    // Update is called once per frame
    void Update()
    {
        if (Model.inst().isTotallyPaused)
        {
            return;
        }
        if (Model.inst().isPaused && !Input.GetMouseButton(0))
        {
            return;
            
        }
        else if (Model.inst().isPaused && !IsPointerOverUIElement())
        {
            print("NNNN");
            View.inst().uiController.showScreen(-1);
            Model.inst().isPaused = false;
        }
        try
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                startMousePosition = Input.mousePosition;
                GameObject newRoot = new GameObject();
                newRoot.transform.position = player.transform.position;
                transform.SetParent(newRoot.transform);
            }
            if (Input.GetMouseButtonUp(0))
            {
                transform.SetParent(transform.parent.parent);
            }
            if (Input.GetMouseButton(0))
            {
                float deltaX = (Input.mousePosition - startMousePosition).y / 4; ;
                //if (transform.parent.localEulerAngles.x >= 300)
                //{
                //    if (360 - transform.parent.localEulerAngles.x <= 36)
                //    {
                        
                //    }
                //}
                //else if (transform.parent.localEulerAngles.x <= 18)
                //{
                //    deltaX = (Input.mousePosition - startMousePosition).y / 4;
                    
                //}
                transform.parent.localEulerAngles = new Vector3(deltaX, 0, (Input.mousePosition - startMousePosition).x / 4);
            }
        }
        catch
        {
           
        }
    }
}
