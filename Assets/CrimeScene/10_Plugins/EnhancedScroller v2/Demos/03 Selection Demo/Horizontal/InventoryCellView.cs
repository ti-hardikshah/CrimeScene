using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellView : EnhancedScrollerCellView
{

    public delegate void SelectedDelegate(EnhancedScrollerCellView cellView);


    private InventoryData _data;


    public int id;
    public Image selectionPanel;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Text itemRewardText;
    public bool isLocked;
    public Image image;

    public Color selectedColor;
    public Color unSelectedColor;

    public int DataIndex { get; private set; }


    bool isNormalUI = true;


    public SelectedDelegate selected;


    void OnDestroy()
    {
        if (_data != null)
        {
            // remove the handler from the data so 
            // that any changes to the data won't try
            // to call this destroyed view's function
            _data.selectedChanged -= SelectedChanged;
        }
    }

    public void SetData(int dataIndex, InventoryData data)
    {
        // if there was previous data assigned to this cell view,
        // we need to remove the handler for the selection change
        if (_data != null)
        {
            _data.selectedChanged -= SelectedChanged;
        }

        // link the data to the cell view
        DataIndex = dataIndex;
        _data = data;

        // update the cell view's UI
       
        id = data.id;

        if (itemNameText != null) itemNameText.text = data.itemName;
        if (itemRewardText != null) itemRewardText.text = (data.rewardAmount > 0 ? data.rewardAmount.ToString() : "-");

        // the description is only shown on the vertical cell view
        //  if (isVertical)
        //  itemDescriptionText.text = data.itemDescription;

        // set up the sprite based on the sprite path and whether the
        // view is horizontal or vertical
        image.sprite = Resources.Load<Sprite>(data.spritePath);

        // set up a handler so that when the data changes
        // the cell view will update accordingly. We only
        // want a single handler for this cell view, so 
        // first we remove any previous handlers before
        // adding the new one
        _data.selectedChanged -= SelectedChanged;
        _data.selectedChanged += SelectedChanged;

        // update the selection state UI
        SelectedChanged(data.Selected);
    }


    private void SelectedChanged(bool selected)
    {

        

     /*   if (selected)
        {
            Debug.Log("Selected !! "+ _data.itemName);
            selectionPanel.color = selectedColor;
        }
        else {
            Debug.Log("Deselect !!" + _data.itemName);
            selectionPanel.color = unSelectedColor;
        }
        */


        selectionPanel.color = (selected ? selectedColor : unSelectedColor);
    }

    /// <summary>
    /// This function is called by the cell's button click event
    /// </summary>
    public void OnSelected()
    {
        // if a handler exists for this cell, then
        // call it.
        if (selected != null)
        {
            selected(this);
        }
        else {
            Debug.Log("Not selected");
        }
    }

}
