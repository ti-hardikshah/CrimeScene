using System.Collections;
using System.Collections.Generic;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScript : MonoBehaviour, IEnhancedScrollerDelegate
{


    //data for scroll view // can be get from locally or remotly
    private SmallList<InventoryData> _data;


    public EnhancedScroller hScroller;

    public EnhancedScrollerCellView hCellViewPrefab;

    public Image selectedImage;
    public Text selectedImageText;

    public string resourcePath;


    void Awake()
    {
        // turn on the mask and loop functionality for each scroller based
        // on the UI settings of this controller

        // var maskToggle = GameObject.Find("Mask Toggle").GetComponent<Toggle>();
        MaskToggle_OnValueChanged(true);

        // var loopToggle = GameObject.Find("Loop Toggle").GetComponent<Toggle>();
        LoopToggle_OnValueChanged(false);

        CellViewSelected(null);
    }


    void Start()
    {
       
        hScroller.Delegate = this;

        // reload the data
        Reload();
    }

    private void Reload()
    {
        // if the data existed previously, loop through
        // and remove the selection change handlers before
        // clearing out the data.
        if (_data != null)
        {
            for (var i = 0; i < _data.Count; i++)
            {
                _data[i].selectedChanged = null;
            }
        }

        // set up a new inventory list
        _data = new SmallList<InventoryData>();

        // add inventory items to the list
        _data.Add(new InventoryData() { id = 0, itemName = "Key", rewardAmount = 100, spritePath = resourcePath + "/Key", itemDescription = "Broadsword with a double-edged blade" });
        _data.Add(new InventoryData() { id = 1, itemName = "Gloves", rewardAmount = 160, spritePath = resourcePath + "/Gloves", itemDescription = "Steel shield to deflect your enemy's blows" });
        _data.Add(new InventoryData() { id = 2, itemName = "Pager", rewardAmount = 220, spritePath = resourcePath + "/Pager", itemDescription = "Magic amulet restores your health points gradually over time" });
        _data.Add(new InventoryData() { id = 3, itemName = "Hat",  rewardAmount = 250, spritePath = resourcePath + "/Hat", itemDescription = "Standard helm will decrease your vulnerability" });
        _data.Add(new InventoryData() { id = 4, itemName = "Shoe", rewardAmount = 150, spritePath = resourcePath + "/Shoe", itemDescription = "Boots of speed will double your movement points" });


        Debug.Log("Total data available for display scroll : "+_data.Count);

        // tell the scrollers to reload
        //  vScroller.ReloadData();
        hScroller.ReloadData();
    }

    private void CellViewSelected(EnhancedScrollerCellView cellView)
        {
            if (cellView == null)
            {
            // nothing was selected
            /*
            selectedImage.gameObject.SetActive(false);
            selectedImageText.text = "None";
            */

            Debug.Log("Noting Selected : ");
   
            }
            else
            {
                // get the selected data index of the cell view
                var selectedDataIndex = (cellView as InventoryCellView).DataIndex;

                // loop through each item in the data list and turn
                // on or off the selection state. This is done so that
                // any previous selection states are removed and new
                // ones are added.
                for (var i = 0; i < _data.Count; i++)
                {
                    _data[i].Selected = (selectedDataIndex == i);
                }

            // selectedImage.gameObject.SetActive(true);

            // selectedImage.sprite = Resources.Load<Sprite>(_data[selectedDataIndex].spritePath + ("_h"));

            //selectedImageText.text = _data[selectedDataIndex].itemName;


            Debug.Log("Selected Value is : " + _data[selectedDataIndex].itemName);

            SelectionController.Instance.DisplayObject(_data[selectedDataIndex].itemName);

            }
        }


    public void MaskToggle_OnValueChanged(bool val)
    {
        // set the mask component of each scroller
        //            vScroller.GetComponent<Mask>().enabled = val;
        hScroller.GetComponent<Mask>().enabled = val;
    }

    /// <summary>
    /// This handles the toggle fof the looping
    /// </summary>
    /// <param name="val">Is the looping on?</param>
    public void LoopToggle_OnValueChanged(bool val)
    {
        // set the loop property of each scroller
        //            vScroller.Loop = val;
        hScroller.Loop = val;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return _data.Count;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        //     if (scroller == vScroller)
        //   {
        // return a static height for all vertical scroller cells
        //     return 320f;
        // }
        // else
        // {
        // return a static width for all horizontal scroller cells
        return 150f;
        //   }
    }


    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        // first get a cell from the scroller. The scroller will recycle if it can.
        // We want a vertical cell prefab for the vertical scroller and a horizontal
        // prefab for the horizontal scroller.
        InventoryCellView cellView = scroller.GetCellView(hCellViewPrefab) as InventoryCellView;

        // set the name of the cell. This just makes it easier to see in our
        // hierarchy what the cell is

       // Debug.Log(" :---------- : " + _data[dataIndex].itemName);

        cellView.name = _data[dataIndex].itemName;

        // set the selected callback to the CellViewSelected function of this controller. 
        // this will be fired when the cell's button is clicked
        cellView.selected = CellViewSelected;

        // set the data for the cell
        cellView.SetData(dataIndex, _data[dataIndex]);

        // return the cell view to the scroller
        return cellView;
    }

}
