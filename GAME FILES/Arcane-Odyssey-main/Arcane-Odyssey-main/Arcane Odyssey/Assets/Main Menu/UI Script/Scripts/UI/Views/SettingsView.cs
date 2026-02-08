using UnityEngine;
using UnityEngine.Events;

public class SettingsView : BaseView
{
  public UnityAction OnQuitClicked;


    public void QuitClick()
    {
        OnQuitClicked?.Invoke();
    }
}
