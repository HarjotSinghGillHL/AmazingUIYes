using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum EButtonPressEvent : int
{
    BEVENT_ADD_SCORE = 0,
    BEVENT_SUB_SCORE,
    BEVENT_RESET_SCORE,
    BEVENT_RANDOM_SCORE,
    BEVENT_SHOWHIDE_KEY,
    BEVENT_EXIT_GAME,
    BEVENT_SET_SCORE_CUSTOM,
    BEVENT_MAX,
}


public class HL_UserInterface : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ScoreTextGameObject = null;
    public GameObject KeyImageGameObject = null;
    public GameObject RgbaTestImageGameObject = null;
    public GameObject InputFieldGameObject = null;

    private Color colRgbaTestImage = Color.white;

    
    TextMeshProUGUI ScoreTextObject = null;
    UnityEngine.UI.Image RgbaTestImage = null;
    TMP_InputField InputFieldObject = null;


    int Score = 0;
    void Start()
    {
        InputFieldObject = InputFieldGameObject.GetComponent<TMP_InputField>();
        InputFieldObject.textComponent.text = "343";

        ScoreTextObject = ScoreTextGameObject.GetComponent<TextMeshProUGUI>();
        RgbaTestImage = RgbaTestImageGameObject.GetComponent<UnityEngine.UI.Image>();
 
    }
    private void Awake()
    {

    }

    public void OnInputTextValueUpdate(TMP_InputField _InputFieldObject)
    {
        if (_InputFieldObject.gameObject.name == "ScoreUpdateField")
        {

        }
    }

    public void OnInputTextEditEnd(TMP_InputField _InputFieldObject)
    {

    }

    public void OnInputTextSelect(TMP_InputField _InputFieldObject)
    {

    }

    public void OnInputTextDeselect(TMP_InputField _InputFieldObject)
    {

    }

    public void UpdateScore(int NewScore)
    {
        if (NewScore == 0)
            Score = 0;
        else
        {
            Score += NewScore;
        }

        Score = Mathf.Clamp(Score,0, 999999999);

        ScoreTextObject.SetText(Score.ToString());
    }

    public void OnSliderValueUpdate(UnityEngine.UI.Slider _Slider)
    {
        _Slider.gameObject.transform.Find("ValueText").GetComponent<TextMeshProUGUI>().SetText(((int)(_Slider.value * 255f)).ToString());
        
        if (_Slider.gameObject.name == "R")
            colRgbaTestImage.r = _Slider.value;
        else if (_Slider.gameObject.name == "G")
            colRgbaTestImage.g = _Slider.value;
        else if (_Slider.gameObject.name == "B")
            colRgbaTestImage.b = _Slider.value;
        else if (_Slider.gameObject.name == "A")
            colRgbaTestImage.a = _Slider.value;

        RgbaTestImage.color = colRgbaTestImage;
    }

    public void OnButtonEvent(int Event)
    {
        switch ((EButtonPressEvent)Event)
        {
            case EButtonPressEvent.BEVENT_ADD_SCORE:
                {
                    Score += 100000000;
                    goto LABEL_SCORE_UPDATE;
                }
            case EButtonPressEvent.BEVENT_SUB_SCORE:
                {
                    Score -= 100000000;
                    goto LABEL_SCORE_UPDATE;
                }
            case EButtonPressEvent.BEVENT_RESET_SCORE:
                {
                    Score = 0;
                    goto LABEL_SCORE_UPDATE;
                }
            case EButtonPressEvent.BEVENT_RANDOM_SCORE:
                {
                    UpdateScore(Random.Range(-999999999, 999999999));
                    goto LABEL_SCORE_UPDATE;
                }
            case EButtonPressEvent.BEVENT_SHOWHIDE_KEY:
                {
                    KeyImageGameObject.SetActive(!KeyImageGameObject.activeSelf); 
                    goto LABEL_POST_PROCESS_EVENT;
                }
            case EButtonPressEvent.BEVENT_EXIT_GAME:
                {
                    goto LABEL_POST_PROCESS_EVENT_ON_EXIT;
                }
            case EButtonPressEvent.BEVENT_SET_SCORE_CUSTOM:
                {
                    if (InputFieldObject.text.Length > 0)
                    {
                            Score = int.Parse(InputFieldObject.text);
                            goto LABEL_SCORE_UPDATE;
                        
                    }
                    goto LABEL_POST_PROCESS_EVENT_ON_EXIT;

                }

            default:
                {
                    //Invalid Event
                    return;
                }
        }
    LABEL_POST_PROCESS_EVENT:


        return;

    LABEL_POST_PROCESS_EVENT_ON_EXIT:

        Application.Quit();
        return;

    LABEL_SCORE_UPDATE:

        Score = Mathf.Clamp(Score, 0, 999999999);
        ScoreTextObject.SetText(Score.ToString());
        goto LABEL_POST_PROCESS_EVENT;

    }
    void Update()
    {
        
    }
}
