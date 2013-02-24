// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;

namespace Server.Items
{
	public class RecruitRing : SilverRing
	{

		[Constructable]
		public RecruitRing()
		{
			Name = "New Recruit Ring";
            Hue = 1153;
						
			Attributes.NightSight = 1;
			
		}

        public RecruitRing(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}