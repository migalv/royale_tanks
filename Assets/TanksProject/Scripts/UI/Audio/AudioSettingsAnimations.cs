using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsAnimations : MonoBehaviour {

    // GUIAnimFREE objects for the Audio Settings Menu
    public GUIAnimFREE a_audioSettings;

    public void showAudioSettings()
    {
        a_audioSettings.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }
    public void hideAudioSettings()
    {
        a_audioSettings.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }
}
