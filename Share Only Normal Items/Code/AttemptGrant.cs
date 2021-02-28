using System;
using System.Collections.Generic;
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
			PickupDef pickupDef = PickupCatalog.GetPickupDef(this.pickupIndex);
			if (pickupDef.itemIndex != ItemIndex.None)
			{
				using (IEnumerator<TeamComponent> enumerator = TeamComponent.GetTeamMembers(TeamIndex.Player).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						TeamComponent teamComponent = enumerator.Current;
						body = teamComponent.GetComponent<CharacterBody>();
						if (teamComponent && teamComponent.teamIndex == TeamIndex.Player)
						{
							Inventory inventory = body.inventory;
							if (inventory)
							{
								this.consumed = true;
								this.GrantItem(body, inventory);
							}
						}
					}
					return;
				}
			}
			TeamComponent teamComponent2 = body.GetComponent<TeamComponent>();
			if (teamComponent2 && teamComponent2.teamIndex == TeamIndex.Player)
			{
				Inventory inventory2 = body.inventory;
				if (inventory2)
				{
					this.consumed = true;
					if (pickupDef.equipmentIndex != EquipmentIndex.None)
					{
						this.GrantEquipment(body, inventory2);
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
