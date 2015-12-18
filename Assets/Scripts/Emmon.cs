using UnityEngine;

public class Emmon : MonoBehaviour
{
    public static Emmon Instance;

    public CharacterControllerLogic.WalkGround Ground = CharacterControllerLogic.WalkGround.None;

    public GameObject WaterRings = null;
    public GameObject InWaterGo;
    public bool InWater = false;

    public Areas CurrentArea;
    public Areas PreviousArea;

    public bool MovePlayer = false;
   // public bool RotatePlayerTowardsNPC = false;
    private Character _dialoguePartner;

    public void Awake()
    {
        Instance = this;

        Ground = CharacterControllerLogic.WalkGround.Dirt;

        SetWaterRings();
    }

    public void Update()
    {
        if(InWater)
        {
            WaterRings.transform.position = new Vector3(WaterRings.transform.position.x,
                InWaterGo.GetComponent<WaterBehaviour>().WaterLevel, 
                WaterRings.transform.position.z);
        }

        if(MovePlayer)
            MoveToDialoguePosition();

    }

    public void SetWaterRings()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Particle Effects")
            {
                GameObject waterRings = GameObject.Instantiate(Resources.Load("Prefabs/Particles/Water Rings") as GameObject);
                waterRings.transform.SetParent(child);
                waterRings.transform.position = child.position;
                WaterRings = waterRings;
                WaterRings.SetActive(false);
            }
        }
    }

    public void TriggerPlayerMove(Character NPC)
    {
        _dialoguePartner = NPC;
        MovePlayer = true;

    }

    public void MoveToDialoguePosition()
    {
        if(ThirdPersonCamera.Instance.PlayerDialoguePositions[_dialoguePartner] == null)
        {
            Debug.LogWarning("we have no player dialogue position for: " + _dialoguePartner);
            MovePlayer = false;
            return;
        }

        GameObject goal = ThirdPersonCamera.Instance.PlayerDialoguePositions[_dialoguePartner];
        Vector3 moveDir = goal.transform.position - Instance.transform.position;

        CharacterControllerLogic.Instance.ForwardSpeed = .2f;
        CharacterControllerLogic.Instance.ForceSpeed(1);

        // Rotate towards the target
        Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation, Quaternion.LookRotation(moveDir), 6 * Time.deltaTime);
        Instance.transform.eulerAngles = new Vector3(0, Instance.transform.eulerAngles.y, 0);

        // move towards the target
        Instance.transform.position = Vector3.MoveTowards(Instance.transform.position, new Vector3(goal.transform.position.x, Instance.transform.position.y ,goal.transform.position.z), Time.deltaTime * 1);
        var distance = Vector3.Distance(Instance.transform.position, goal.transform.position);

        // apply gravity during animation
        if (!CharacterControllerLogic.CharacterController.isGrounded)
            Instance.transform.position = new Vector3(Instance.transform.position.x, Instance.transform.position.y - 1f * Time.deltaTime, Instance.transform.position.z);

        if (distance < .2f)
        {
            ReachDialoguePosition();
        }
    }

    public void ReachDialoguePosition()
    {
        MovePlayer = false;
        CharacterControllerLogic.Instance.StopMoving();
        CharacterControllerLogic.Instance.ForwardSpeed = 2f;
        TimeManager.Instance.CreateRotator(Instance.transform, GameManager.NPCs[_dialoguePartner].transform, 6, 4);
    }
}
