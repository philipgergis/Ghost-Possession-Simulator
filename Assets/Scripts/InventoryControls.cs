using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InventoryControls : ParentControls
{
    // Inventory holds up to 5 items
    [Header("Inventory")]
    [Range(1,5)][SerializeField] protected int maxItems = 5;

    // Inventory child
    [SerializeField] protected Transform inv;

    // Adjustment for where to keep object at
    [SerializeField] protected Vector3 adjustment;

    // current index in inventory
    protected int currentIndex = 0;

    // list of objects
    [ReadOnly] protected List<GameObject> invObjects;

    // SFX
    private AudioSource pickupAudio;

    private LayerMask grabMask;


    protected override void Awake()
    {
        base.Awake();
        pickupAudio = GetComponent<AudioSource>();
        grabMask = LayerMask.GetMask("Grab", "PossessGrab");
    }

    // Checks if full capacity is reached
    public bool RoomAvailable()
    {
        return inv.childCount < maxItems;
    }

    public bool ItemExists(GameObject item)
    {
        for(int i = 0; i < maxItems; i++)
        {
            if(item == invObjects[i])
            {
                return true;
            }
        }
        return false;
    }

    // Disables all images, the selection border, turns on slashes, and puts current index to 0
    protected void RevertHotbarSettings()
    {
        for(int i = 0; i < maxItems; i++)
        {
            HotbarManager.Instance.UpdateSlot(i, false, 3);
        }
        HotbarManager.Instance.UpdateSlot(currentIndex, false, 2);
        currentIndex = 0;
        //HotbarManager.Instance.UpdateSlot(currentIndex, true, 2);
        ShowAccessibleSlots(true);
    }

    // removes crosses from available inventory slows, or turns them back on
    public void ShowAccessibleSlots(bool show)
    {
        if(inControl)
        {
            for (int i = 0; i < maxItems; i++)
            {
                HotbarManager.Instance.UpdateSlot(i, show, 0);
            }
        }
    }

    // if there is an item in a slow it shows the image
    public void ShowItemImages()
    {
        if(inControl)
        {
            for (int i = 0; i < maxItems; i++)
            {
                if (invObjects[i] != null)
                {
                    HotbarManager.Instance.SetSlotImage(i, invObjects[i].GetComponent<Grabbables>().GetImage());
                    HotbarManager.Instance.UpdateSlot(i, true, 3);
                }
            }
        }
    }

    // shows which slot is selected, shows all items, then removes slashes when needed
    protected void HotbarUpdates()
    {
        SelectSlot();
        //ShowItemImages();
        //ShowAccessibleSlots(false);
    }


    // uses input from scroll wheel to change selected slot
    protected void SelectSlot()
    {
        if(inControl)
        {
            // y value from input is 120, 0, or -120
            float scroll = mainControls.Main.Inventory.ReadValue<Vector2>().y;

            // temporarily turn off selection
            HotbarManager.Instance.UpdateSlot(currentIndex, false, 2);

            // moves selection to right if scroll up and vice versa
            if (scroll > 0)
            {
                ChangeIndex(currentIndex - 1);
            }
            if (scroll < 0)
            {
                ChangeIndex(currentIndex + 1);
            }

            // turn selection border on new selected slot
            HotbarManager.Instance.UpdateSlot(currentIndex, true, 2);
        }  
    }

    // makes sure index is not negeative or >= maxItems
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
            for(int i = 0; i < maxItems; i++)
            {
                // if slot is full do not add item
                if(invObjects[i] == null)
                {
                    // makes item child of inventory, then sets its position in front of entity, then sets it to false
                    invObjects[i] = obj;
                    obj.transform.parent = inv;
                    obj.transform.position = transform.position + transform.forward + adjustment;
                    obj.SetActive(false);
                    HotbarManager.Instance.SetSlotImage(i, invObjects[i].GetComponent<Grabbables>().GetImage());
                    HotbarManager.Instance.UpdateSlot(i, true, 3);
                    break;
                }
            }
            
        }
    }


    // Delete item from inventory
    // Add item to inventory
    public void DeleteItem(GameObject obj)
    {
        for(int i = 0; i < maxItems; i++)
        {
            if(invObjects[i] == obj)
            {
                HotbarManager.Instance.UpdateSlot(i, false, 3);
                HotbarManager.Instance.SetSlotImage(i, null);
                invObjects[i] = null;
                HotbarManager.Instance.UpdateSlot(i, false, 3);
                Destroy(obj);
            }
        }
    }


    // drop item in front of entity
    public void DropItem(int index)
    {
        GameObject child = invObjects[index];

        // do not drop if slot empty or if there is something in the way of spawning the item
        if (child != null && Physics.OverlapSphere(child.transform.position, 0.5f).Length == 0)
        {
            // remove image from hotbar and inventory array, make object parentless, and make it active
            HotbarManager.Instance.UpdateSlot(currentIndex, false, 3);
            HotbarManager.Instance.SetSlotImage(index, null);
            invObjects[index] = null;
            child.transform.parent = null;
            child.SetActive(true);
        }
    }

    // gets an item if it is in the inventory
    public GameObject GetCurrentItem()
    {
        return invObjects[currentIndex];
    }

    // make an array the length of the items the entity can carry
    protected virtual void Start()
    {
        invObjects = new List<GameObject>();
        for(int i = 0; i < maxItems; i++)
        {
            invObjects.Add(null);
        }
    }

    // grabs object if there is room
    protected void GrabObject()
    {
        // Gets object in an area, if they are grabbable it grabs the first one from the list
        Collider[] grabs = Physics.OverlapBox(transform.position + transform.forward, new Vector3(1, 1, 1), Quaternion.identity, grabMask);

        // if an object was detected add if there is space
        if (grabs.Length > 0 && RoomAvailable())
        {
            AudioSource.PlayClipAtPoint(pickupAudio.clip, transform.position, 2.0f);
            AddItem(grabs[0].gameObject);
        }
    }

    // Ability to call for special ability, add grab object to it
    protected override void StartAbility()
    {

        if (mainControls.Main.Ability.triggered && inControl)
        {
            GetInteraction();
            GrabObject();
        }
        else if(mainControls.Main.Drop.triggered && inControl)
        {
            DropItem(currentIndex);
        }
    }

    // update hot bar
    protected override void Update()
    {
        if(!PauseControls.Instance.GetPause())
        {
            base.Update();
            HotbarUpdates();
        }
    }

    // unpossess mechanic, added so you can revert the hotbar when going to be a ghost
    protected override void Possession()
    {
        // if entity is in control, the possess button is pressed, and the ghost is a child, unpossess the target
        if (inControl && mainControls.Main.Possess.triggered)
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

            if (ghost != null)
            {
                // checks for objects the ghost cannot spawn over
                Collider[] obstacles = Physics.OverlapSphere(ghost.position, radiusDetect, mask);

                // if no objects blocking the way, unposssess target and change the camera
                if (obstacles.Length == 0)
                {
                    // added revert hot bar settings to unpossession
                    RevertHotbarSettings();
                    ghost.gameObject.SetActive(true);
                    ghost.GetComponent<ParentControls>().SetControl(true);
                    ghost.transform.parent = null;
                    CameraShift(ghost);
                    SetControl(false);
                }
            }
        }
    }

}
