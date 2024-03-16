using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State
    public IdleState idleState { get; private set; }
    public LeftThrowState leftThrowState { get; private set; }
    public RightThrowState rightThrowState { get; private set; }
    #endregion
    public StateMachine stateMachine { get; private set; }
    public Animator anim { get; private set; }

    public bool isInJumpTile { get; private set; }
    private void Awake()
    {
        stateMachine = new StateMachine();
        anim = GetComponent<Animator>();

        idleState = new IdleState(this, "Idle");
        leftThrowState = new LeftThrowState(this, "ThrowLeft");
        rightThrowState = new RightThrowState(this, "ThrowRight");
    }
    void Start()
    {
        stateMachine.InitState(idleState);
    }
    private void Update()
    {
        stateMachine.currentState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            isInJumpTile = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            isInJumpTile = false;
        }
    }

}
