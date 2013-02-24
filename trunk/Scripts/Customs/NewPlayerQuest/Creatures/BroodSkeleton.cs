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
	[CorpseName( "a skeletal corpse" )]
	public class BroodSkeleton : BaseCreature
	{
		[Constructable]
		public BroodSkeleton() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a brood skeleton";
			Body = 50;
			BaseSoundID = 0x48D;
            Hue = 6;

			SetStr( 56, 80 );
			SetDex( 56, 75 );
			SetInt( 16, 40 );

			SetHits( 20, 25 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 25, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 25.1, 40.0 );
			SetSkill( SkillName.Wrestling, 25.1, 45.0 );

			Fame = 100;
			Karma = -0;

            PackItem(new Gold(50));             //No worries about gold yet.
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

			VirtualArmor = 16;

		}

		public override void GenerateLoot()
		{
		}

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
 //               case 0: c.AddItem(new TokenCheck(25)); break;  //Remove if not using token
                case 1: c.AddItem(new TrainSupplies()); break;  //1st Item requested.
            }
            base.OnDeath(c);
        }

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

        public BroodSkeleton(Serial serial) : base(serial)
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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
