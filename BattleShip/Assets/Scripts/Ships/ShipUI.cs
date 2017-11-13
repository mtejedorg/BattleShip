using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUI : MonoBehaviour {

    public GameObject selected;

    private void Start()
    {
        selected.SetActive(false);
    }

    public void ShipSelected(bool sel)
    {
        selected.SetActive(sel);
    }
}
