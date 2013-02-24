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
	[CorpseName( "an frillback ogre corpse" )]
	public class FrillBack : BaseCreature
	{
		[Constructable]
		public FrillBack () : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frillback ogre";
			Body = 1;
			BaseSoundID = 427;
            Hue = 2430;

			SetStr( 166, 195 );
			SetDex( 46, 65 );
			SetInt( 146, 170 );

			SetHits( 60, 67 );
			SetMana( 100 );

			SetDamage( 4, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 25 );

            SetSkill(SkillName.Anatomy, 60.2, 70.0);
            SetSkill(SkillName.Archery, 70.1, 80.0);
            SetSkill(SkillName.MagicResist, 55.1, 60.0);
            SetSkill(SkillName.Tactics, 50.1, 65.0);
            SetSkill(SkillName.Wrestling, 50.1, 65.0);

			Fame = 100;
			Karma = -0;

            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());
            AddItem(new Bow());
            PackItem(new Arrow(Utility.RandomMinMax(10, 20)));

			VirtualArmor = 18;

        }

		public override void GenerateLoot()
		{
        }
		
        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using tokens
                case 1: c.AddItem(new MagicLogg()); break;          //9th Item Requested
            }
            base.OnDeath(c);
        }

        public FrillBack(Serial serial) : base(serial)
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