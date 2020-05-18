using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{


    public static SelectionController Instance = null;

    [SerializeField]
    private CanvasGroup menuUI;

   // [SerializeField]
   // private CanvasGroup backButton;

  //  public GameObject parent;
   // public GameObject prefab;


    public string resourcePath;

   // public bool firstTime;


  //  public GameObject InstructionPnl;


    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

      //  firstTime = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    


    public void DisplayObject(string name) {

   /*     if (firstTime) {
            InstructionPnl.SetActive(true);
            firstTime = false;
        }*/
       

        menuUI.alpha = 0;
        menuUI.interactable = false;
        menuUI.blocksRaycasts = false;

      //  if (prefab != null) {
      //
    //        Destroy(prefab);
     //   }


        // prefab = Instantiate(Resources.Load(resourcePath+"/"+name, typeof(GameObject)) , parent.transform,false) as GameObject;

        EvidencePlacementController.Instance.UpdateItemState(resourcePath + "/" + name);

    }




    public void backToMenu() {

        menuUI.alpha = 1;
        menuUI.interactable = true;
        menuUI.blocksRaycasts = true;

        EvidencePlacementController.Instance.ResetPrefab();


    }
}
