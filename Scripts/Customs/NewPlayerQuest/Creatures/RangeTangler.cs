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
	[CorpseName( "an tangled corpse" )]
	public class RangeTangler : BaseCreature
	{
		[Constructable]
		public RangeTangler() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "range tangler";
			Body = 18;
			BaseSoundID = 367;
            Hue = 33;

			SetStr( 136, 165 );
			SetDex( 56, 75 );
			SetInt( 31, 55 );

			SetHits( 60, 65 );

			SetDamage( 4, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 40 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 15, 25 );

            SetSkill(SkillName.EvalInt, 40.1, 30.0);
            SetSkill(SkillName.Magery, 60.1, 65.0);
            SetSkill(SkillName.MagicResist, 30.1, 50.0);
            SetSkill(SkillName.Tactics, 52.1, 60.0);
            SetSkill(SkillName.Wrestling, 50.1, 64.0);

            Fame = 100;
            Karma = -0;

            VirtualArmor = 28;

            PackReg(10);
            PackItem(new Gold(50));             //No worries about gold yet
        //    PackItem(new CraftingRecipe());     //Remove if not using Daats
        //    PackItem(new ResourceRecipe());
        }

		public override void GenerateLoot()
		{
		}

		public override bool CanRummageCorpses{ get{ return true; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using tokens
                case 1: c.AddItem(new MagicLogg()); break;          //9th Item Requested
            }
            base.OnDeath(c);
        }

        public RangeTangler(Serial serial) : base(serial)
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