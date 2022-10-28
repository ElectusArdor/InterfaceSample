using UnityEngine;
using UnityEngine.UI;

public class ChangeBtnColor : MonoBehaviour
{
    private Image img;
    private Color colorOn, colorOff;
    private bool on = true;

    private void Start()
    {
        img = GetComponent<Image>();
        colorOff = new Color(0.7215686f, 0.7215686f, 0.7215686f, 1);
        colorOn = new Color(0.01960784f, 0.0509804f, 0.4745098f, 1);
    }

    public void ChangeColor(bool boolOn)
    {
        if (boolOn)
        {
            img.color = colorOff;
        }
        else
        {
            img.color = colorOn;
        }
        on = !boolOn;
    }

    public void OnClick()
    {
        ChangeColor(on);
    }
}
