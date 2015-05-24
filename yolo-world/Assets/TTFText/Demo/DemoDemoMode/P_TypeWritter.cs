using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class P_TypeWritter : MonoBehaviour {
	// we make appear the letters one by one 
	TTFSubtext pt;
	public float minDelay=0.2f;
	public float maxDelay=2;
	public AudioClip auc;
	AudioSource aus;
	
	
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale=Vector3.zero;
		aus=GetComponent<AudioSource>();
		if (aus==null) {
			gameObject.AddComponent<AudioSource>();
			aus=GetComponent<AudioSource>();
		}
		pt=GetComponent<TTFSubtext>();
		if (pt.SequenceNo==0) {
			StartCoroutine("DisplayLetter");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public IEnumerator DisplayLetter() {
		//Debug.Log("display letter");
//		Debug.Log(pt.SequenceNo);
		transform.localScale=Vector3.one;
				
		if (auc!=null) {
			aus.clip=auc;
			aus.Play();
		}
		
		float t=Random.Range(minDelay,maxDelay);
		yield return new WaitForSeconds(t);
		
		foreach (Transform st in transform.parent) {
			TTFSubtext apt=st.GetComponent<TTFSubtext>();
			if (apt!=null) {
				// if token mode = character
				// check line no (if line no different also play)...
				// carriage return ...
				
				
				if (apt.SequenceNo==(pt.SequenceNo+1)) {		
					apt.SendMessage("DisplayLetter");
				}
			}
		}
	}
}
