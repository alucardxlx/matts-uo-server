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
	[CorpseName( "a smoldering corpse" )]
	public class LavaGut : BaseCreature
	{
		[Constructable]
		public LavaGut() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a frill back";
			Body = 101;
			BaseSoundID = 679;
            Hue = 1161;

			SetStr( 202, 300 );
			SetDex( 104, 260 );
			SetInt( 91, 100 );

			SetHits( 55, 60 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 35, 45 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 35, 45 );

            SetSkill(SkillName.EvalInt, 50.1, 60.0);
            SetSkill(SkillName.Magery, 70.1, 75.0);
            SetSkill(SkillName.MagicResist, 30.1, 50.0);
            SetSkill(SkillName.Tactics, 42.1, 50.0);
            SetSkill(SkillName.Wrestling, 50.1, 54.0);

            Fame = 100;
            Karma = -0;

            VirtualArmor = 28;

            PackReg(10);
            PackItem(new Gold(50));             //No worries about Gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

		}

		public override void GenerateLoot()
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 4; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new MagicLogg()); break;          //9th Item requested
            }
            base.OnDeath(c);
        }

        public LavaGut(Serial serial) : base(serial)
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

			if ( BaseSoundID == 678 )
				BaseSoundID = 679;
		}
	}
}