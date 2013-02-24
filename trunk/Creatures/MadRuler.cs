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
	[CorpseName( "an mad ruler corpse" )]
	public class MadRuler : BaseCreature
	{
		[Constructable]
		public MadRuler() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mad ruler";
			Body = 131;
			BaseSoundID = 768;
            Hue = 1644;             //Not sure if everyone has this hue or not

			SetStr( 126, 155 );
			SetDex( 266, 285 );
			SetInt( 131, 155 );

			SetHits( 55, 60 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 60.1, 75.0 );
			SetSkill( SkillName.Magery, 60.1, 75.0 );
			SetSkill( SkillName.MagicResist, 60.1, 65.0 );
			SetSkill( SkillName.Tactics, 60.1, 65.0 );
			SetSkill( SkillName.Wrestling, 60.1, 65.0 );

			Fame = 100;
			Karma = -0;

            PackReg(10);
            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

			VirtualArmor = 36;
		}

		public override void GenerateLoot()
		{
		}

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;       //Remove if not using Tokens
                case 1: c.AddItem(new SpecialIngot()); break;       //7th Item Requested
            }
            base.OnDeath(c);
        }

        public MadRuler(Serial serial) : base(serial)
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
