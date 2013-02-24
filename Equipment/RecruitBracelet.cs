// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;

namespace Server.Items
{
	public class RecruitBracelet : SilverBracelet
	{

		[Constructable]
		public RecruitBracelet()
		{
			Name = "Recruit Bracelet";
            Hue = 1153;                  //added hue to make them easier to find in packs
						
			Attributes.BonusDex = 1;
			Attributes.RegenStam = 1;
			
		}

        public RecruitBracelet(Serial serial) : base(serial)
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