using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsMainMenu : MonoBehaviour {

    // ########################################
    // Variables
    // ########################################
    #region Variables

    // GUIAnimFREE objects for the main menu 
    public GUIAnimFREE m_playBtn;
    public GUIAnimFREE m_optionsBtn;
    public GUIAnimFREE m_quitBtn;

    // GUIAnimFREE objects for the options menu
    public GUIAnimFREE m_optionsHeader;
    public GUIAnimFREE m_audioBtn;
    public GUIAnimFREE m_videoBtn;
    public GUIAnimFREE m_controlsBtn;
    public GUIAnimFREE m_backBtn;

    // GUIAnimFREE objects for the Audio Settings Menu
    public GUIAnimFREE a_audioHeader;
    public GUIAnimFREE a_audioSettingsBg;
    public GUIAnimFREE a_backBtn;

    #endregion // Variables

    // ########################################
    // MonoBehaviour Functions
    // http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    // ########################################
    #region MonoBehaviour

    // Awake is called when the script instance is being loaded.
    // http://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    void Awake()
    {
        if (enabled)
        {
            // Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false in Awake() will let you control all GUI Animator elements in the scene via scripts.
            GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
        }
    }

    // Use this for initialization
    private void Start () {
        showMainMenu();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion // MonoBehaviour

    public void showMainMenu()
    {
        StartCoroutine(DisableAllButtonsForSeconds(1.6f));
        // MoveIn the 3 buttons on the right
        m_playBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_optionsBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_quitBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }

    public void hideMainMenu()
    {
        StartCoroutine(DisableAllButtonsForSeconds(1.6f));
        // MoveOut the 3 buttons on the right
        m_playBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_optionsBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_quitBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }

    public void showOptionsMenu()
    {
        StartCoroutine(DisableAllButtonsForSeconds(1.6f));
        // MoveIn the 5 components of the options menu
        m_optionsHeader.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_audioBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_videoBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_controlsBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_backBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }

    public void hideOptionsMenu()
    {
        StartCoroutine(DisableAllButtonsForSeconds(1.6f));
        // MoveIn the 5 components of the options menu
        m_optionsHeader.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_audioBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_videoBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_controlsBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_backBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }
    public void showAudioSettings()
    {
        StartCoroutine(DisableAllButtonsForSeconds(1f));
        // MoveIn the 3 components of the audio menu
        a_audioHeader.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        a_audioSettingsBg.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        a_backBtn.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }
    public void hideAudioSettings()
    {
        StartCoroutine(DisableAllButtonsForSeconds(1f));
        // MoveIn the 5 components of the audio menu
        a_audioHeader.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        a_audioSettingsBg.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        a_backBtn.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }

    // Disable a button 
    public void disableButton(GameObject GO)
    {
        GUIAnimSystemFREE.Instance.EnableButton(GO.transform, false);
    }

    // Enable a button 
    public void enableButton(GameObject GO)
    {
        GUIAnimSystemFREE.Instance.EnableButton(GO.transform, true);
    }

    // Disable all buttons for a few seconds
    IEnumerator DisableAllButtonsForSeconds(float DisableTime)
    {
        // Disable all buttons
        GUIAnimSystemFREE.Instance.EnableAllButtons(false);

        yield return new WaitForSeconds(DisableTime);

        // Enable all buttons
        GUIAnimSystemFREE.Instance.EnableAllButtons(true);
    }
}
