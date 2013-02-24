// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest and reward giver
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Accounting;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "Jereme's corpse" )]
    public class Jereme : BaseVendor
	{
        private ArrayList m_SBInfos = new ArrayList();
        protected override ArrayList SBInfos { get { return m_SBInfos; } }
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        private static bool m_Talked; // flag to prevent spam 

        string[] kfcsay = new string[] // things to say while greeting 
		      { 
		         "All warrior types over here.",          
                 "Melee recruits line up here.",
                 "Stop lolly gaggin about an less go!"   //Last saying has no comma after it
      };

		[Constructable]
		public Jereme() : base( "weapon master" )
		{
			Name = "Jereme";
			Title = "New Recruit Guide";
			Body = 400;
			CantWalk = true;
            Female = false;

            Skills.Cap = 9000;  //Raised for training purposes.

            SetSkill(SkillName.Fencing, 100.0);
            SetSkill(SkillName.Macing, 100.0);
            SetSkill(SkillName.Swords, 100.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Parry, 100.0);
            SetSkill(SkillName.Archery, 100.0);
            SetSkill(SkillName.Chivalry, 100.0);
            SetSkill(SkillName.Anatomy, 100.0);
            SetSkill(SkillName.Healing, 100.0);

		}
        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBMeleeTrainer());
        }
        public override void InitOutfit()
        {
            EquipItem(new BladeOfTheRighteous());
            EquipItem(new Aegis());

            EquipItem(new Boots(1));
            EquipItem(new PlateChest());
            EquipItem(new PlateLegs());
            EquipItem(new PlateArms());
            EquipItem(new PlateGloves());
            EquipItem(new PlateGorget());
            EquipItem(new CloseHelm());
            EquipItem(new Cloak(1));

            HairItemID = 0x203C;
            HairHue = 0x466;
        }
        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m_Talked == false)
            {
                if (m.InRange(this, 4))
                {
                    m_Talked = true;
                    SayRandom(kfcsay, this);
                    this.Move(GetDirectionTo(m.Location));
                    SpamTimer t = new SpamTimer();
                    t.Start();
                }
            }
        }
        private class SpamTimer : Timer
        {
            public SpamTimer()
                : base(TimeSpan.FromSeconds(10))
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Talked = false;
            }
        }
        private static void SayRandom(string[] say, Mobile m)
        {
            m.Say(say[Utility.Random(say.Length)]);
        }
        public Jereme(Serial serial) : base(serial)
		{
		}
        
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new JeremeEntry( from, this ) );
		}

        public override bool HandlesOnSpeech(Mobile from)
        {
            base.HandlesOnSpeech(from);
            return true;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {

            bool isMatch = false;

            Mobile from = e.Mobile;

            string keyword = "ready";       //Change keyword here  


            if (keyword != null && e.Speech.ToLower().IndexOf(keyword.ToLower()) >= 0)
            {
                isMatch = true;

                if (!isMatch)
                    return;


                from.SendGump(new ReadyGump(from));
                e.Handled = true;
            }

            base.OnSpeech(e);
        }

		public class JeremeEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

            public JeremeEntry(Mobile from, Mobile giver) : base(6146, 3)
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				
				
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				
				{
					if ( ! mobile.HasGump( typeof( JeremeGump ) ) )
					{
						mobile.SendGump( new JeremeGump( mobile ));
						
					}
				}
			}
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			
			if( mobile != null )
			{
				if( dropped is RecruitDocuments )
				{
					dropped.Delete();
					mobile.SendGump( new TrainStartGump( mobile ));
					return true;
				}
                else if (dropped is TrainSupplies)
         		{
         			if(dropped.Amount!=15)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Cant count? I said 15 of em.", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new Gold( 100 ) );
                    mobile.AddToBackpack(new RecruitCap());
                    mobile.AddToBackpack(new EnhancedBandage(50));
         			mobile.SendGump( new TrainGump1(mobile) );
					return true;
         		}
				else if( dropped is MageBag )
				{
					if(dropped.Amount!=15)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Gotta teach ya to count to do I? Need 15.", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new Gold( 100 ) );
         		    mobile.AddToBackpack( new RecruitGloves() );    
         			mobile.SendGump( new TrainGump2(mobile) );
					return true;
				}
				else if( dropped is DarkBone )
				{
                    if (dropped.Amount != 10)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Again the wrong amount?  sheesh.", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(100));
                    mobile.AddToBackpack(new RecruitGorget());
                    mobile.AddToBackpack(new EnhancedBandage(50));
                    mobile.SendGump(new TrainGump3(mobile));
                    return true;
                }
				else if( dropped is Medicine )
				{
                    if (dropped.Amount != 5)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Dont keep gold long do ye? Need 5 of em.", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(100));
                    mobile.AddToBackpack(new RecruitLegs());   
                    mobile.SendGump(new TrainGump4(mobile));
                    return true;
				}
				else if( dropped is PowerCrystals )
				{
                    if (dropped.Amount != 10)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Who taught you to count?", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(100));
                    mobile.AddToBackpack(new RecruitSleeves());
                    mobile.AddToBackpack(new EnhancedBandage(50));
                    mobile.SendGump(new TrainGump5(mobile));
                    return true;
				}
				else if( dropped is SpecialLeather )
				{
                    if (dropped.Amount != 10)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Dang blasted recruit, 10!?", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(50));
                    mobile.AddToBackpack(new RecruitTunic());    
                    mobile.SendGump(new TrainGump6(mobile));
                    return true;
				}
				else if( dropped is SpecialIngot )
				{
                    if (dropped.Amount != 10)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "What!?", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(100));
                    mobile.AddToBackpack(new RecruitShield());
                    mobile.AddToBackpack(new EnhancedBandage(50));
                    mobile.SendGump(new TrainGump7(mobile));
                    return true;
				}
				else if( dropped is TastyFood )
				{
                    if (dropped.Amount != 10)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Trainees!?", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(100));
                    mobile.AddToBackpack(new RecruitEarrings());   
                    mobile.SendGump(new TrainGump8(mobile));
                    return true;
				}
				else if( dropped is MagicLogg )
				{
                    if (dropped.Amount != 5)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Oy, ye shoulda been a mage!?", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new Gold(100));
                    mobile.AddToBackpack(new EnhancedBandage(50));
                    mobile.AddToBackpack(new RecruitBracelet());   
                    mobile.SendGump(new TrainGump9(mobile));
                    return true;
				}
				else if( dropped is LetterGeneral )
				{
                    dropped.Delete();
                    mobile.AddToBackpack(new BankCheck(5000));
                    mobile.SendGump(new TrainGumpFinish(mobile));
                    return true;
				}
				else if( dropped is LetterHome )
				{
					dropped.Delete();
                    mobile.AddToBackpack(new Gold(50));
                    mobile.SendMessage("Ill make sure they get these. 'eres a bit o coin fer the troubles.");
					return true;
				}
                else if( dropped is TrainingBow )
                {
                    dropped.Delete();
                    mobile.AddToBackpack( new RecruitBow());
                    mobile.AddToBackpack( new Arrow(100));
                    mobile.SendMessage("Heres a new bow, put it to good use!");
                    return true;
                }
                    else if( dropped is Trainingclub )
                {
                    dropped.Delete();
                    mobile.AddToBackpack( new RecruitMace()); 
                    mobile.SendMessage("Heres a new mace, put it to good use!");
                    return true;
                }
                    else if( dropped is TrainingKatana )
                {
                    dropped.Delete();
                    mobile.AddToBackpack( new RecruitKatana()); 
                    mobile.SendMessage("Heres a new katana, put it to good use!");
                    return true;
                }
                    else if( dropped is TrainingKryss )
                {
                    dropped.Delete();
                    mobile.AddToBackpack( new RecruitKryss()); 
                    mobile.SendMessage("Heres a new kryss, put it to good use!");
                    return true;
                }
                else if (dropped is Gold)
                {
                    return OnGoldGiven(from, (Gold)dropped);
                }
                else
                {
                    mobile.SendMessage("I have no need for this item.");
                }
				}
			else
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no need for this item.", mobile.NetState );
				}
		    return false;
		}
        
        public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}  
	}
}