using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyMode : MonoBehaviour
{

    public static LazyMode Instance;

    public GameObject JoystickController;

    public CharacterController character;


    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator StartMode() {

        yield return new WaitForSeconds(2f);



    }


    public void EnableLazyMode() {
        JoystickController.gameObject.transform.position = new Vector3(JoystickController.gameObject.transform.position.x, 2f, JoystickController.gameObject.transform.position.z);
        JoystickController.SetActive(true);
        character.enabled = true;
    }
}
