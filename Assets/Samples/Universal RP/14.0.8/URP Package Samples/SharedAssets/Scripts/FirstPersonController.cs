using UnityEngine;
using Cursor = UnityEngine.Cursor;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float m_MouseSensitivity = 100f;
    [SerializeField] private float m_WalkSpeed = 5f;
    [SerializeField] private float m_RunSpeed = 10f;
    [SerializeField] private float m_Gravity = 8f;

    [SerializeField] private Transform m_PlayerCamera = null;
    [SerializeField] private bool m_MoveWithMouse = true;

    private CharacterController m_CharacterController;
    private float m_XRotation = 0f;
    private byte m_ButtonMovementFlags;

    //anim & sound variables
    public Animator playerAnims;
    public AudioSource playerSound;
    public AudioClip[] footstepClips;
    public float basePSoundPitch;
    public float basePSoundVolume;

    // 🔹 Animal Call System Variables
    public AnimalAI[] animals; // Assign all 8 animal objects here
    public GameObject spawnMarkerPrefab; // Assign the circular spawn marker prefab
    private GameObject currentSpawnMarker;
    private int selectedAnimalIndex = -1;
    private bool isHoldingKey = false;


    void Start()
    {
        if (m_MoveWithMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Look();
        Move();
        HandleAnimalCall(); // 🔹 Add the call system to the Update function
    }

    private void Look()
    {
        Vector2 lookInput = GetLookInput();
        m_XRotation -= lookInput.y;
        m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

        m_PlayerCamera.localRotation = Quaternion.Euler(m_XRotation, 0, 0);
        transform.Rotate(Vector3.up * lookInput.x, Space.World);
    }

    private void Move()
    {
        Vector3 movementInput = GetMovementInput();
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.z;

        //add gravity
        if (!m_CharacterController.isGrounded)
        {
            move.y -= m_Gravity * Time.deltaTime;
        }

        //shift to run
        if (Input.GetKey(KeyCode.LeftShift))
        {//apply run speed
            m_CharacterController.Move(move * m_RunSpeed * Time.deltaTime);
        }
        else
        {//or apply walk speed
            m_CharacterController.Move(move * m_WalkSpeed * Time.deltaTime);
        }
    }

    private Vector2 GetLookInput()
    {
        float mouseX = 0;
        float mouseY = 0;
        if (m_MoveWithMouse)
        {
            mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;
        }
        return new Vector2(mouseX, mouseY);
    }

    private Vector3 GetMovementInput()
    {
        float x = 0;
        float z = 0;
        if (m_MoveWithMouse)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        //set animation
        if (x != 0 || z != 0)
        {
            playerAnims.SetBool("IsWalking", true); 
        }
        else
        {
            playerAnims.SetBool("IsWalking", false);
        }
        return new Vector3(x, 0, z);
    }

    //method to pick a footstep sound and add variation to it at runtime
    public void FootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            //pick a random footstep sound
            playerSound.clip = footstepClips[Random.Range(0, footstepClips.Length)];
            //adjust volume and pitch just slightly
            playerSound.pitch = basePSoundPitch + Random.Range(-0.1f, 0.1f);
            playerSound.volume = basePSoundVolume + Random.Range(0, -0.5f);

            playerSound.Play();
        }
    }

    // 🔹 Animal Call System (Integrated)
    private void HandleAnimalCall()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) // Detect key press (1-8)
            {
                selectedAnimalIndex = i;
                isHoldingKey = true;
                ShowSpawnMarker();
            }
            if (Input.GetKeyUp(KeyCode.Alpha1 + i)) // Detect key release
            {
                isHoldingKey = false;
                SummonAnimal();
            }
        }

        if (isHoldingKey && currentSpawnMarker != null)
        {
            UpdateSpawnMarker();
        }
    }

    private void ShowSpawnMarker()
    {
        if (currentSpawnMarker == null)
        {
            currentSpawnMarker = Instantiate(spawnMarkerPrefab);
        }
        UpdateSpawnMarker();
    }

    private void UpdateSpawnMarker()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            currentSpawnMarker.transform.position = hit.point + new Vector3(0, 0.1f, 0);
        }
    }

    private void SummonAnimal()
    {
        if (selectedAnimalIndex < 0 || selectedAnimalIndex >= animals.Length) return;

        AnimalAI selectedAnimal = animals[selectedAnimalIndex];
        selectedAnimal.transform.position = currentSpawnMarker.transform.position;
        selectedAnimal.MoveToPlayer(transform.position + transform.forward * 2); // Moves animal in front of the player

        Destroy(currentSpawnMarker);
        selectedAnimalIndex = -1;
    }
}
