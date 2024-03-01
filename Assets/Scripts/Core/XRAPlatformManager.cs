using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRAPlatformManager : MonoBehaviour
{
    public PlatfromType CurrentPlatfromType = PlatfromType.None;

    [SerializeField] private GameObject iphoneRig;
    [SerializeField] private GameObject metaQuestRig;
   
    private void Awake()
    {
#if UNITY_IOS && !UNITY_EDITOR
        CurrentPlatfromType = PlatfromType.iPhone;

        iphoneRig.SetActive(true);
        metaQuestRig.SetActive(false);

#elif UNITY_ANDROID
        CurrentPlatfromType = PlatfromType.MetaQuest;
                metaQuestRig.SetActive(true);
                iphoneRig.SetActive(false);
#elif UNITY_EDITOR
        CurrentPlatfromType = PlatfromType.UnityEditor;
#endif

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CurrentPlatfromType.ToString());
    }
}
