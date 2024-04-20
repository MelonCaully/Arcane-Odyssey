using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState currentState;

    [SerializeField]
    private UIRoot ui;
    public UIRoot UI => ui;

    private void Start()
    {
        ChangeState(new MenuState());
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState newState)
    {

        if (currentState != null)
        {
            currentState.DestroyState();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }
}

