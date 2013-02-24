// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Gump
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{
    public class TrainStartGump : Gump
    {
        private Item m_Item;
        private Mobile m_Mobile;

        public static void Initialize()
        {
            CommandSystem.Register("TrainStartGump", AccessLevel.GameMaster, new CommandEventHandler(TrainStartGump_OnCommand));
        }

        private static void TrainStartGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new TrainStartGump(e.Mobile));
        }

        public TrainStartGump( Mobile owner ) : base(50, 50)
        {
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 494, 390, 9200);
			this.AddLabel(53, 51, 95, @"Another new recruit, good!  We can use all the help we can get.");
			this.AddLabel(64, 80, 95, @"These blasted monsters have invaded the tunnels here.  ");
			this.AddLabel(55, 108, 95, @"We've to stop them afore they get out and into the cities. ");
			this.AddLabel(52, 133, 95, @"What can you do to help you ask?  Boy, im likin you more n more");
			this.AddLabel(20, 160, 95, @"Firstly, these blasted Skeletons and blasted undead types are nabbin our ");
			this.AddLabel(31, 183, 95, @"supplies as they come into camp.  I need you to get some of them back.");
			this.AddLabel(21, 207, 95, @"Take this deed for training weapons and kill them.  Bring me back 15 of our");
			this.AddLabel(25, 230, 95, @"missing supplies. Also heres a ring to help you see in the darkness.");
			this.AddLabel(130, 267, 95, @"So whatchya say, are ya in or out?");
			this.AddButton(326, 345, 242, 241, 0, GumpButtonType.Reply, 0);
            this.AddButton(82, 343, 247, 248, 1, GumpButtonType.Reply, 1);
		}
		
		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile;

         switch (info.ButtonID)
         {
             case 0:
                 {
                     from.SendMessage("Really? I thought you had what it took");
                     from.CloseGump(typeof(TrainStartGump));
                     Item item = new RecruitDocuments();
                     item.LootType = LootType.Regular;
                     from.AddToBackpack(new RecruitDocuments());
                     break;
                 }
             case 1:
                 {
                     from.CloseGump(typeof(TrainStartGump));
                     Item item = new RecruitBag();
                     item.LootType = LootType.Regular;
                     from.AddToBackpack(new RecruitBag());

                     /*Item item = new TrainingWeaponDeed();
                     item.LootType = LootType.Regular;
                     from.AddToBackpack(new TrainingWeaponDeed());*/
                     from.SendMessage("Thats the spirit!");
                     break;
                 }
            }
         }
	}
}