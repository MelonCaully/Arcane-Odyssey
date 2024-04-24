using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu state that show Menu view and add interpret user interaction with that view.
/// </summary>
public class MenuState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.MenuView.OnStartClicked += StartClicked;
        owner.UI.MenuView.OnQuitClicked += QuitClicked;
        owner.UI.MenuView.OnSettingsClicked += SettingsClicked;
        // Show menu view
        owner.UI.MenuView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide menu view
        owner.UI.MenuView.HideView();

        // Detach functions from view events
        owner.UI.MenuView.OnStartClicked -= StartClicked;
        owner.UI.MenuView.OnQuitClicked -= QuitClicked;
        owner.UI.MenuView.OnSettingsClicked -= SettingsClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Start button is clicked in Menu view.
    /// </summary>

    private void StartClicked()
    {
        SceneManager.LoadScene("Level 1");
    }
    private void SettingsClicked()
    {
        owner.ChangeState(new SettingsState());
    }
    /// <summary>
    /// Function called when Quit button is clicked in Menu view.
    /// </summary>
    private void QuitClicked()
    {
        Debug.Log("hi");
        Application.Quit();
    }

}