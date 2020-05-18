using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{

    public delegate void SelectedChangedDelegate(bool val);

    public int id;

    public string itemName;

    public int rewardAmount;

    public bool isLocked = true;

    public string spritePath;

    public string itemDescription;


    public SelectedChangedDelegate selectedChanged;

    private bool _selected;

    public bool Selected
    {
        get { return _selected; }
        set
        {
            // if the value has changed
            if (_selected != value)
            {
                // update the state and call the selection handler if it exists
                _selected = value;
                if (selectedChanged != null) selectedChanged(_selected);
            }
        }
    }



}
