using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Unityエディタ上で変えたい色を指定できる。
    public Color color = Color.red;
    public GameObject plane;
    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            var change = other.gameObject.GetComponent<Renderer>().material;

            plane.gameObject.GetComponent<Renderer>().material = change;
        }
    }
}