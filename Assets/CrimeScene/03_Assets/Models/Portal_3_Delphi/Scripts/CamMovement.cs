using UnityEngine;
using UnityEngine.UI;

public class CamMovement : MonoBehaviour
{
    public float SpeedMovement;
    private int Forwarding;

    private float Timer;
    private int Frames;

    public Text T_FPS;

    public float SpeedVertical;
    public float SpeedHorizontal;

    public int RotationFactorV;
    public int RotationFactorH;

    public Transform Cube;
    private Vector3 TempPos;

    private void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            Application.targetFrameRate = 60;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * Forwarding * -SpeedMovement * Time.deltaTime, Space.World);

        transform.Rotate(RotationFactorV * SpeedVertical * Time.deltaTime, 0, 0);
        transform.Rotate(0, RotationFactorH * SpeedHorizontal * Time.deltaTime, 0, Space.World);

        Timer += Time.deltaTime;
        Frames++;

        if(Timer >= 1)
        {
            Timer = 0;
            T_FPS.text = Frames.ToString();
            Frames = 0;
        }

        /*TempPos = transform.position;
        TempPos.x = transform.position.x * 0.33f;
        Cube.position = TempPos*/
    }


    public void OnForward_ON()
    {
        Forwarding = 1;
    }

    public void OnForward_OFF()
    {
        Forwarding = 0;
    }

    public void OnBackward_ON()
    {
        Forwarding = -1;
    }

    public void OnBackward_OFF()
    {
        Forwarding = 0;
    }




    public void OnHorizontal_Right()
    {
        RotationFactorH = 1;
    }

    public void OnHorizontal_Left()
    {
        RotationFactorH = -1;
    }

    public void OnHorizontal_OFF()
    {
        RotationFactorH = 0;
    }




    public void OnVertical_Up()
    {
        RotationFactorV = -1;
    }

    public void OnVertical_Down()
    {
        RotationFactorV = 1;
    }

    public void OnVertical_OFF()
    {
        RotationFactorV = 0;
    }
}