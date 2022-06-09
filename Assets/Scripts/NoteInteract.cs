using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteract : Interact
{
    [SerializeField] private GameObject note;

    [SerializeField] private float maxTime;
    private float currentTime;
    private int modifier = -1;

    private void Start()
    {
        currentTime = maxTime;
    }

    public override void Interaction(GameObject obj)
    {
        Debug.Log(obj);
        Debug.Log("note interact");
        note.SetActive(true);
    }

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);

        if(currentTime > 0)
        {
            transform.position = transform.position + Vector3.down * Time.fixedDeltaTime/5 * modifier;
            currentTime--;
        }
        else
        {
            modifier *= -1;
            currentTime = maxTime;
        }

    }
}
