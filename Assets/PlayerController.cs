using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text startWinText;

    private Rigidbody rb;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        startWinText.text = " ";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moverVertical);

        rb.AddForce(movement * speed); 
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

            if (count >= 9)
            {
            startWinText.text = "Congratulations! You Win !";

            }
    }

}
