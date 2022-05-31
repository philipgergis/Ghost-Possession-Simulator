using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControls : ParentControls
{
    // Inventory holds up to 5 items
    [Range(1,5)][SerializeField] protected int maxItems = 5;

    // Inventory child
    [SerializeField] protected Transform inv;

    // Adjustment for where to keep object at
    [SerializeField] protected Vector3 adjustment;

    // current index in inventory
    protected int currentIndex = 0;

    // Checks if full capacity is reached
    public bool RoomAvailable()
    {
        return inv.childCount < maxItems;
    }

    protected override void Possession()
    {
        
        // ghost variable
        Transform ghost = null;

        // looks for a ghost in the child objects
        foreach (Transform child in transform)
        {
            if (child.tag == "Ghost")
            {
                ghost = child;
                break;
            }
        }

        // if entity is in control, the possess button is pressed, and the ghost is a child, unpossess the target
        if (inControl && mainControls.Main.Possess.triggered && ghost != null && rb.velocity == Vector3.zero)
        {
            // checks for objects the ghost cannot spawn over
            Collider[] obstacles = Physics.OverlapBox(ghost.position, new Vector3(1, 1, 1), Quaternion.identity, LayerMask.GetMask("Anti-Ghost"));

            // if no objects blocking the way, unposssess target and change the camera
            if (obstacles.Length == 0)
            {
                RevertHotbarSettings();
                ghost.gameObject.SetActive(true);
                ghost.GetComponent<ParentControls>().SetControl(true);
                ghost.transform.parent = null;
                CameraShift(ghost);
                SetControl(false);
            }
        }
    }

    protected void RevertHotbarSettings()
    {
        HotbarManager.Instance.UpdateSlot(currentIndex, false, 2);
        currentIndex = 0;
        HotbarManager.Instance.UpdateSlot(currentIndex, true, 2);
        ShowAccessibleSlots(true);
    }

    protected void ShowAccessibleSlots(bool show)
    {
        if(inControl)
        {
            for (int i = 0; i < maxItems; i++)
            {
                HotbarManager.Instance.UpdateSlot(i, show, 0);
            }
        }
    }

    protected void HotbarUpdates()
    {
        SelectSlot();
        ShowAccessibleSlots(false);
    }

    protected void SelectSlot()
    {
        if(inControl)
        {
            float scroll = mainControls.Main.Inventory.ReadValue<Vector2>().y;
            HotbarManager.Instance.UpdateSlot(currentIndex, false, 2);
            if (scroll > 0)
            {
                ChangeIndex(currentIndex - 1);
            }
            if (scroll < 0)
            {
                ChangeIndex(currentIndex + 1);
            }
            HotbarManager.Instance.UpdateSlot(currentIndex, true, 2);
        }  
    }

    protected void ChangeIndex(int index)
    {
        if(index < 0)
        {
            currentIndex = maxItems-1;
        }
        else if(index >= maxItems)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex = index;
        }
    }
    
    // Add item to inventory
    public void AddItem(GameObject obj)
    {
        if (inv.childCount < maxItems)
        {
            obj.transform.parent = inv;
            obj.transform.position = transform.position + transform.forward + adjustment;
            obj.SetActive(false);
        }
    }

    // Delete item from inventory
    // Add item to inventory
    public void DeleteItem(GameObject obj)
    {
        if (FindItem(obj))
        {
            Destroy(obj);
        }
    }


    // drop item
    public void DropItem(int index)
    {

        
        Transform child = inv.GetChild(index);

        if (child != null && Physics.OverlapSphere(child.position, 0.5f).Length == 0)
        {
            child.parent = null;
            child.gameObject.SetActive(true);
        }
    }

    // checks if an item is in the inventory
    public bool FindItem(GameObject obj)
    {
        foreach (Transform child in inv)
        {
            if (child.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }


    protected virtual void Start()
    {
        
    }


    protected void GrabObject()
    {
        // Gets object in an area, if they are grabbable it grabs the first one from the list
        Collider[] grabs = Physics.OverlapBox(transform.position + transform.forward, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Grab", "PossessGrab"));

        if (grabs.Length > 0 && RoomAvailable())
        {
            AddItem(grabs[0].gameObject);
        }
    }

    // Ability to call for special ability
    protected override void StartAbility()
    {
        if (mainControls.Main.Ability.triggered && inControl)
        {
            GrabObject();
        }
        else if(mainControls.Main.Drop.triggered && inControl)
        {
            DropItem(currentIndex);
        }
    }

    protected override void Update()
    {
        base.Update();
        HotbarUpdates();
    }


}
