// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Start Item
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
	public class RecruitDocuments : Item
	{
		[Constructable]
		public RecruitDocuments() : base( 0x14F0 )
		{
			base.Weight = 1.0;
			base.Name = "Documents of new recruit";
			Hue = 17;
		}

        public RecruitDocuments(Serial serial) : base(serial)
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

		public override void OnDoubleClick( Mobile m )      //Change if using only one NPC or names are different
		{
			m.SendMessage( "Documents of new recruit. Give to one of the trainers, either Mary (mage) or Jereme (melee) to start your training" );
		}
	}
}


