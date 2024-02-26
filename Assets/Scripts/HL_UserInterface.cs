using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EButtonPressEvent
{
    BEVENT_ADD_SCORE,
    BEVENT_SUB_SCORE,
    BEVENT_MAX,
}
public class HL_UserInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonEvent(int Event)
    {
        Debug.Log("Button Event Fired ! : " + Event);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
