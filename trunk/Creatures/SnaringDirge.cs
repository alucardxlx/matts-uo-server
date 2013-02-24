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
	[CorpseName( "a snaring dirge corpse" )]
	public class SnaringDirge : BaseCreature
	{
		[Constructable]
		public SnaringDirge() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a snaring dirge";
			Body = 250;
            Hue = 2095;

			SetStr( 301, 350 );
			SetDex( 151, 200 );
			SetInt( 66, 76 );

			SetHits( 56, 60 );
			SetMana( 40 );

			SetDamage( 4, 6 );

			SetDamageType( ResistanceType.Physical, 90 );
			SetDamageType( ResistanceType.Cold, 5 );
			SetDamageType( ResistanceType.Energy, 5 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 50, 70 );
			SetResistance( ResistanceType.Poison, 50, 70 );
			SetResistance( ResistanceType.Energy, 50, 70 );

            SetSkill(SkillName.Anatomy, 60.2, 70.0);
            SetSkill(SkillName.Archery, 60.1, 70.0);
            SetSkill(SkillName.MagicResist, 65.1, 90.0);
            SetSkill(SkillName.Tactics, 50.1, 60.0);
            SetSkill(SkillName.Wrestling, 50.1, 60.0);

            Fame = 100;
            Karma = -0;

            PackItem(new Gold(50));             //No worries about gold here
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            AddItem(new Bow());
            PackItem(new Arrow(Utility.RandomMinMax(10, 20)));

            VirtualArmor = 18;
        }

		public override void GenerateLoot()
		{
		}
		public override int Meat { get { return 4; } }
		public override int Hides { get { return 25; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override HideType HideType { get { return HideType.Barbed; } }  //Fixed  Changed from shadow to barbed

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;   //Remove if not using Tokens
                case 1: c.AddItem(new TastyFood()); break;      //8th Item Requested
            }
            base.OnDeath(c);
        }

        public SnaringDirge(Serial serial) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int GetAngerSound()
		{
			return 0x52D;
		}

		public override int GetIdleSound()
		{
			return 0x52C;
		}

		public override int GetAttackSound()
		{
			return 0x52B;
		}

		public override int GetHurtSound()
		{
			return 0x52E;
		}

		public override int GetDeathSound()
		{
			return 0x52A;
		}
	}
}