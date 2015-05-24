using UnityEngine;
using System.Collections;

public class DemoFree1Main : MonoBehaviour {
	
	public Transform target;
	public float h=17;
	public float r=20;
	public Vector3 up=Vector3.back;
	public GameObject to=null;
	public float hf=30;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t=Time.time;
		float xt=t-Mathf.Floor(t/18)*18;
		transform.localPosition=new Vector3(Mathf.Cos(t)*r,Mathf.Sin(t+(xt*xt))*r,-h);
		transform.LookAt(target,up);
		if (to!=null) {
			to.transform.localPosition=new Vector3(0,Mathf.Sin(3*t)*hf,Mathf.Cos(t));
			to.transform.localRotation=Quaternion.Euler(0,t*120,0);
		}
	}
}
