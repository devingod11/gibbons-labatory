using System.Collections;
using UnityEngine;

public class JumpscareTeleportation : MonoBehaviour
{
    public Transform Player;
    public Transform RestartPos;
    public GameObject Monster;
    public GameObject Jumpscare;
    public GameObject Map;
    public float WaitTime;
    public float BeforeReenableTime;
    [Header("Add the tag for the jumpscare trigger here, or it'll be buggy asf.")]
    public string JumpscareTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(JumpscareTrigger))
        {
            StartCoroutine(EnableJumpscareOverlay());
        }
    }

    IEnumerator EnableJumpscareOverlay()
    {
        Monster.SetActive(false);
        Jumpscare.SetActive(true);
        yield return new WaitForSeconds(WaitTime);
        Map.SetActive(false);
		Player.position = RestartPos.position;
		Player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(BeforeReenableTime);
        Map.SetActive(true);
        
		yield return new WaitForSeconds(WaitTime);
		Jumpscare.SetActive(false);
        Monster.SetActive(true);

    }
    
    void Update()
    {
       
    }
}
