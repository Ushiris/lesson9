using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    GameObject sword;
    public float swipe_speed = 3.0f;
    public float move_speed = 3.0f;//cm par second

    enum MoveInput
    {
        up,
        down,
        right,
        left
    }

    // Start is called before the first frame update
    void Start()
    {
        sword = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        List<MoveInput> input = input_move();
        Move(input);

        swipe();
    }

    void swipe()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 target = ray.GetPoint(5.0f);

            sword.transform.LookAt(target);
        }
    }

    List<MoveInput> input_move()
    {
        List<MoveInput> input_buff = new List<MoveInput>();
        if (Input.GetKey("up"))
        {
            input_buff.Add(MoveInput.up);
        }
        if(Input.GetKey("down"))
        {
            input_buff.Add(MoveInput.down);
        }
        if (Input.GetKey("left"))
        {
            input_buff.Add(MoveInput.left);
        }
        if (Input.GetKey("right"))
        {
            input_buff.Add(MoveInput.right);
        }
        
        return input_buff;
    }

    void Move(List<MoveInput> inputs)
    {
        Vector3 move_vec = Vector3.zero;
        foreach(var a in inputs)
        {
            switch (a)
            {
                case MoveInput.up:
                    move_vec += new Vector3(0, 0, move_speed / 100);
                    break;
                case MoveInput.down:
                    move_vec += new Vector3(0, 0, -move_speed / 100);
                    break;
                case MoveInput.right:
                    move_vec += new Vector3(move_speed / 100, 0, 0);
                    break;
                case MoveInput.left:
                    move_vec += new Vector3(-move_speed / 100, 0, 0);
                    break;
                default:
                    break;
            }
        }

        transform.position += move_vec;
    }
}
