using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;

    // Update is called once per frame
    void Update ()
    {

#if UNITY_EDITOR
        // For testing in editor
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            // Handles multiple touches
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            
            // Uses raycasts to detect touch hits
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                

            if (Physics.Raycast(ray, out hit, touchInputMask))
            {
                // Get reference to hit object
                GameObject reciever = hit.transform.gameObject;
                touchList.Add(reciever);

                if (Input.GetMouseButtonDown(0))
                {
                    reciever.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    reciever.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    reciever.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }

            foreach (GameObject obj in touchesOld)
            {
                if (!touchList.Contains(obj))
                {
                    obj.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }

#endif
        if (Input.touchCount > 0)
        {
            // Handles multiple touches
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                // Uses raycasts to detect touch hits
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    // Get reference to hit object
                    GameObject reciever = hit.transform.gameObject;
                    touchList.Add(reciever);

                    if (touch.phase == TouchPhase.Began)
                    {
                        reciever.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        reciever.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        reciever.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        reciever.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            foreach (GameObject obj in touchesOld)
            {
                if (!touchList.Contains(obj))
                {
                    obj.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        
	}
}
