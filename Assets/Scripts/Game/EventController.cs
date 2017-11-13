using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour {

    [SerializeField]
    public GameObject sceneManager;

	public void onCellClick(Object cell)
    {
        Debug.Log(cell);
        //cell.GetComponent<Image>().sprite = sceneManager.GetComponent<SceneManager>().getCross();
    }
}
