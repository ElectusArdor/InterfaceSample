using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class View : MonoBehaviour
{
    [SerializeField] private List<Text> texts;
    [SerializeField] private List<Toggle> toggles;
    [SerializeField] private List<UIImage> eyes;
    [SerializeField] private List<InputField> fields;
    [SerializeField] private RectTransform contentRT, menuPanelRT;
    [SerializeField] private InputField inputField;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 hiddenPos, showPos;

    private bool togglesOn = false;
    private bool eyesOn = true;
    private Vector2 targetPosition;

    void Start()
    {
        Screen.SetResolution(420, 540, false);

        foreach (UIImage eye in eyes)
        {
            SetImgProperties(eye, true);
        }

        foreach (Text text in texts)
        {
            text.enabled = true;
        }

        targetPosition = hiddenPos;
    }

    public void SetImgProperties(UIImage img, bool eyeOn)
    {
        img.color = img.colors[eyeOn];
        img.colored = eyeOn;
    }

    public void OnShowBtnClick()
    {
        if (targetPosition == hiddenPos)
            targetPosition = showPos;
        else
            targetPosition = hiddenPos;
    }

    public void OnOffAllEyes()
    {
        eyesOn = !eyesOn;

        for (int i = 0; i < eyes.Count; i++)
        {
            SetImgProperties(eyes[i], eyesOn);
            texts[i].enabled = eyesOn;
        }
    }

    public void OnOffAllToggles()
    {
        togglesOn = !togglesOn;
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = togglesOn;
        }
    }

    public void AddInputField()
    {
        int deltaHeight = 75 * fields.Count;
        FitHeight(deltaHeight);

        fields.Add(Instantiate(inputField) as InputField);
        RectTransform rt = fields[fields.Count - 1].GetComponent<RectTransform>();
        rt.SetParent(contentRT, false);
        rt.localPosition = new Vector3(260, -45 - deltaHeight, 0);

        texts.Add(rt.transform.GetChild(1).gameObject.GetComponent<Text>());
        toggles.Add(rt.transform.GetChild(2).gameObject.GetComponent<Toggle>());
        eyes.Add(rt.transform.GetChild(3).gameObject.GetComponent<UIImage>());
    }

    public void RemoveInputField()
    {
        if (fields.Count > 1)
        {
            Destroy(fields[fields.Count - 1].gameObject);
            fields.RemoveAt(fields.Count - 1);
            texts.RemoveAt(texts.Count - 1);
            toggles.RemoveAt(toggles.Count - 1);
            eyes.RemoveAt(eyes.Count - 1);
            FitHeight(75 * (fields.Count - 1));
        }
    }

    private void FitHeight(int deltaHeight)
    {
        if (deltaHeight > 510)
            menuPanelRT.sizeDelta = new Vector2(600, 800);
        else
            menuPanelRT.sizeDelta = new Vector2(600, 290 + deltaHeight);
        contentRT.sizeDelta = new Vector2(520, 135 + deltaHeight);
    }

    private void MoveMenu()
    {
        menuPanelRT.anchoredPosition = Vector2.MoveTowards(menuPanelRT.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        if (menuPanelRT.anchoredPosition != targetPosition)
            MoveMenu();
    }
}
