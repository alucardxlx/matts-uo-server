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
   public class TrainGumpFinish : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGumpFinish", AccessLevel.GameMaster, new CommandEventHandler(TrainGumpFinish_OnCommand)); 
      }

      private static void TrainGumpFinish_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGumpFinish(e.Mobile)); 
      }

      public TrainGumpFinish(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(48, 20, 95, @"Hmm. Looks as tho your deeds have not gone ");
          this.AddLabel(17, 47, 95, @"unnoticed.  The general has requested me to release your");
          this.AddLabel(17, 72, 95, @"services and ask that you seek out Lothar in Haven City.");
          this.AddLabel(8, 96, 95, @"I have placed the letter of Apprenticship for Lothar in yer bag.");
          this.AddLabel(12, 126, 95, @"Just say the word *ready* to me when ye are for a gate");
          this.AddLabel(23, 171, 95, @"out to the main city. Remember to speak with Lothar in"); 
          this.AddLabel(71, 209, 95, @"Haven tho.  Im sure ill hear of ye soon.");
          this.AddButton(171, 305, 247, 248, 0, GumpButtonType.Reply, 0);

      }

      public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
      {
          Mobile from = state.Mobile;

          switch (info.ButtonID)
          {
              case 0:
                  {
                      from.SendMessage("Fare thee well young warrior!");
                      from.CloseGump(typeof(TrainGumpFinish));
                      break;
                  }

         }
      }
   }
}