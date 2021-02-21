using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ES.InteractionSys;

public class UIHelper : MonoBehaviour
{
    [SerializeField] Canvas playerCanvas;
    [SerializeField] GridLayoutGroup muhGrid;
    [SerializeField] Text muhText;
    [SerializeField] private GameObject btnPref;

    // Start is called before the first frame update
    void Start()
    {
        playerCanvas = GetComponentInChildren<Canvas>();
        muhGrid = playerCanvas.GetComponent<GridLayoutGroup>();
        muhText = playerCanvas.GetComponentInChildren<Text>();
        muhGrid.enabled = muhText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu(InteractableObject target){
            GameManager.player.myView.ToggleLock();
            muhGrid.enabled = true;
            BuildMenu(target);
            playerCanvas.transform.rotation = Quaternion.identity;
            playerCanvas.transform.localScale = Vector3.one;
    }

    public void CloseMenu(){
        GameManager.player.myView.ToggleLock();
        Button[] btns = playerCanvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < btns.Length; i++){
            Destroy(btns[i].gameObject);
        }
        muhGrid.enabled = false;
    }

    void BuildMenu(InteractableObject target){
        
        if (target is iLookable _l){
            CreateButton("Look", _l.GetLookedAt);
        }
        if (target is iTouchable _t) {
            CreateButton("Touch", _t.GetTouched);

        }
        if (target is iPickable _p) {
            CreateButton("Pick", _p.GetPicked);
        }
    }

    void CreateButton(string text, UnityEngine.Events.UnityAction action) {
        GameObject buttonObj = (GameObject)Instantiate(btnPref);
        buttonObj.transform.SetParent(playerCanvas.transform);
        buttonObj.GetComponentInChildren<Text>().text = text;
        Button button = buttonObj.GetComponent<Button>();
        button.onClick.AddListener(action);
        button.onClick.AddListener(CloseMenu);
    }

    public void ShowText(string text){
        muhText.text = text;
        muhText.enabled = true;
        Invoke("HideText", 3f);
    }

    private void HideText(){
        muhText.enabled = false;
    }
}
