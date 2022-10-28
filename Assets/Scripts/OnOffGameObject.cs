using UnityEngine;

public class OnOffGameObject : MonoBehaviour
{
    private bool visible = true;

    public void OnOff()
    {
        ChangeVis(visible);
    }

    public void ChangeVis(bool vis)
    {
        if (vis)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        visible = !vis;
    }
}
