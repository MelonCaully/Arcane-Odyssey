using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsState : BaseState
{ 

public override void PrepareState()
    {
    base.PrepareState();

    owner.UI.SettingsView.OnQuitClicked += QuitClicked;

    owner.UI.SettingsView.ShowView();
    }

public override void DestroyState()
    {
    // Hide Settings view
    owner.UI.SettingsView.HideView();

    // Settings functions removed
    owner.UI.MenuView.OnQuitClicked -= QuitClicked;

    base.DestroyState();
    }


    private void QuitClicked()
    {
        owner.ChangeState(new MenuState());
    }
}
