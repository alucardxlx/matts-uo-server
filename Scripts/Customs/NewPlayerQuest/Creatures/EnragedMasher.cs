// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item holder
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "an enraged masher corpse" )]
	public class EnragedMasher : BaseCreature
	{
		[Constructable]
		public EnragedMasher () : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an enraged masher";
			Body = 159;
			BaseSoundID = 278;
            Hue = 1644;

			SetStr( 126, 150 );
			SetDex( 106, 125 );
			SetInt( 126, 150 );

			SetHits( 35, 45 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill(SkillName.Anatomy, 50.2, 60.0);
            SetSkill(SkillName.Archery, 50.1, 60.0);
            SetSkill(SkillName.MagicResist, 45.1, 50.0);
            SetSkill(SkillName.Tactics, 50.1, 65.0);
            SetSkill(SkillName.Wrestling, 50.1, 65.0);

			Fame = 150;
			Karma = -0;

            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            AddItem(new Bow());
            PackItem(new Arrow(Utility.RandomMinMax(10, 20)));

			VirtualArmor = 30;
		}

		public override void GenerateLoot()
		{
		}

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;   //Remove if not using tokens 
                case 1: c.AddItem(new Medicine()); break;       //4th Item Requested
            }
            base.OnDeath(c);
        }

        public EnragedMasher(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}