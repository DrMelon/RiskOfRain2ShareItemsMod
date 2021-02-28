using System;
using System.Runtime.InteropServices;
using RoR2.Networking;
using UnityEngine;
using UnityEngine.Networking;

namespace RoR2
{
	// Token: 0x0200028A RID: 650
	public sealed partial class GenericPickupController : NetworkBehaviour, IInteractable, IDisplayNameProvider
	{
		// Token: 0x06000F06 RID: 3846
		[Server]
		private void AttemptGrant(CharacterBody body)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void RoR2.GenericPickupController::AttemptGrant(RoR2.CharacterBody)' called on client");
				return;
			}
			foreach (TeamComponent component in TeamComponent.GetTeamMembers(TeamIndex.Player))
			{
				body = component.GetComponent<CharacterBody>();
				if (component && component.teamIndex == TeamIndex.Player)
				{
					Inventory inventory = body.inventory;
					if (inventory)
					{
						this.consumed = true;
						PickupDef pickupDef = PickupCatalog.GetPickupDef(this.pickupIndex);
						if (pickupDef.itemIndex != ItemIndex.None)
						{
							this.GrantItem(body, inventory);
						}
						if (pickupDef.equipmentIndex != EquipmentIndex.None)
						{
							this.GrantEquipment(body, inventory);
						}
						if (pickupDef.artifactIndex != ArtifactIndex.None)
						{
							this.GrantArtifact(body, pickupDef.artifactIndex);
						}
						if (pickupDef.coinValue != 0U)
						{
							this.GrantLunarCoin(body, pickupDef.coinValue);
						}
					}
				}
			}
		}
	}
}
