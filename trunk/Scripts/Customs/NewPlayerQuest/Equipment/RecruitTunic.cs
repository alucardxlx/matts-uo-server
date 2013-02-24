// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using Server;
using System;
using Server.Items;

namespace Server.Items
{
	public class RecruitTunic : LeatherChest
	{ 
				
		public override int InitMinHits{ get{ return 125; } }
		public override int InitMaxHits{ get{ return 125; } }

		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

		public override int AosStrReq{ get{ return 15; } }
		public override int OldStrReq{ get{ return 15; } } 
		
		[Constructable]
		public RecruitTunic()
		{
			Hue = 6;
			Name = "Recruit Tunic";
			Weight = 5;
			
			Attributes.ReflectPhysical = 5;
			Attributes.Luck = 125;
            PhysicalBonus = 4;
            FireBonus = 4;
            ColdBonus = 4;
            PoisonBonus = 4;
            EnergyBonus = 4;

            LootType = LootType.Blessed;

		}

        public RecruitTunic(Serial serial) : base(serial)
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
