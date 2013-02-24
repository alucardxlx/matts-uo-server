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
	[CorpseName( "a liche's corpse" )]
	public class VorpalLich : BaseCreature
	{
		[Constructable]
		public VorpalLich() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a vorpal lich";
			Body = 24;
			BaseSoundID = 0x3E9;
            Hue = 1158;

			SetStr( 101, 120 );
			SetDex( 126, 145 );
			SetInt( 146, 155 );

			SetHits( 35, 45 );
            SetMana(100);

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 65 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 30.0 );
			SetSkill( SkillName.Meditation, 45.1, 55.0 );
            SetSkill(SkillName.Magery, 50.1, 65.0);
			SetSkill( SkillName.MagicResist, 50.1, 60.0 );
			SetSkill( SkillName.Tactics, 50.1, 60.0 );
            SetSkill(SkillName.Tactics, 50.1, 65.0);
            SetSkill(SkillName.Wrestling, 50.1, 65.0);

			Fame = 100;
			Karma = -0;

			VirtualArmor = 50;

            PackReg(10);
            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

		}

		public override void GenerateLoot()
		{			
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new Medicine()); break;           //4th Item Requested
            }
            base.OnDeath(c);
        }

        public VorpalLich(Serial serial) : base(serial)
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