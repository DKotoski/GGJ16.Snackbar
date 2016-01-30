using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class swipe : MonoBehaviour {

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    Text instruction;
    Text instruction2;

    void Start()
    {
        instruction = GameObject.Find("debug").GetComponent<Text>();
        instruction2 = GameObject.Find("swipee").GetComponent<Text>();
    }

    void Update()
    {
        int i = 0;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
        RaycastHit hit;
        instruction.text = "tap";

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            instruction.text = "tap 2";
            if (hit.transform.name == "pos1")
            {
                instruction.text = "pos1";
                swipeDetect();
            }
            if (hit.transform.name == "pos2")
            {
                instruction.text = "pos2";
                swipeDetect();
            }
        }
        ++i;
    }

    void swipeDetect()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;


                    if (swipeDistHorizontal > swipeDistVertical)
                    {
                        if (swipeDistHorizontal > minSwipeDistX)
                        {
                            float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                            if (swipeValue > 0)
                            {
                                instruction2.text = "right";
                            }
                                
                            else if (swipeValue < 0)
                            {
                                instruction2.text = "left";
                            }
                                
                        }
                    }
                    else if (swipeDistHorizontal < swipeDistVertical)
                    {
                        if (swipeDistVertical > minSwipeDistY)
                        {
                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                            if (swipeValue > 0)
                            {
                                instruction2.text = "up";
                            }
                                

                            else if (swipeValue < 0)
                            {
                                instruction2.text = "down";
                            }
                                
                        }
                    }

                    break;
            }
        }
    }
}
