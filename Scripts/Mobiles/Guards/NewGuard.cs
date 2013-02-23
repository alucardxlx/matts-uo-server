/////////////////////////////////
/////                       /////
/////      TGrey[WoLf]      /////
/////                       /////
/////////////////////////////////
using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class NewGuard : BaseCreature
	{
		private Mobile m_Target;
		private DateTime m_ExpireTime;

		public override void DisplayPaperdollTo( Mobile to )
		{
			// Do nothing
		}

		public override Mobile ConstantFocus{ get{ return m_Target; } }
		public override bool NoHouseRestrictions{ get{ return true; } }

		[Constructable]
		public NewGuard() : this( null )
		{
		}

		[Constructable]
		public NewGuard(Mobile target) : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.05, 0.2 )
		{
			if ( Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
			}

			Title = "the guard";

			m_Target = target;
			TimeSpan duration = TimeSpan.FromMinutes(5);
			m_ExpireTime = DateTime.Now + duration;

			SetStr( 200 );
			SetDex( 150 );
			SetInt( 150 );

			SetDamage( 10, 17 );

			// Bestiary says 50 phys 50 cold, animal lore says differently
			SetDamageType( ResistanceType.Physical, 65 );

			SetSkill( SkillName.MagicResist, 100.0 ); // magic resist is absolute value of spiritspeak
			SetSkill( SkillName.Tactics, 120.0 ); // always 100
			SetSkill( SkillName.Swords, 120.0); // not displayed in animal lore but tests clearly show this is influenced
			SetSkill( SkillName.DetectHidden, 100);


			SetResistance( ResistanceType.Physical, 25, 45 );
			SetResistance( ResistanceType.Cold, 25, 45 );
			SetResistance( ResistanceType.Fire, 25, 45 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 25, 45 );

			Fame = 0;
			Karma = 0;

			VirtualArmor = 32;

			Item shroud = new DeathShroud();

			shroud.Hue = 0x455;

			shroud.Movable = false;

			AddItem( shroud );

			Halberd weapon = new Halberd();

			weapon.Hue = 1;
			weapon.Movable = false;
			weapon.Attributes.SpellChanneling = 1;

			AddItem( weapon );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override void OnThink()
		{
			if ( !m_Target.Alive || DateTime.Now > m_ExpireTime )
			{
				Delete();
				return;
			}
			else if ( Map != m_Target.Map || !InRange( m_Target, 15 ) )
			{
				Map fromMap = Map;
				Point3D from = Location;

				Map toMap = m_Target.Map;
				Point3D to = m_Target.Location;

				if ( toMap != null )
				{
					for ( int i = 0; i < 5; ++i )
					{
						Point3D loc = new Point3D( to.X - 4 + Utility.Random( 9 ), to.Y - 4 + Utility.Random( 9 ), to.Z );

						if ( toMap.CanSpawnMobile( loc ) )
						{
							to = loc;
							break;
						}
						else
						{
							loc.Z = toMap.GetAverageZ( loc.X, loc.Y );

							if ( toMap.CanSpawnMobile( loc ) )
							{
								to = loc;
								break;
							}
						}
					}
				}

				Map = toMap;
				Location = to;

				ProcessDelta();

				Effects.SendLocationParticles( EffectItem.Create( from, fromMap, EffectItem.DefaultDuration ), 0x3728, 1, 13, 37, 7, 5023, 0 );
				FixedParticles( 0x3728, 1, 13, 5023, 37, 7, EffectLayer.Waist );

				PlaySound( 0x37D );
			}

			if ( m_Target.Hidden && InRange( m_Target, 3 ) && DateTime.Now >= this.NextSkillTime && UseSkill( SkillName.DetectHidden ) )
			{
				Target targ = this.Target;

				if ( targ != null )
					targ.Invoke( this, this );
			}

			Combatant = m_Target;
			FocusMob = m_Target;

			if ( AIObject != null )
				AIObject.Action = ActionType.Combat;

			base.OnThink();
		}

		public NewGuard( Serial serial ) : base( serial )
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

			Delete();
		}
	}
}