using Assets;
using UnityEngine;

public class RocketLaunchBtn : Interactable
{
    public GameObject Target;
    public Material GreenMat;
    public Material RedMat;

    private bool interacted = false;
    // Start is called before the first frame update
    void Start()
    {
        //Target.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void HandleInteraction()
    {
        //Logic for interaction
        //Launch rocket
        if (!interacted)
        {
            GetComponent<Renderer>().material = GreenMat;
            Target.gameObject.SetActive(true);
            interacted = true;
        }
        else
        {
            //stop rocket
            GetComponent<Renderer>().material = RedMat;
            Target.gameObject.SetActive(false);
            interacted = false;
        }
    }
    public override void Interact()
    {
        //Trigger from raycast
        HandleInteraction();
    }
}
