using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Extended class Image with property "colored" and color set
/// </summary>
public class UIImage : Image
{
    private Color colorOff = new Color(0.7215686f, 0.7215686f, 0.7215686f, 1);
    private Color colorOn = new Color(0.01960784f, 0.0509804f, 0.4745098f, 1);
    public Dictionary<bool, Color> colors;
    public bool colored = true; //  This property makes it clear whether the UI element is active or not

    protected new void Awake()
    {
        base.Awake();
        colors = new Dictionary<bool, Color>() { { true, colorOn }, { false, colorOff } };
    }
}
