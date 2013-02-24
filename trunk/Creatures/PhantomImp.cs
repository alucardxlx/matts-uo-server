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
	[CorpseName( "an phantom imp corpse" )]
	public class PhantomImp : BaseCreature
	{
		[Constructable]
		public PhantomImp() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a phantom imp";
			Body = 74;
			BaseSoundID = 422;
            Hue = 0x4001;           //Ethereal Hue

			SetStr( 71, 95 );
			SetDex( 61, 80 );
			SetInt( 86, 105 );

			SetHits( 30, 40 );
            SetMana(100);

			SetDamage( 2, 4 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.EvalInt, 20.1, 30.0 );
			SetSkill( SkillName.Magery, 50.1, 60.0 );
			SetSkill( SkillName.MagicResist, 30.1, 50.0 );
			SetSkill( SkillName.Tactics, 42.1, 50.0 );
			SetSkill( SkillName.Wrestling, 40.1, 44.0 );

			Fame = 100;
			Karma = -0;

			VirtualArmor = 30;

            PackReg(10);
            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());
            //PackItem(new ResourceRecipe());

			Tamable = true;                     //Possible Taming quest add later?
			ControlSlots = 1;
			MinTameSkill = 23.1;
		}

		public override void GenerateLoot()
		{
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 2; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Daemon; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new DarkBone()); break;           //3rd Item Requested
            }
            base.OnDeath(c);
        }

        public PhantomImp(Serial serial) : base(serial)
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