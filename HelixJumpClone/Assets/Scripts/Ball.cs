using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     Rigidbody rb;
    [SerializeField] float jumpForce=150f;
    [SerializeField] GameObject splitPrefab;
    AudioManager aa;
    void Start()
    {
       aa= FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce*Time.deltaTime,rb.velocity.z);
        //rb.AddForce(Vector3.up * jumpForce);
        aa.Play("Land");

        GameObject newSplit = Instantiate(splitPrefab, new Vector3(transform.position.x, collision.transform.position.y,transform.position.z),
            transform.rotation);
        newSplit.transform.localScale = Vector3.one * Random.Range(0.8f,1.2f);
        newSplit.transform.parent = collision.transform;

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        

        if (materialName == "Safe (Instance)")
        {
           // Debug.Log("you are safe");
        }
        if (materialName == "UnSafe (Instance)")
        {
            GameManager.gameOver =true;
            aa.Play("GameOver");
        }
        if (materialName =="LastRing (Instance)" && !GameManager.levelWin)
        {
            GameManager.levelWin = true;
            aa.Play("LevelWin");
        }


    }
}
