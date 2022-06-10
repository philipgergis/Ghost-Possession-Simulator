using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TameableBehavior : MonoBehaviour
{
    // radius used to detect if the taming item is nearby
    [SerializeField] private float radius;

    // how fast entity moves to item
    [SerializeField] private float moveSpeed = 5f;

    // item to tame entity
    [SerializeField] private GameObject tamingItem;

    // orb to convey object is tamed
    [SerializeField] private GameObject tamed;

    // orb to convey object is untamed
    [SerializeField] private GameObject notTamed;

    // inventory controller
    private InventoryControls _controller;

    private void Awake()
    {
        _controller = transform.parent.GetComponent<InventoryControls>();    
    }

    private void FixedUpdate()
    {
        MoveToItem();
    }

    // moves entity to taming item if nearby
    private void MoveToItem()
    {
        // if object is not being controlled by player
        if (!transform.parent.GetComponent<ParentControls>().CheckControl())
        {
            // check for taming item in distance 4 * radius
            Collider[] items = Physics.OverlapSphere(transform.position, radius * 4);

            foreach (Collider col in items)
            {

                Vector3 colPosition = new Vector3(col.transform.position.x, gameObject.transform.parent.position.y, col.transform.position.z);

                // make entity go to item if it is nearby until it is within a certain distance
                if (col.gameObject == tamingItem && Vector3.Distance(gameObject.transform.parent.position, colPosition) > 0.9 * radius)
                {
                    gameObject.transform.parent.LookAt(colPosition);
                    gameObject.transform.parent.position = Vector3.MoveTowards(gameObject.transform.parent.position, colPosition, moveSpeed * Time.deltaTime);
                }
            }
        }
    }

    // checks if the object is tamed
    public bool CheckTame()
    {
        // gets objects in radius
        Collider[] items = Physics.OverlapSphere(transform.position, radius);
        
        // if an object is the one nearby return true
        foreach (Collider col in items)
        {
            if (col.gameObject == tamingItem)
            {
                // make certain orbs glow to show it is tamed
                notTamed.SetActive(false);
                tamed.SetActive(true);
                return true;
            }
        }

        if(_controller.ItemExists(tamingItem))
        {
            notTamed.SetActive(false);
            tamed.SetActive(true);
            return true;
        }

        // make certain orbs glow to show not tamed
        tamed.SetActive(false);
        notTamed.SetActive(true);
        return false;
    }

    private void Update()
    {
        CheckTame();
    }


}
