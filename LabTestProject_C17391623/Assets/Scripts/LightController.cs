using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Renderer myRend;
    public class GreenState:State
    {
        Color green = Color.green;
        Renderer myRend;
        public override void Enter()
        {
            myRend = owner.GetComponent<LightController>().myRend;
            myRend.material.color = green;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LightStateMachine>().ChangeState(new RedState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
