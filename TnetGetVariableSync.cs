// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetGetVariableSync : ComponentAction<FSMvariablesSyncProxy>
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
            Position.Value = tno.position;
            Horizontal.Value = tno.Horizontal;
			Vertical.Value = tno.Vertical;
			name.Value = tno.playername;
			Life.Value = tno.Life;

		}

	}
}