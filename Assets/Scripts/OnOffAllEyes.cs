using UnityEngine;

public class OnOffAllEyes : MonoBehaviour
{
    [SerializeField] private ChangeBtnColor[] toggles;
    [SerializeField] private OnOffGameObject[] texts;

    private bool on = true;

    public void OnClick()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].ChangeColor(on);
            texts[i].ChangeVis(on);
        }
        on = !on;
    }
}
