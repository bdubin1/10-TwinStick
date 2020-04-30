using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour {
    private myGameManager manager;
    private const int bufferFrames=100;
    private MKeyFrame[] keyFrames=new MKeyFrame[bufferFrames];
    private Rigidbody myRigidbody;


	// Use this for initialization
	void Start () {
        manager = GameObject.FindObjectOfType<myGameManager>();
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (manager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
        
    }
    public void PlayBack()
    {
        //Debug.Log("in playback mode");
        //code moves objects without physics engine
        myRigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
    public void Record()
    {
        //Debug.Log("in record mode");
        //Physics engine moves objects
        myRigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrames[frame] = new MKeyFrame(time, transform.position, transform.rotation);
    }
}
/// <summary>
/// A structure for storing time, rotation and position
/// </summary>
public struct MKeyFrame {
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MKeyFrame(float tm, Vector3 pos, Quaternion rot)
    {
        frameTime = tm;
        position = pos;
        rotation = rot;
    }
}
