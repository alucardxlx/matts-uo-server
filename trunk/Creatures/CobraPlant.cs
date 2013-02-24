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
	[CorpseName( "a plant corpse" )]
	public class CobraPlant : BaseCreature
	{
		[Constructable]
		public CobraPlant() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "A Cobra Plant";
			Body = 8;
			BaseSoundID = 684;
            Hue = 1155;

			SetStr( 56, 80 );
			SetDex( 26, 45 );
			SetInt( 26, 40 );

			SetHits( 26, 30 );
			SetMana( 0 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 20, 30 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.Wrestling, 45.1, 60.0 );

			Fame = 100;
			Karma = -0;

			VirtualArmor = 18;

            PackItem(new Gold(50));             //no worries about gold yet
			PackItem(new MandrakeRoot(5));
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

		}

		public override void GenerateLoot()
		{
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override bool DisallowAllMoves{ get{ return true; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;   //Remove if not using tokens
                case 1: c.AddItem(new MageBag()); break;        //2nd Item Requested
            }   
            base.OnDeath(c);
        }

		public CobraPlant( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 352 )
				BaseSoundID = 684;
		}
	}
}
