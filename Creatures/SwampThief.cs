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
	[CorpseName( "a spiney corpse" )]
	public class SwampThief : BaseCreature
	{
		[Constructable]
		public SwampThief() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant toad";
			Body = 80;
			BaseSoundID = 0x26B;
            Hue = 1420;

			SetStr( 76, 100 );
			SetDex( 6, 25 );
			SetInt( 11, 20 );

			SetHits( 55, 60 );
			SetMana( 0 );

			SetDamage( 4, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 45 );
			SetResistance( ResistanceType.Fire, 35, 40 );
			SetResistance( ResistanceType.Energy, 25, 30 );

            SetSkill(SkillName.EvalInt, 60.1, 70.0);
            SetSkill(SkillName.Magery, 70.1, 72.0);
            SetSkill(SkillName.MagicResist, 50.1, 55.0);
            SetSkill(SkillName.Tactics, 62.1, 70.0);
            SetSkill(SkillName.Wrestling, 70.1, 74.0);

            Fame = 100;
            Karma = -0;

            VirtualArmor = 30;

            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 37.1;
		}

		public override void GenerateLoot()
		{
		}

		public override int Hides{ get{ return 4; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;   //Remove if not using Tokens
                case 1: c.AddItem(new TastyFood()); break;      //8th Item Requested
            }
            base.OnDeath(c);
        }

        public SwampThief(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}