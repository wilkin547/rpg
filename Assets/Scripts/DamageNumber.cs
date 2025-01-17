﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float damageTextSpeed;
    public float damagePoints;

    public Text damageText;
    
    void Update()
    {
        damageText.text = damagePoints.ToString();
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + damageTextSpeed * Time.deltaTime, this.transform.position.z);
    }
}