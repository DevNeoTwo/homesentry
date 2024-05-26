using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSelector : MonoBehaviour {

    public void SoloMode() {
        PlayerPrefs.SetString("gamemode", "solo");
        fadescreen.instance.hacefade();
    }

    public void VsMode() {
        PlayerPrefs.SetString("gamemode", "vs");
        fadescreen.instance.hacefade();
    }
}
