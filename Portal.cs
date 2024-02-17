using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using RPG.SceneManagement;
using UnityEngine.InputSystem;

public class Portal : MonoBehaviour, IInteractable
{

    bool transitionStart = false;

    enum DestinationIdentifier
    {
        DowntownRight, HomeStreetLeft
    }

    [SerializeField] int sceneToLoad = 1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIdentifier startPoint;
    [SerializeField] DestinationIdentifier destination;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //InputReader playerInput = player.GetComponent<InputReader>();
        //playerInput.InteractEvent += StartTransition;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")

    //    {
            
    //    }
    //}

    void StartTransition()
    {
        if (!transitionStart)
        {
            transitionStart = true;
            StartCoroutine(Transition());
            //playerInput.InteractEvent -= StartTransition
        }
    }

    IEnumerator Transition()
    {
        
        DontDestroyOnLoad(gameObject);

        //SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
        //wrapper.AutoSave();

        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        //wrapper.AutoLoad();

        Portal otherPortal = GetOtherPortal();
        UpdatePlayer(otherPortal);
        player.GetComponent<PlayerStateMachine>().ClearInteractableObject();
        Destroy(gameObject);

    }


    private void UpdatePlayer(Portal otherPortal)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = otherPortal.spawnPoint.position;
        player.GetComponent<CharacterController>().enabled = true;
        transitionStart = false;
        
    }

    private Portal GetOtherPortal()
    {
        Debug.Log("Interacted with portal");
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this) continue;
            if (portal.startPoint != destination) continue;

            return portal;
        }

        return null;
    }

    public void Interact()
    {
        StartTransition();
    }
}
