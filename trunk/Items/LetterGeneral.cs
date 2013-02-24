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
	public class LetterGeneral : Item
	{
		[Constructable]
		public LetterGeneral() : base( 0x14F0 )
		{
			base.Weight = 1.0;
			base.Name = "Letter from the general";
			Hue = 14;
		}

        public LetterGeneral(Serial serial) : base(serial)
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

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "Letter from the General of the armies." );
		}
	}
}


