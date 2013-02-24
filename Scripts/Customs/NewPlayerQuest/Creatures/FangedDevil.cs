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
	[CorpseName( "a fanged devil corpse" )]
	public class FangedDevil : BaseCreature
	{
		[Constructable]
		public FangedDevil() : base( AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fanged devil";
			Body = 317;
			BaseSoundID = 0x270;
            Hue = 1157;

			SetStr( 51, 75 );
			SetDex( 51, 75 );
			SetInt( 26, 50 );

			SetHits( 30, 40 );
            SetMana(100);

			SetDamage( 2, 4 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 55.1, 80.0 );
			SetSkill( SkillName.Wrestling, 30.1, 55.0 );
            SetSkill(SkillName.Necromancy, 30.0, 50.0);
            SetSkill( SkillName.SpiritSpeak, 30.0, 50.0);

			Fame = 100;
			Karma = -0;

			VirtualArmor = 14;

            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            PackNecroReg(5, 10);

		}

		public override void GenerateLoot()
		{
		}

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using tokens
                case 1: c.AddItem(new DarkBone()); break;           //3rd Item Requested
            }
            base.OnDeath(c);
        }

		public override int GetIdleSound()
		{
			return 0x29B;
		}

        public FangedDevil(Serial serial) : base(serial)
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