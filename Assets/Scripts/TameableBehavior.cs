using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TameableBehavior : MonoBehaviour
{
    [SerializeField] private float radius;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject tamingItem;

    [SerializeField] private GameObject tamed;

    [SerializeField] private GameObject notTamed;

    private void FixedUpdate()
    {
        if(!transform.parent.GetComponent<ParentControls>().CheckControl())
        {
            Collider[] items = Physics.OverlapSphere(transform.position, radius * 4);

            foreach (Collider col in items)
            {
                if (col.gameObject == tamingItem && Vector3.Distance(gameObject.transform.parent.position, col.transform.position) > 0.9*radius)
                {
                    gameObject.transform.parent.LookAt(col.transform.position);
                    gameObject.transform.parent.position = Vector3.MoveTowards(gameObject.transform.parent.position, col.transform.position, moveSpeed * Time.deltaTime);
                }
            }
        }  
    }

    public bool CheckTame()
    {
        Collider[] items = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in items)
        {
            if (col.gameObject == tamingItem)
            {
                notTamed.SetActive(false);
                tamed.SetActive(true);
                return true;
            }
        }
        tamed.SetActive(false);
        notTamed.SetActive(true);
        return false;
    }

    private void Update()
    {
        CheckTame();
    }


}
