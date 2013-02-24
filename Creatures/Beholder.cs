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
	[CorpseName( "a beholder corpse" )]
	public class Beholder : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		[Constructable]
		public Beholder() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a beholder";
			Body = 36;
			BaseSoundID = 417;
            Hue = 1102;

			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 36, 60 );

			SetHits( 50, 55 );
            SetMana(100);

			SetDamage( 4, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 10, 20 );

            SetSkill(SkillName.EvalInt, 30.1, 40.0);
            SetSkill(SkillName.Magery, 60.1, 65.0);
            SetSkill(SkillName.MagicResist, 30.1, 50.0);
            SetSkill(SkillName.Tactics, 42.1, 50.0);
            SetSkill(SkillName.Wrestling, 40.1, 44.0);

			Fame = 100;
			Karma = -0;

			VirtualArmor = 28;

            PackReg(10);
            PackItem(new Gold(50));  //Dont want them to worried about gold yet.
            //PackItem(new CraftingRecipe());
            //PackItem(new ResourceRecipe());

		}

		public override void GenerateLoot()
		{
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 2; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
//                case 0: c.AddItem(new TokenCheck(25)); break;   //Remove if not using tokens
                case 1: c.AddItem(new SpecialLeather()); break; //6th item requested
            }
            base.OnDeath(c);
        }

        public Beholder(Serial serial) : base(serial)
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