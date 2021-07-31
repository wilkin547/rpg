using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue;
    private GemsManager gemsManager;

    void Start()
    {
        gemsManager = FindObjectOfType<GemsManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gemsManager.AddGems(gemValue);
            Destroy(gameObject);
        }
    }
}