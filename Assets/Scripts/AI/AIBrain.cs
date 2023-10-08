using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// the AI brain is responsible from going from one state to the other based on the defined transitions. It's basically just a collection of states, and it's where you'll link all the actions, decisions, states and transitions together.
/// </summary>
public class AIBrain : MonoBehaviour
{
    /// the collection of states
    public List<AIState> States;
    /// whether or not this brain is active
    public bool BrainActive = true;
    /// this brain's current state
    public AIState CurrentState { get; protected set; }
    /// the time we've spent in the current state
    public float TimeInThisState;
    /// the current target
    public Transform Target;

    protected AIDecision[] _decisions;

    /// <summary>
    /// On awake we set our brain for all states
    /// </summary>
    protected virtual void Awake()
    {
        foreach (AIState state in States)
        {
            state.SetBrain(this);
        }
        _decisions = this.gameObject.GetComponents<AIDecision>();
    }

    /// <summary>
    /// On Start we set our first state
    /// </summary>
    protected virtual void Start()
    {
        if (States.Count > 0)
        {
            CurrentState = States[0];
        }
    }

    /// <summary>
    /// Every frame we update our current state
    /// </summary>
    protected virtual void Update()
    {
        if (!BrainActive || CurrentState == null)
        {
            return;
        }
        CurrentState.UpdateState();
        TimeInThisState += Time.deltaTime;
    }

    /// <summary>
    /// Transitions to the specified state, trigger exit and enter states events
    /// </summary>
    /// <param name="newStateName"></param>
    public virtual void TransitionToState(string newStateName)
    {
        if (newStateName != CurrentState.StateName)
        {
            CurrentState.ExitState();
            OnExitState();

            CurrentState = FindState(newStateName);
            if (CurrentState != null)
            {
                CurrentState.EnterState();
            }
        }
    }

    /// <summary>
    /// When exiting a state we reset our time counter
    /// </summary>
    protected virtual void OnExitState()
    {
        TimeInThisState = 0f;
    }

    /// <summary>
    /// Initializes all decisions
    /// </summary>
    protected virtual void InitializeDecisions()
    {
        foreach (AIDecision decision in _decisions)
        {
            decision.Initialization();
        }
    }

    /// <summary>
    /// Returns a state based on the specified state name
    /// </summary>
    /// <param name="stateName"></param>
    /// <returns></returns>
    protected AIState FindState(string stateName)
    {
        foreach (AIState state in States)
        {
            if (state.StateName == stateName)
            {
                return state;
            }
        }
        Debug.LogError("You're trying to transition to state '" + stateName + "' in " + this.gameObject.name + "'s AI Brain, but no state of this name exists. Make sure your states are named properly, and that your transitions states match existing states.");
        return null;
    }

    /// <summary>
    /// Restarts the brain from the first state.
    /// </summary>
    public virtual void RestartBrain()
    {
        if (States.Count > 0)
        {
            CurrentState = States[0];
        }
    }
}
