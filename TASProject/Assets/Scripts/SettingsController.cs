using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SettingsController object. This is where the currentSetting and settings variables exist.
//We should use this for any other settings management in the options scene
public class SettingsController {

    public string currentSetting { get; set; }
    public List<string> settings = new List<string>();

    public SettingsController()
    {
        settings.Add("scale");
        settings.Add("paintColour");
        settings.Add("outro");
        currentSetting = settings[0];
    }
}
