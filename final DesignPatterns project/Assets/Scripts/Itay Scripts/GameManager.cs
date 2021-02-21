using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES.InteractionSys;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    static public InputManager inputManager;
    static public InteractionManager interactionManager;
    static public UIHelper uIHelper;
    static public Player player {get; private set;}



    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.inputManager = GetComponent<InputManager>();
        GameManager.interactionManager = GetComponent<InteractionManager>();
        GameManager.uIHelper = GetComponent<UIHelper>();
    }

    private void OnEnable() {
        player = FindObjectOfType<Player>();
    }
}
