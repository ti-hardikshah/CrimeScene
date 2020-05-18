using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQualityLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void ChangeQuality(int i) {
        QualitySettings.SetQualityLevel(i, true);
    }
}
