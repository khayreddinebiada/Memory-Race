using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInputs : MonoBehaviour {

    public float minMovingTouch = 5;

    private Vector3 touchPosInit;
    private Player player;


	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        InputsManager();
    }

    void InputsManager()
    {

        float currentTouch = Mathf.Abs(minMovingTouch * Screen.width / 100);

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            touchPosInit = Input.mousePosition;
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (touchPosInit.x > Input.mousePosition.x && Mathf.Abs(touchPosInit.x - Input.mousePosition.x) > currentTouch)
            {
                if (!player.isLoss && Player.player.isMove) player.moveDirection = Player.MoveDirection.Left;
                player.RemoveHowToPlay();
            }

            if (touchPosInit.x < Input.mousePosition.x && Mathf.Abs(touchPosInit.x - Input.mousePosition.x) > currentTouch && !player.isShowHowToPlay)
            {
                if (!player.isLoss && Player.player.isMove) player.moveDirection = Player.MoveDirection.Right;
            }
        }

#elif UNITY_ANDROID

            if (0 < Input.touchCount)
            {
                foreach (Touch touch in Input.touches)
                {

                    if (touch.phase == TouchPhase.Began)
                    {
                        touchPosInit = touch.position;
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        if (touchPosInit.x > touch.position.x && Mathf.Abs(touchPosInit.x - touch.position.x) > currentTouch)
                        {
                            if (!player.isLoss && Player.player.isMove) player.moveDirection = Player.MoveDirection.Left;
                            player.RemoveHowToPlay();
                        }

                        if (touchPosInit.x < touch.position.x && Mathf.Abs(touchPosInit.x - touch.position.x) > currentTouch && !player.isShowHowToPlay)
                        {
                            if (!player.isLoss && Player.player.isMove) player.moveDirection = Player.MoveDirection.Right;
                        }
                    }

                }
            }

#endif
    }
}
