using Assets;
using UnityEngine;

public class DoorBtn : Interactable
{
    public GameObject Target;
    public Material GreenMat;
    public Material RedMat;
    public GameObject NextTarget;
    public Material NextTargetMat;

    private bool interacted = false;
    private Material NextTargetOriginalMat;

    // Start is called before the first frame update
    void Start()
    {
        NextTargetOriginalMat = NextTarget.GetComponent<Renderer>().material;
    }

    public void HandleInteraction()
    {
        //Logic for interaction
        //open door if not already.
        if (!interacted)
        {
            GetComponent<Renderer>().material = GreenMat;
            NextTarget.GetComponent<Renderer>().material = NextTargetMat;
            Target.transform.eulerAngles = new Vector3(0, 90, 0);
            interacted = true;
        }
        else
        {
            //close door
            GetComponent<Renderer>().material = RedMat;
            NextTarget.GetComponent<Renderer>().material = NextTargetOriginalMat;
            Target.transform.eulerAngles = new Vector3(0, 0, 0);
            interacted = false;
        }
    }
    public override void Interact()
    {
        //Trigger from raycast
        HandleInteraction();
    }
}
