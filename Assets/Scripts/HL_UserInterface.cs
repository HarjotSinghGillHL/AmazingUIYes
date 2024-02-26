using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum EButtonPressEvent : int
{
    BEVENT_ADD_SCORE = 0,
    BEVENT_SUB_SCORE,
    BEVENT_MAX,
}
public class HL_UserInterface : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ScoreTextGameObject = null;

    TextMeshProUGUI ScoreTextObject = null;
    int Score = 0;
    void Start()
    {
        ScoreTextObject= ScoreTextGameObject.GetComponent<TextMeshProUGUI>();
        ScoreTextObject.SetText("Score : " + Score);
    }

    private void Awake()
    {

    }

    public void OnButtonEvent(int Event)
    {
        switch ((EButtonPressEvent)Event)
        {
            case EButtonPressEvent.BEVENT_ADD_SCORE:
                {
                    Score += 15;
                    goto LABEL_SCORE_UPDATE;
                }
            case EButtonPressEvent.BEVENT_SUB_SCORE:
                {
                    Score -= 15;
                    goto LABEL_SCORE_UPDATE;
                }
            default:
                {
                    //Invalid Event
                    return;
                }
        }

LABEL_PROCESS_EVENT:

        return;

LABEL_SCORE_UPDATE:
        ScoreTextObject.SetText("Score : " + Score);
        goto LABEL_PROCESS_EVENT;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
