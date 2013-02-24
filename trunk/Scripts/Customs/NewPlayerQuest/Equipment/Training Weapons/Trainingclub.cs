//Modified By Jamze for Mystic 2/25/2010
//From Murzins design
using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13b4, 0x13b3 )]
	public class Trainingclub : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override int AosStrengthReq{ get{ return 1; } }
		public override int AosMinDamage{ get{ return 1; } }
		public override int AosMaxDamage{ get{ return 2; } }
		public override int AosSpeed{ get{ return 55; } }
        public override float MlSpeed { get { return 0.25f; } }

		public override int OldStrengthReq{ get{ return 1; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 4; } }
		public override int OldSpeed{ get{ return 55; } }

		public override int InitMinHits{ get{ return 10; } }
		public override int InitMaxHits{ get{ return 10; } }

		[Constructable]
		public Trainingclub() : base( 0x13B4 )
		{
			Name = "Practice Club";
			Hue = 17;
			Weight = 1.0;
		}

		public Trainingclub( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}