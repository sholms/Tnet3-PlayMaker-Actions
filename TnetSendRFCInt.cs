// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetSendRFCInt : ComponentAction<RFCProxy>
	{
		[RequiredField]
		[CheckForComponent(typeof(RFCProxy))]
        public FsmOwnerDefault gameObject;
		//public FsmEvent Spawn;

		[System.NonSerialized]
		 RFCProxy tno;

		 [RequiredField]
		[Tooltip("Event Name, the resive variable need the same name")]
		public FsmString eventname;

		 [RequiredField]
		[Tooltip("Send Variable")]
		public FsmInt variable;
		

		public override void Reset()
		{
			eventname = "";
			variable = 0;
            
			
		}

		public override void OnEnter()
		{
            if (UpdateCache (Fsm.GetOwnerDefaultTarget (gameObject))) {
				tno = (RFCProxy)this.cachedComponent;
				Execute ();
			}

			Finish();
			

			

		}
        void Execute()
		{
			tno.intdata = variable.Value;
			tno.eventname = eventname.Value;
            tno.SendInt();
		}

	}
}