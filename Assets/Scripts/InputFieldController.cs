using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    public UIImage img;
    public Text text;

    private void Start()
    {
        img.colored = true;
    }

    public void OnEyeClick()
    {
        img.colored = !img.colored;
        ChangeColor(img.colored);
    }

    public void OnOffText()
    {
        text.enabled = !text.enabled;
    }

    private void ChangeColor(bool eyeOn)
    {
        img.color = img.colors[eyeOn];
        img.colored = eyeOn;
    }
}
