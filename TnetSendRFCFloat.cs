// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetSendRFCFloat : ComponentAction<RFCProxy>
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
		public FsmFloat variable;
		

		public override void Reset()
		{
			eventname = "";
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
			tno.floatdata = variable.Value;
			tno.eventname = eventname.Value;
            tno.SendFloat();
		}

	}
}