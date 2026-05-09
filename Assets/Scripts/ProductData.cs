using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product Data", menuName = "Retail/Product Data")]
public class ProductData : ScriptableObject
{
    public string productName;
    public int price;
    public float weight;
}
