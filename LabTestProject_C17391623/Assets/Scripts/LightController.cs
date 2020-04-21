using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Renderer myRend;
    public State[] states;
    public class GreenState : State
    {
        Color green = Color.green;
        Renderer myRend;
        public override void Enter()
        {
            myRend = owner.GetComponent<LightController>().myRend;
            myRend.material.color = green;
        }
        public override void Execute()
        {
                owner.ChangeState(new YellowState());
        }
        public override void Exit()
        {
            
        }
    }
    public class YellowState : State
    {
        Color yellow = Color.yellow;
        Renderer myRend;
        public override void Enter()
        {
            myRend = owner.GetComponent<LightController>().myRend;
            myRend.material.color = yellow;
        }
        public override void Execute()
        {
            owner.ChangeState(new RedState());
        }
        public override void Exit()
        {
           
        }
    }
    public class RedState : State
    {
        Color red = Color.red;
        Renderer myRend;
        public override void Enter()
        {
            myRend = owner.GetComponent<LightController>().myRend;
            myRend.material.color = red;
        }
        public override void Execute()
        {
                owner.ChangeState(new GreenState());
        }
        public override void Exit()
        {

        }
    }
    private int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 9);
        if (randomNum < 3)
        {
            GetComponent<LightStateMachine>().ChangeState(new GreenState());
        }
        else if(randomNum >= 3 && randomNum <= 6)
        {
            GetComponent<LightStateMachine>().ChangeState(new YellowState());
        }
        else if (randomNum > 6 && randomNum <= 9)
        {
            GetComponent<LightStateMachine>().ChangeState(new RedState());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}