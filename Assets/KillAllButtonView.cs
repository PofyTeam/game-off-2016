namespace Guvernal.Torquer
{
	using UnityEngine;
	using System.Collections;
	using PofyTools;

	public class KillAllButtonView : ButtonView
	{
		#region implemented abstract members of ButtonView

		protected override void OnClick ()
		{
			//EventManager.Events.killAllRequest ();
		}

		#endregion
	}
}