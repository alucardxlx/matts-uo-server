// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Gate Item
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Commands;


namespace Server.Items
{
	public class ReadyGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;


		[Constructable]
		public ReadyGate() : this( true )
		{
		}

		[Constructable]
		public ReadyGate( bool decays, Point3D loc, Map map ) : this( decays )
		{
			MoveToWorld( loc, map );
			Effects.PlaySound( loc, map, 0x20E );
		}

		[Constructable]
		public ReadyGate( bool decays ) : base( new Point3D( 3712, 2229, 20  ), Map.Felucca ) //this is where the gate goes to
		{
			Dispellable = false;
			ItemID = 0x1FD4;
            Name = "Ready Gate";
            Hue = 68;

			if ( decays )
			{
				m_Decays = true;
				m_DecayTime = DateTime.Now + TimeSpan.FromSeconds( 30 );

				m_Timer = new InternalTimer( this, m_DecayTime );
				m_Timer.Start();
			}
		}

        public ReadyGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			base.OnAfterDelete();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); 

			writer.Write( m_Decays );

			if ( m_Decays )
				writer.WriteDeltaTime( m_DecayTime );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Decays = reader.ReadBool();

					if ( m_Decays )
					{
						m_DecayTime = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_DecayTime );
						m_Timer.Start();
					}

					break;
				}
			}
		}

		private class InternalTimer : Timer
		{
			private Item m_Item;

			public InternalTimer( Item item, DateTime end ) : base( end - DateTime.Now )
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}
}