using Assets;
using UnityEngine;

public class RocketLaunchBtn : Interactable
{
    public GameObject Target;
    public Material GreenMat;
    public Material RedMat;
    public GameObject rocket;

    private bool interacted = false;

    public void HandleInteraction()
    {
        //Logic for interaction
        //Launch rocket
        if (!interacted)
        {
            GetComponent<Renderer>().material = GreenMat;
            Target.gameObject.SetActive(true);
            //trigger rocket movement
            rocket.GetComponent<MoveRocket>().AllowMovement();
            interacted = true;
        }
    }
    public override void Interact()
    {
        //Trigger from raycast
        HandleInteraction();
    }
}
