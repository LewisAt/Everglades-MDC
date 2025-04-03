using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles interaction popups and info display for animal objects.
/// </summary>
public class Infointraction : MonoBehaviour
{
    [TextArea(15, 20)] public string infoTodisplay;
    public UnityEngine.UI.Text textBoxToReveal;
    public GameObject canvasBase;
    public AudioSource interactAudio;
    public GameObject idlePrefab;
    public float canvasPopupHeight = 5f;

    private GameObject canvasParent;
    private Vector3 initalPositionInsideOfParent;
    private GameObject player;

    static GameObject thereCanOnlyBeOne;

    private void Awake()
    {
        canvasParent = canvasBase.transform.parent.gameObject;
        initalPositionInsideOfParent = canvasBase.transform.localPosition;
        canvasBase.SetActive(false);
        player = Camera.main.gameObject;
    }

    public void enableAll(AudioSource thisAudio = null)
    {
        if (thisAudio == null)
            thisAudio = interactAudio;

        FindObjectOfType<GamePlayDialog>()?.GetInteractAudio(thisAudio);

        if (canvasBase.activeSelf)
        {
            canvasBase.SetActive(false);
            canvasBase.transform.parent = canvasParent.transform;
            canvasBase.transform.localPosition = initalPositionInsideOfParent;
            return;
        }

        if (thereCanOnlyBeOne != null)
        {
            thereCanOnlyBeOne.SetActive(false);
            thereCanOnlyBeOne.transform.parent = thereCanOnlyBeOne.transform.parent.gameObject.transform;
            thereCanOnlyBeOne.transform.localPosition = thereCanOnlyBeOne.transform.localPosition;
        }

        thereCanOnlyBeOne = thisAudio.gameObject;

        // 🐾 STOP AI and switch to idle prefab
        AnimalAI ai = GetComponentInParent<AnimalAI>();
        if (ai != null)
        {
            ai.SwitchToIdle(idlePrefab);
        }

        canvasBase.transform.parent = null;
        canvasBase.transform.position = canvasParent.transform.position + new Vector3(0, canvasPopupHeight, 0);

        canvasBase.SetActive(true);
        textBoxToReveal.text = infoTodisplay;

        StartCoroutine(Disable());
    }

    private void FixedUpdate()
    {
        if (canvasBase.activeSelf)
            LockInfoPanel();
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(60);

        if (canvasBase.activeSelf)
        {
            canvasBase.SetActive(false);
            canvasBase.transform.parent = canvasParent.transform;
            canvasBase.transform.localPosition = initalPositionInsideOfParent;

            // 🐾 Resume AI movement
            AnimalAI ai = GetComponentInParent<AnimalAI>();
            if (ai != null)
            {
                ai.ResumeWalking();
            }
        }
    }

    private void LockInfoPanel()
    {
        if (!canvasBase.activeSelf)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(canvasBase.transform.position - player.transform.position, Vector3.up);
        canvasBase.transform.rotation = lookRotation;
    }
}