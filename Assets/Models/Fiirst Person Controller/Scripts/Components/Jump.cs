using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    private bool canJump= true;
    [SerializeField] private int jumpWaitTime;

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Jump when the Jump button is pressed
        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump=false;
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
            StartCoroutine("ResetJump");
        }
    }

        IEnumerator ResetJump(){
        yield return new WaitForSeconds(jumpWaitTime);
        canJump= true;
    }
}
