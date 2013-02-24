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
	[CorpseName( "a rock eater corpse" )]
	public class RockEater : BaseCreature
	{

		[Constructable]
		public RockEater() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a rock eater";
			Body = 14;
			BaseSoundID = 268;

			SetStr( 96, 125 );
			SetDex( 66, 85 );
			SetInt( 71, 92 );

			SetHits( 55, 60 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 15, 25 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 100;
			Karma = -0;

			VirtualArmor = 34;

            PackItem(new Gold(50));         //No worries about gold yet
            //PackItem(new CraftingRecipe()); //Remove if not using Daats
            //PackItem(new ResourceRecipe());

		}

		public override void GenerateLoot()
		{
		}

		public override bool BleedImmune{ get{ return true; } }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new SpecialIngot()); break;       //7th Item requested
            }
            base.OnDeath(c);
        }

        public RockEater(Serial serial) : base(serial)
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