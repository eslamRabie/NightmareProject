﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouseClick : MonoBehaviour
{
    [SerializeField]
    int mouseButtonIndex;
    [SerializeField]
    Color color;

    Ray ray;
    RaycastHit hit;
    int walkableLayerMask;

    private void Start()
    {
        walkableLayerMask = LayerMask.NameToLayer("Walkable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(mouseButtonIndex))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.layer == walkableLayerMask)
                    transform.position = hit.point;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
