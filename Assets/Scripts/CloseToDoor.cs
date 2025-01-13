using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CloseToDoor : ConditionTask {

		public GameObject doorTarget;
		float closenessBuffer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			closenessBuffer = .3f;
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if ((agent.transform.position - doorTarget.transform.position).magnitude < closenessBuffer)
			{
                return true;
            }
			else
			{
				return false;
			}
			
		}
	}
}