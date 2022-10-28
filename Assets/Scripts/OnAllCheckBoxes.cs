using UnityEngine;
using UnityEngine.UI;

public class OnAllCheckBoxes : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;

    private bool on = true;

    public void OnClick()
    {
        if (on)
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = false;
            }
            on = false;
        }
        else
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = true;
            }
            on = true;
        }
    }
}
