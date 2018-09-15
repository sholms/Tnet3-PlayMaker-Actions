// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetSetVariableSync : ComponentAction<FSMvariablesSyncProxy>
	{
		[RequiredField]
		[CheckForComponent(typeof(FSMvariablesSyncProxy))]
		public FsmOwnerDefault gameObject;

        public FsmVector3 Position;
        public FsmFloat Horizontal;
		public FsmFloat Vertical;
		public FsmString name;
		public FsmInt Life;

		[System.NonSerialized]
		 FSMvariablesSyncProxy tno;

		public override void OnEnter()
		{
			if (UpdateCache (Fsm.GetOwnerDefaultTarget (gameObject))) {
				tno = (FSMvariablesSyncProxy)this.cachedComponent;
				
			}

			

		}
        public override void OnUpdate(){
            tno.position = Position.Value;
            tno.Horizontal = Horizontal.Value;
			tno.Vertical = Vertical.Value;
			tno.playername = name.Value;
			tno.Life = Life.Value;

		}

	}
}