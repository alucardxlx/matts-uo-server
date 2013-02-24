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
	[CorpseName( "a ratman's corpse" )]
	public class HookRat : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public HookRat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hook rat";
			Body = 42;
			BaseSoundID = 437;
            Hue = 17;

			SetStr( 96, 120 );
			SetDex( 81, 100 );
			SetInt( 36, 60 );

			SetHits( 48, 55 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 40.0 );
			SetSkill( SkillName.Tactics, 55.1, 65.0 );
			SetSkill( SkillName.Wrestling, 55.1, 65.0 );

			Fame = 100;
			Karma = -0;

            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

			VirtualArmor = 28;
		}

		public override void GenerateLoot()
		{
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 2; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new SpecialLeather()); break;     //6th Item Requested
            }
            base.OnDeath(c);
        }

        public HookRat(Serial serial) : base(serial)
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