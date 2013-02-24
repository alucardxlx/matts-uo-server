// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
	public class DarkBone : Item
	{

		[Constructable]
		public DarkBone() : this( 1 )
		{
		}

		[Constructable]
		public DarkBone( int amount ) : base( 0xf7e )
		{
            Name = "Dark Bone";
            Stackable = true;
			Amount = amount;
            Hue = 17;
			Weight = 1.0;
		}

        public DarkBone(Serial serial) : base(serial)
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