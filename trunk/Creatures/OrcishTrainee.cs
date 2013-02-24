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
	[CorpseName( "an orcish corpse" )]
	public class OrcishTrainee : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public OrcishTrainee() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an orcish trainee";
			Body = 138;
			BaseSoundID = 0x45A;
            Hue = 68;                   //Green because hes new! Noob!  (Signs you play too much UO??)

			SetStr( 147, 165 );
			SetDex( 91, 115 );
			SetInt( 61, 85 );

			SetHits( 45, 50 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Swords, 55.1, 65.0 );
			SetSkill( SkillName.Tactics, 55.1, 60.0 );
			SetSkill( SkillName.Wrestling, 50.1, 65.0 );

			Fame = 100;
			Karma = -0;

            PackItem(new Gold(50));             //No wories about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            PackItem(new Scimitar());
            PackItem(new WoodenShield());

		}

		public override void GenerateLoot()
		{
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;           //Remove if not using Tokens
                case 1: c.AddItem(new PowerCrystals()); break;          //5th Item Requested
            }
            base.OnDeath(c);
        }

        public OrcishTrainee(Serial serial) : base(serial)
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