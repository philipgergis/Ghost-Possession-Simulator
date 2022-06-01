//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveToCheese : MonoBehaviour
//{
//    [SerializeField] private float moveSpeed = 5f;
//    [SerializeField] private CheeseTrigger cheeseTrigger;
//    private Vector3 target;
//    private Collider _collider;

//    private void Awake()
//    {
//        target = cheeseTrigger.transform.position;
//        _collider = GetComponent<Collider>();
//    }

//    private void FixedUpdate()
//    {
//        if (cheeseTrigger.GetStatus())
//        {
//            MoveMouse();
//            _collider.enabled = false;
//        } else
//        {
//            _collider.enabled = true;
//        }
//    }

//    private void MoveMouse()
//    {
//        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
//    }
//}
