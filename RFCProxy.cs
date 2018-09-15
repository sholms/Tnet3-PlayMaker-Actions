using System.Collections;
using System.Collections.Generic;
using TNet;
using HutongGames.PlayMaker;
using UnityEngine;

public class RFCProxy :TNBehaviour{

	public PlayMakerFSM fsm;
	public string stringdata;
	public int intdata;
	public float floatdata;
	public string eventname;

	// Use this for initialization
	public void SendString () {
		
			tno.Send("StringData", Target.All, stringdata,eventname);
		}
		
	public void SendInt (){
			tno.Send("IntData", Target.All, intdata ,eventname);
	}

	public void SendFloat (){
			tno.Send("FloatData", Target.All,floatdata ,eventname);
	}

	public void Event (){
			tno.Send("Event", Target.All,eventname);
	}

	[RFC] void StringData (string test,string fsmevent){
		eventname = fsmevent;
		fsm.FsmVariables.GetFsmString(eventname).Value = test;
		fsm.SendEvent(eventname);
		
		
	}

	[RFC] void IntData (int number, string fsmevent){
		eventname = fsmevent;
		fsm.FsmVariables.GetFsmInt(eventname).Value = number;
		fsm.SendEvent(eventname);
		
	}

	[RFC] void FloatData (float floatnumber, string fsmevent){
		eventname = fsmevent;
		fsm.FsmVariables.GetFsmFloat(eventname).Value = floatnumber;
		fsm.SendEvent(eventname);
		
	}

	[RFC] void Event (string fsmevent){
		eventname = fsmevent;
		fsm.SendEvent(eventname);
		
	}
	
	
}
