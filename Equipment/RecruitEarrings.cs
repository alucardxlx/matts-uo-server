// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;

namespace Server.Items
{
	public class RecruitEarrings : SilverEarrings
	{

		[Constructable]
		public RecruitEarrings()
		{
			Name = "Recruit Earrings";
            Hue = 1153;                 //added hue to make easier to find in packs
						
			Attributes.BonusInt = 1;
			Attributes.RegenMana = 1;
			Attributes.SpellDamage = 1;
			
		}

        public RecruitEarrings(Serial serial) : base(serial)
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