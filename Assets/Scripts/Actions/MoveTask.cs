using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class MoveTask : ActionTask {

		private Blackboard agentBlackboard;

		private Transform robotTransform;
		private float stoppingDistance;

		public BBParameter<float> moveSpeed;
		public BBParameter<float> turnSpeed;

		public Transform destination;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

			agentBlackboard = agent.GetComponent<Blackboard>();
			robotTransform = agentBlackboard.GetVariableValue<Transform>("robotTransform");
			stoppingDistance = agentBlackboard.GetVariableValue<float>("stoppingDistance");

            return null;
		}

        private void Turn(Vector3 direction)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction);

            if (robotTransform.rotation == desiredRotation) return;

            float step = turnSpeed.value * Time.deltaTime;
            robotTransform.rotation = Quaternion.RotateTowards(robotTransform.rotation, desiredRotation, step);
        }

        private void Move(Vector3 direction)
        {
            if (direction.magnitude <= stoppingDistance) return;

            robotTransform.Translate(moveSpeed.value * Time.deltaTime * robotTransform.forward, Space.World);
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            Move(destination.position);
            Turn(destination.position);
        }

	}
}