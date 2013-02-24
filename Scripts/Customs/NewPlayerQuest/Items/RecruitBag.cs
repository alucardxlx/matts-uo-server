using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Items
{
	public class RecruitBag : Bag
	{
		[Constructable]
		public RecruitBag()
		{
            Name = "New Recruit Bag";
            Hue = 17;
            DropItem(new TrainingWeaponDeed());
            DropItem(new RecruitRing());
		}

        public RecruitBag(Serial serial) : base(serial)
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