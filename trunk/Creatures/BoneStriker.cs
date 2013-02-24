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
	[CorpseName( "a bone corpse" )]
	public class BoneStriker : BaseCreature
	{
		[Constructable]
		public BoneStriker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone striker";
			Body = 57;
			BaseSoundID = 451;
            Hue = 2066;

			SetStr( 136, 150 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 35, 45 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 45.1, 50.0 );
			SetSkill( SkillName.Tactics, 50.1, 55.0 );
			SetSkill( SkillName.Wrestling, 50.1, 55.0 );

			Fame = 100;
			Karma = -0;

			VirtualArmor = 20;

            PackItem(new Gold(50));             //Dont want them worried about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            PackItem(new Scimitar());
			PackItem( new WoodenShield());
		}

		public override void GenerateLoot()
		{
		}

		public override bool BleedImmune{ get{ return true; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
//                case 0: c.AddItem(new TokenCheck(25)); break; //Remove if not using tokens
                case 1: c.AddItem(new Medicine()); break;       //4th item requested
            }
            base.OnDeath(c);
        }

        public BoneStriker(Serial serial) : base(serial)
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