using UnityEngine;

class ColorChangable : MonoBehaviour, IColorChangable
{
    public void ChangeColor(Color color)
    {
        // ここで色を変える処理をする。
        Debug.Log("change color to " + color);
    }
}