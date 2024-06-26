﻿using UnityEngine;

/// <summary>
/// UI Root class, used for storing references to UI views.
/// </summary>
public class UIRoot : MonoBehaviour
{
    [SerializeField]
    private MenuView menuView;
    public MenuView MenuView => menuView;

    [SerializeField]
    private SettingsView settingsView;
    public SettingsView SettingsView => settingsView;

}
