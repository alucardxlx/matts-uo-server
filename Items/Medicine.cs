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
	public class Medicine : Item
	{
		[Constructable]
		public Medicine() : this( 1 )
		{
		}

		[Constructable]
		public Medicine( int amount ) : base( 0xF0E )
		{
            Name = "Medicine";
            Stackable = true;
			Weight = 1.0;
            Hue = 28;
			Amount = amount;
		}

        public Medicine(Serial serial) : base(serial)
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