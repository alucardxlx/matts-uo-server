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
	[CorpseName( "a minotaur corpse" )]
	public class LostTorturer : BaseCreature
	{
		[Constructable]
		public LostTorturer() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{
			Name = "a lost torturer";
			Body = 0x107;
            Hue = 2430;             //Im not sure if everyone has this hue or not

			SetStr( 101, 140 );
			SetDex( 91, 110 );
			SetInt( 31, 50 );

			SetHits( 50, 55 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Anatomy, 40 );
			SetSkill( SkillName.MagicResist, 56.1, 64.0 );
			SetSkill( SkillName.Tactics, 63.3, 65.8 );
			SetSkill( SkillName.Wrestling, 60.4, 65.1 );

			Fame = 100;
			Karma = -0;
            
            PackItem(new Gold(50));             //No worries about gold yet
            //PackItem(new CraftingRecipe());     //Remove if not using Daats
            //PackItem(new ResourceRecipe());

			VirtualArmor = 28; 
		}

		public override void GenerateLoot()
		{
		}

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		public override void OnThink()
		{
			if ( Combatant != null )
			{
				if ( !InRange( Combatant.Location, 5 ) )
					CurrentSpeed = 0.05;
				else
					CurrentSpeed = ActiveSpeed;
			}
		}


		public override int GetDeathSound()	{ return 0x596; }
		public override int GetAttackSound() { return 0x597; }
		public override int GetIdleSound() { return 0x598; }
		public override int GetAngerSound() { return 0x599; }
		public override int GetHurtSound() { return 0x59A; }

        public override void OnDeath(Container c)
        {
            switch (Utility.Random(2))
            {
                //case 0: c.AddItem(new TokenCheck(25)); break;           //Remove if not using Tokens
                case 1: c.AddItem(new SpecialLeather()); break;         //6th Item Requested
            }
            base.OnDeath(c);
        }

        public LostTorturer(Serial serial) : base(serial)
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