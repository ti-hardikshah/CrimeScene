using UnityEngine;

[ExecuteInEditMode]
public class FormBridge : MonoBehaviour
{
    public GameObject Prefab;
    public float Distance;

    private GameObject G;
    public int Counter;

    private void OnEnable()
    {
        G = Instantiate(Prefab, transform.position, Quaternion.identity) as GameObject;
        Counter++;

        G.transform.SetParent(transform);
        G.transform.localEulerAngles = Prefab.transform.localEulerAngles;
        G.transform.localScale = Prefab.transform.localScale;
        G.transform.localPosition = Prefab.transform.localPosition;

        G.name = Prefab.name + "_" + Counter.ToString();

        G.transform.localPosition = new Vector3(G.transform.localPosition.x, G.transform.localPosition.y, -Distance * Counter);
    }
}