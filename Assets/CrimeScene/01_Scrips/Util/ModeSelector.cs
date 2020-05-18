using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelector : MonoBehaviour
{

    public Toggle ARmode;
    public Toggle LazyMode;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("IsLazyMode", 1) == 1)
        {
            ARmode.isOn = true;
        }
        else {
            LazyMode.isOn = true;
        }

    }

    public void ActivateARMode() {
        PlayerPrefs.SetInt("IsLazyMode", 1);
        transform.gameObject.SetActive(false);
    }

    public void ActivateLazyMode()
    {
        PlayerPrefs.SetInt("IsLazyMode", 0);
        transform.gameObject.SetActive(false);
    }

}
