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
   public class TrainGump9 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump9", AccessLevel.GameMaster, new CommandEventHandler(TrainGump9_OnCommand)); 
      }

      private static void TrainGump9_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump9(e.Mobile)); 
      }

      public TrainGump9(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(20, 19, 95, @"Wow, yer makin some of the others look bad. Keep it up!");
          this.AddLabel(38, 46, 95, @"Just a few more tasks and Ill send ya on yer way.");
          this.AddLabel(17, 72, 95, @"We use a carrier to take letters back n forth. Seems he");
          this.AddLabel(20, 99, 95, @"was attacked on his way back this time and lost all the");
          this.AddLabel(30, 126, 95, @"letters for the troops.  I need you to go find them");
          this.AddLabel(14, 150, 95, @"With out em, morale 'ill be too low. Says he was attacked ");
          this.AddLabel(4, 176, 95, @"by those unholy drainers but was some scavengers around to.");
          this.AddLabel(24, 199, 95, @"Could be any of em has em.  Says there was 15 letters.");
          this.AddLabel(53, 228, 95, @"The one I need tho, is from the general.");
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
                      from.SendMessage("Yer jokin, arent ye?!");
                      from.CloseGump(typeof(TrainGump9));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump9));
                      from.SendMessage("Smack em once for me too!");
                      break;
                  }

         }
      }
   }
}