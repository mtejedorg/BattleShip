using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour {

    public enum Actions { Press, Drag, Hold, Release }
    public Actions input;

    public const string Press = "Fire1";

    private Camera cam;
    private Ray mousePositionRay;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag(Tags.MAINCAMERA).GetComponent<Camera>(); ;
    }

    void Update () {

        mousePositionRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject gameObjectHit;
        if (Physics.Raycast(mousePositionRay, out hit, Mathf.Infinity))
        {
            gameObjectHit = hit.transform.gameObject;

            if (Input.GetButtonDown(Press))
            {
                if (gameObjectHit.layer == Layers.SHIP)
                    SelectShip(gameObjectHit);
                else if (gameObjectHit.layer == Layers.WATER)
                    print("Seleccionado agua");
                else
                    print("Seleccionado nada");
            }
        }
	}

    private void SelectShip(GameObject ship)
    {
        print("Seleccionado barco");
        GameObject [] ships = GameObject.FindGameObjectsWithTag(Tags.SHIP);
        foreach(GameObject sh in ships)
        {
            if(sh != ship)
                ship.SendMessage("ShipSelected", false);
            else
                ship.SendMessage("ShipSelected", true);
        }
    }
}