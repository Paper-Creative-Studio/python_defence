using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControllermovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController charactercontroller;
    [SerializeField] private float speed;
    private Vector3 move;
    private Vector2 input;
    private Vector2 smoothmove;
    private Vector2 smoothInputVelocity;
    [SerializeField] private float smoothing_speed;
    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        smoothmove = Vector2.SmoothDamp(smoothmove, input, ref smoothInputVelocity, smoothing_speed);

    }
    private void FixedUpdate()
    {
        charactercontroller.Move(smoothmove * speed);
    }
}
