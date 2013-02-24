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
	[CorpseName( "a wither corpse" )]
	public class Wither : BaseCreature
	{
		[Constructable]
		public Wither() : base( AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wither";
			Body = 28;
			BaseSoundID = 0x388;
            Hue = 1150;

			SetStr( 76, 100 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 26, 30 );
			SetMana( 100 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Poison, 25, 35 );

            SetSkill(SkillName.MagicResist, 50.1, 75.0);
            SetSkill(SkillName.Tactics, 55.1, 80.0);
            SetSkill(SkillName.Wrestling, 30.1, 55.0);
            SetSkill(SkillName.Necromancy, 30.0, 50.0);
            SetSkill(SkillName.SpiritSpeak, 30.0, 50.0);

			Fame = 100;
			Karma = -0;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;

            PackItem(new Gold(50));             //No worries about gold yet
			PackItem( new SpidersSilk( 5 ) );
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            PackNecroReg(5, 10);

		}

		public override void GenerateLoot()
		{
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new MageBag()); break;            //2nd Item Requested
            }
            base.OnDeath(c);
        }

        public Wither(Serial serial) : base(serial)
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