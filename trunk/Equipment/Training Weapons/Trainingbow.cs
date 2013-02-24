//Modified By Jamze for Mystic 2/25/2010
//From Murzins design
using System;
using Server.Network;
using Server.Items;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0x13B2, 0x13B1 )]
	public class TrainingBow : BaseMeleeWeapon
	{

		public virtual int EffectID{ get{ return 0xF42; } }
		public virtual Type AmmoType{ get{ return typeof( Arrow ); } }
		public virtual Item Ammo{ get{ return new Arrow(); } }

		public override int DefHitSound{ get{ return 0x234; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override SkillName DefSkill{ get{ return SkillName.Archery; } }
		public override WeaponType DefType{ get{ return WeaponType.Ranged; } }

		public override SkillName AccuracySkill{ get{ return SkillName.Archery; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 1; } }
		public override int AosMinDamage{ get{ return 1; } }
		public override int AosMaxDamage{ get{ return 2; } }
		public override int AosSpeed{ get{ return 55; } }
        public override float MlSpeed { get { return 0.25f; } }

		public override int OldStrengthReq{ get{ return 1; } }
		public override int OldMinDamage{ get{ return 3; } }
		public override int OldMaxDamage{ get{ return 5; } }
		public override int OldSpeed{ get{ return 55; } }

		public override int InitMinHits{ get{ return 10; } }
		public override int InitMaxHits{ get{ return 10; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public TrainingBow() : base( 0x13B2 )
		{
			Name = "Practice Bow";
			Hue = 17;
			Weight = 1.0;
			Layer = Layer.TwoHanded;
		}

		public override TimeSpan OnSwing( Mobile attacker, Mobile defender )
		{
			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );

			// Make sure we've been standing still for .25/.5/1 second depending on Era
			if ( DateTime.Now > (attacker.LastMoveTime + TimeSpan.FromSeconds( Core.SE ? 0.25 : (Core.AOS ? 0.5 : 1.0) )) || (Core.AOS && WeaponAbility.GetCurrentAbility( attacker ) is MovingShot) )
			{
				bool canSwing = true;

				if ( Core.AOS )
				{
					canSwing = ( !attacker.Paralyzed && !attacker.Frozen );

					if ( canSwing )
					{
						Spell sp = attacker.Spell as Spell;

						canSwing = ( sp == null || !sp.IsCasting || !sp.BlocksMovement );
					}
				}

				if ( canSwing && attacker.HarmfulCheck( defender ) )
				{
					attacker.DisruptiveAction();
					attacker.Send( new Swing( 0, attacker, defender ) );

					if ( OnFired( attacker, defender ) )
					{
						if ( CheckHit( attacker, defender ) )
							OnHit( attacker, defender );
						else
							OnMiss( attacker, defender );
					}
				}

				attacker.RevealingAction();

				return GetDelay( attacker );
			}
			else
			{
				attacker.RevealingAction();

				return TimeSpan.FromSeconds( 0.25 );
			}
		}

		public TrainingBow( Serial serial ) : base( serial )
		{
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			base.OnMiss( attacker, defender );
		}


		public virtual bool OnFired( Mobile attacker, Mobile defender )
		{
			attacker.MovingEffect( defender, EffectID, 18, 1, false, false );

			return true;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				case 1:
				{
					break;
				}
				case 0:
				{
					/*m_EffectID =*/ reader.ReadInt();
					break;
				}
			}

			if ( version < 2 )
			{
				WeaponAttributes.MageWeapon = 0;
				WeaponAttributes.UseBestSkill = 0;
			}

			if ( Weight > 1.0 )
				Weight = 1.0;
		}
	}
}