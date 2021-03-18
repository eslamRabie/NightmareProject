using System;
using System.Collections;
using System.Collections.Generic;
using MysteryBox;
using Players;
using UnityEngine;

public class KeyBox : MonoBehaviour, IMysteryBox
{
    [SerializeField] private GameObject _shape;
    

    public void Reveal()
    {
        _shape.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Reveal();
            other.gameObject.GetComponent<Player>().AcquireKey();
        }
    }
}
