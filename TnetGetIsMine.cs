// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetGetIsMine : ComponentAction<TNObject>
	{
		[RequiredField]
		[CheckForComponent(typeof(TNObject))]
		public FsmOwnerDefault gameObject;

		public FsmEvent isClientEvent;

		public FsmEvent isNotClientEvent;

		[UIHint(UIHint.Variable)]
		public FsmBool isClient;

		[System.NonSerialized]
		 TNObject tno;

		public override void Reset()
		{
			
			gameObject = null;
			isClientEvent = null;
			isNotClientEvent = null;
			isClient = null;
		}

		public override void OnEnter()
		{
			if (UpdateCache (Fsm.GetOwnerDefaultTarget (gameObject))) {
				tno = (TNObject)this.cachedComponent;
				Execute ();
			}

			Finish();

		}
        void Execute()
		{
			if (tno.isMine)
			{
				Fsm.Event(isClientEvent);
			}else{
				Fsm.Event(isNotClientEvent);
			}
		}

	}
}