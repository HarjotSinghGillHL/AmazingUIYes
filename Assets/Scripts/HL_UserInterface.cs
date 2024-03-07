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
    public GameObject AbilityChargeGameObject = null;
    public GameObject AbilityChargeTextGameObject = null;
    public GameObject DropDownImageGameObject = null;
    public GameObject DropDownGameObject = null;

    public GameObject HealthBarBackgroundGameObject = null;
    public GameObject HealthBarForegroundGameObject = null;
    public GameObject HealthTextGameObject = null;

    public GameObject CoinsCollectedBarBackgroundGameObject = null;
    public GameObject CoinsCollectedBarForegroundGameObject = null;
    public GameObject CoinsCollectedTextGameObject = null;

    TextMeshProUGUI HealthTextObject = null;
    TextMeshProUGUI ScoreTextObject = null;
    TextMeshProUGUI AbilityChargeText = null;
    TextMeshProUGUI CoinsCollectedTextObject = null;

    UnityEngine.UI.Image RgbaTestImage = null;
    UnityEngine.UI.Image AbilityChargeImage = null;
    UnityEngine.UI.Image DropDownImage = null;
    UnityEngine.UI.Image HealthBackgroundImage = null;
    UnityEngine.UI.Image HealthForegroundImage = null;
    UnityEngine.UI.Image CoinsCollectedBackgroundImage = null;
    UnityEngine.UI.Image CoinsCollectedForegroundImage = null;

    TMP_InputField InputFieldObject = null;

    TMP_Dropdown DropdownImageDropdownComponent = null;

    private Color colRgbaTestImage = Color.white;
    private int Score = 0;
    private int Health = 100;
    private int CollectedCoins = 0;
    void Start()
    {
        InputFieldObject = InputFieldGameObject.GetComponent<TMP_InputField>();
        InputFieldObject.textComponent.text = "343";

        HealthTextObject = HealthTextGameObject.GetComponent<TextMeshProUGUI>();
        HealthBackgroundImage = HealthBarBackgroundGameObject.GetComponent<UnityEngine.UI.Image>();
        HealthForegroundImage = HealthBarForegroundGameObject.GetComponent<UnityEngine.UI.Image>();
       
        CoinsCollectedTextObject = CoinsCollectedTextGameObject.GetComponent<TextMeshProUGUI>();
        CoinsCollectedBackgroundImage = CoinsCollectedBarBackgroundGameObject.GetComponent<UnityEngine.UI.Image>();
        CoinsCollectedForegroundImage = CoinsCollectedBarForegroundGameObject.GetComponent<UnityEngine.UI.Image>();

        ScoreTextObject = ScoreTextGameObject.GetComponent<TextMeshProUGUI>();
        RgbaTestImage = RgbaTestImageGameObject.GetComponent<UnityEngine.UI.Image>();

        AbilityChargeImage = AbilityChargeGameObject.GetComponent<UnityEngine.UI.Image>();
        DropDownImage = DropDownImageGameObject.GetComponent<UnityEngine.UI.Image>();
        AbilityChargeText = AbilityChargeTextGameObject.GetComponent<TextMeshProUGUI>();
        DropdownImageDropdownComponent = DropDownGameObject.GetComponent<TMP_Dropdown>();
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

    public void OnCoinCollected()
    {
        Debug.Log("Pressed");
        CollectedCoins += 1;
        CollectedCoins = Mathf.Clamp(CollectedCoins, 0, 10);
        CoinsCollectedForegroundImage.fillAmount = (float)CollectedCoins / 10.0f;
        CoinsCollectedTextObject.SetText(CollectedCoins+"/10");

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

    public void UpdateHealth(int NewHealth)
    {
        if (NewHealth == 0)
            Health = 0;
        else
        {
            Health += NewHealth;
        }

        Health = Mathf.Clamp(Health, 0, 100);
        HealthForegroundImage.fillAmount = ((float)Health / 100.0f);
        HealthForegroundImage.color = new Color(1.0f - (1.0f * HealthForegroundImage.fillAmount), 1.0f * HealthForegroundImage.fillAmount, HealthForegroundImage.color.b,1.0f);
        HealthTextObject.SetText(Health.ToString());
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

    public void OnDropdownValueChange()
    {
        switch (DropdownImageDropdownComponent.value)
        {
            case 0:
                {
                    DropDownImage.color = Color.white;
                    break;
                }
            case 1:
                {
                    DropDownImage.color = Color.red;
                    break;
                }
            case 2:
                {
                    DropDownImage.color = Color.green;
                    break;
                }
            case 3:
                {
                    DropDownImage.color = Color.blue;
                    break;
                }
            default:
                {
                    break;
                }
        }

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

    public void HandleAbilityRadialIndicator(GameObject CallerObject)
    {
        AbilityChargeImage.fillAmount = 0.0f;
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
                    if (InputFieldObject.text.Length > 0 && InputFieldObject.text != "")
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
        if (AbilityChargeImage.fillAmount < 1.0f)
        {
            AbilityChargeImage.fillAmount += 1.0f * Time.deltaTime;
            AbilityChargeImage.fillAmount = Mathf.Clamp(AbilityChargeImage.fillAmount, 0.0f, 1.0f);

            AbilityChargeText.SetText("(Radial) Ability Charge : " + ((int)(AbilityChargeImage.fillAmount * 100.0f)));
        }
    }
}
