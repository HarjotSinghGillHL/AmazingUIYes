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
    BEVENT_MAX,
}
public class HL_UserInterface : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ScoreTextGameObject = null;
    public GameObject KeyImageGameObject = null;
    public GameObject RgbaTestImageGameObject = null;

    private Color colRgbaTestImage = Color.white;

    TextMeshProUGUI ScoreTextObject = null;
    UnityEngine.UI.Image RgbaTestImage = null;

    int Score = 0;
    void Start()
    {
        ScoreTextObject= ScoreTextGameObject.GetComponent<TextMeshProUGUI>();
        RgbaTestImage = RgbaTestImageGameObject.GetComponent<UnityEngine.UI.Image>();
        ScoreTextObject.SetText(Score.ToString());
    }
    private void Awake()
    {

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
                    Score += Random.Range(-999999999, 999999999);
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

        if (Score < 0)
            Score = 0;
        else if (Score > 999999999)
            Score = 999999999;
        
        ScoreTextObject.SetText(Score.ToString());
        goto LABEL_POST_PROCESS_EVENT;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
