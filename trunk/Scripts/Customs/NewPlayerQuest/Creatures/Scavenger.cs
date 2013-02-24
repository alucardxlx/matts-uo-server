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
	[CorpseName( "a scavenger corpse" )]
	public class Scavenger : BaseCreature
	{
		[Constructable]
		public Scavenger() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a scavenger";
			Body = 48;
			BaseSoundID = 397;

			SetStr( 73, 115 );
			SetDex( 76, 95 );
			SetInt( 16, 30 );

			SetHits( 50, 66 );
			SetMana( 0 );

			SetDamage( 4, 6 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 15 );
			SetResistance( ResistanceType.Cold, 20, 25 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 30.1, 35.0 );
			SetSkill( SkillName.Tactics, 60.3, 75.0 );
			SetSkill( SkillName.Wrestling, 60.3, 75.0 );

            Fame = 100;
            Karma = -0;

            VirtualArmor = 28;

            PackItem(new Gold(50));     //No worries about gold yet
            //PackItem(new CraftingRecipe());     //remove if not using Daats
            //PackItem(new ResourceRecipe());

			Tamable = true;             //Possible Taming add later?
			ControlSlots = 1;
			MinTameSkill = 37.1;

		}

		public override void GenerateLoot()
		{
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(15))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new LetterGeneral()); break;      //Last Item Requested.
                case 2: c.AddItem(new LetterHome()); break;         //Not requested but gives additional reward
            }
            base.OnDeath(c);
        }

        public Scavenger(Serial serial) : base(serial)
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