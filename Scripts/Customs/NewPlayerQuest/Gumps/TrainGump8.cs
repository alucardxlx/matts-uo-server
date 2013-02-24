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
   public class TrainGump8 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump8", AccessLevel.GameMaster, new CommandEventHandler(TrainGump8_OnCommand)); 
      }

      private static void TrainGump8_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump8(e.Mobile)); 
      }

      public TrainGump8(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(30, 19, 95, @"Great work! Now the troops can stay fed til supplies");
          this.AddLabel(19, 45, 95, @"arrive a thanks to ye. But... Nows a time not for chattin");
          this.AddLabel(24, 72, 95, @"We got us a problem. The archers be runnin low on em");
          this.AddLabel(20, 99, 95, @"arrows. I telled em to use a sword but was ran out fer it.");
          this.AddLabel(22, 126, 95, @"These arrows are not just normal ones. They are made ");
          this.AddLabel(23, 150, 95, @"a magical log we found down here. Come to think of it, ");
          this.AddLabel(21, 174, 95, @"thats how this all started. Oh.. Anyhow, I be needin ye");
          this.AddLabel(24, 199, 95, @"to get 5 of the logs fast as ye can. They be on Range");
          this.AddLabel(79, 230, 95, @"tanglers, Frillbacks and Lavaguts");
          this.AddButton(248, 304, 242, 241, 0, GumpButtonType.Reply, 0);
          this.AddButton(71, 305, 247, 248, 1, GumpButtonType.Reply, 1);

      }

      public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
      {
          Mobile from = state.Mobile;

          switch (info.ButtonID)
          {
              case 0:
                  {
                      from.SendMessage("Blasted newbies!");
                      from.CloseGump(typeof(TrainGump8));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump8));
                      from.SendMessage("Good work, keep it up.");
                      break;
                  }

         }
      }
   }
}