using UnityEngine;

[ExecuteInEditMode]

public class PlaceTreeOnGround : MonoBehaviour
{
    private RaycastHit Hit;
    public bool RandomScale;
    public bool RandomRotation;
    private float ScaleFactor;
    private float ScaleAmount;

    private void Start()
    {
        ScaleFactor = transform.localScale.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 1000, transform.position.z);

        if(Physics.Raycast(transform.position, Vector3.down, out Hit))
        {
            transform.position = Hit.point;

            if(RandomScale)
            {
                ScaleAmount = Random.Range(-1.2f, 1.2f);
                transform.localScale =  Vector3.one * (ScaleFactor + ScaleAmount);
            }

            if(RandomRotation)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
            }
        }
    }
}