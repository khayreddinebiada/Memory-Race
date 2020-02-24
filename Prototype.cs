using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype : MonoBehaviour {

    public GameObject leftBarrier;
    public GameObject rightBarrier;
    public GameObject instantPrototype;

    public Player.MoveDirection moveDirection;

    public static GameObject prevRightPrototype;
    public static GameObject prevLeftPrototype;

    public static GameObject currentRightPrototype;
    public static GameObject currentLeftPrototype;

    private static int currentPathIndex;


	// Use this for initialization
    void Start()
    {
        leftBarrier.SetActive(false);
        rightBarrier.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {

            if (prevLeftPrototype)
                Destroy(prevLeftPrototype);

            if (prevRightPrototype)
                Destroy(prevRightPrototype);

            prevLeftPrototype = currentLeftPrototype;
            prevRightPrototype = currentRightPrototype;

            currentRightPrototype = Instantiate(instantPrototype, transform.position + transform.right * 80, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 90, 0)));
            currentLeftPrototype = Instantiate(instantPrototype, transform.position - transform.right * 80, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, -90, 0)));

            currentRightPrototype.GetComponent<Prototype>().moveDirection = rightPath[currentPathIndex];
            currentLeftPrototype.GetComponent<Prototype>().moveDirection = rightPath[currentPathIndex];

            Player.player.AddScore();

            currentPathIndex++;
            if (currentPathIndex == rightPath.Length)
                currentPathIndex = 0;

            if (moveDirection == Player.MoveDirection.Left)
            {
                rightBarrier.SetActive(true);
            }
            else
            {
                leftBarrier.SetActive(true);
            }

        }
    }

    public static Player.MoveDirection[] rightPath = new Player.MoveDirection[]
        {
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right,
            Player.MoveDirection.Right,
            Player.MoveDirection.Left,
            Player.MoveDirection.Right
        };
}
