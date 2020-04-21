using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public LightStateMachine owner;
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Execute() { }
}
public class LightStateMachine : MonoBehaviour
{
    public State currentState;
    public State prevState;
    private void OnEnable()
    {
        StartCoroutine(Execute());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(State newState)
    {
        prevState = currentState;
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.owner = this;
        currentState.Enter();
    }
    IEnumerator Execute()
    {
        yield return new WaitForSeconds(Random.Range(5f,10f));
        while(true)
        {
            if(currentState != null)
            {
                currentState.Execute();
            }
            yield return new WaitForSeconds(Random.Range(5f,10f));
        }
    }
}
