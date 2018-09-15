using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNet;
using HutongGames.PlayMaker;


	public class PlayMakerTnetNetworkBehaviourCallbacksProxy : MonoBehaviour {
        public PlayMakerFSM fsm;
    private void OnEnable()
{
        TNet.TNManager.onConnect += OnConnect;
        TNet.TNManager.onDisconnect -= OnDisconnect;
        TNet.TNManager.onJoinChannel += OnJoinChannel;
        TNet.TNManager.onLeaveChannel += OnLeaveChannel;
}
 
    private void OnDisable()
{
        TNet.TNManager.onConnect -= OnConnect;
        TNet.TNManager.onDisconnect -= OnDisconnect;
        TNet.TNManager.onJoinChannel += OnJoinChannel;
        TNet.TNManager.onLeaveChannel += OnLeaveChannel;
}

	private void OnConnect(bool success, string message)
{
        if (success)
        {
               fsm.SendEvent("OnConnect");
        }
}
    
    private void OnDisconnect ()
{
       
               fsm.SendEvent("OnDisconnect");
        
}
     private void OnJoinChannel (int channel,bool success,string message)
{
                if (success){
                fsm.SendEvent("OnJoinChannel");
                }
               
        
}
    private void OnLeaveChannel (int channel)
{
       
               fsm.SendEvent("OnLeaveChannel");
        
}


	}
