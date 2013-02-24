// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item holder
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Misc;
using Server.Spells;
using Server.Spells.Third;
using Server.Spells.Sixth;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an unholy corpse" )]
	public class UnholyDrainer : BaseCreature
	{
		[Constructable]
		public UnholyDrainer() : base( AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.1, 0.4 )
		{
			Name = "an unholy drainer";
			Body = 264;
            BaseSoundID = 0x470;
            Hue = 1158;

			SetStr( 96, 105 );
			SetDex( 212, 262 );
			SetInt( 317, 399 );

			SetHits( 50, 55 );
			SetStam( 212, 262 );
			SetMana( 317, 399 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );
			
			SetResistance( ResistanceType.Physical, 81, 90 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 49 );
			SetResistance( ResistanceType.Poison, 41, 50 );
			SetResistance( ResistanceType.Energy, 43, 50 );

            SetSkill(SkillName.MagicResist, 50.1, 75.0);
            SetSkill(SkillName.Tactics, 55.1, 80.0);
            SetSkill(SkillName.Wrestling, 30.1, 55.0);
            SetSkill(SkillName.Necromancy, 70.0, 80.0);
            SetSkill(SkillName.SpiritSpeak, 70.0, 80.0);
            SetSkill(SkillName.Magery, 70.0, 80.0);

            Fame = 100;
            Karma = -0;

            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            PackNecroReg(5, 10);

            VirtualArmor = 29;
        }

        public override void GenerateLoot()
        {
        }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(15))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;   //Remove if not using Tokens
                case 1: c.AddItem(new LetterGeneral()); break;  //Last Item Requested
                case 2: c.AddItem(new LetterHome()); break;     //Not requested but extra if given to Jereme
            }
            base.OnDeath(c);
        }

        public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

        public UnholyDrainer(Serial serial) : base(serial)
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
