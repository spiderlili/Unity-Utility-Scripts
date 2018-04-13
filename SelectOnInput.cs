//detect user input on menu selection

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;

    //has the player made a selection
    private bool buttonSelected;

    //check has the player sent some input from a keyboard or from a controller on every frame

	void Update () {

        //if some movement was detected on the vertical axis(gamepad/keyboard)
  
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false) {

            //set the selected game object of event system

            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
	}

    //when the global game object is deactivated
    private void OnDisable()
    {
        buttonSelected = false;
    }
}
