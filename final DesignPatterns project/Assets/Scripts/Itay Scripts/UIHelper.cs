using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ES.InteractionSys;

public class UIHelper : MonoBehaviour
{
    [SerializeField] Canvas playerCanvas;
    [SerializeField] private GameObject btnPref;

    // Start is called before the first frame update
    void Start()
    {
        playerCanvas = GetComponentInChildren<Canvas>();
        playerCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu(InteractableObject target){
        if (!playerCanvas.gameObject.activeSelf) {
            GameManager.player.myView.ToggleLock();
            BuildMenu(target);
            playerCanvas.gameObject.SetActive(true);
            playerCanvas.transform.rotation = Quaternion.identity;
            playerCanvas.transform.localScale = Vector3.one;
        }
    }

    public void CloseMenu(){
        GameManager.player.myView.ToggleLock();
        Button[] btns = playerCanvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < btns.Length; i++){
            Destroy(btns[i].gameObject);
        }
        playerCanvas.gameObject.SetActive(false);
    }

    void BuildMenu(InteractableObject target){
        
        if (target is iLookable _l){
            CreateButton("Look", _l.GetLookedAt);
        }
        if (target is iTouchable _t) {
            CreateButton("Touch", _t.GetTouched);

        }
        if (target is iPickable _p) {
            CreateButton("Look", _p.GetPicked);
        }
    }

    void CreateButton(string text, UnityEngine.Events.UnityAction action) {
        GameObject buttonObj = (GameObject)Instantiate(btnPref);
        buttonObj.transform.SetParent(playerCanvas.transform);
        buttonObj.GetComponentInChildren<Text>().text = text;
        Button button = buttonObj.GetComponent<Button>();
        button.onClick.AddListener(action);
        button.onClick.AddListener(CloseMenu);
        /*
        Button b = playerCanvas.gameObject.AddComponent<Button>();
        b.gameObject.AddComponent<Text>().text = text;
        b.onClick.AddListener(action);
        */
    }
}
