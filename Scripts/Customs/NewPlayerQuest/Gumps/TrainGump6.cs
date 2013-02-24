// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest. Gump
using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class TrainGump6 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump6", AccessLevel.GameMaster, new CommandEventHandler(TrainGump6_OnCommand)); 
      }

      private static void TrainGump6_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump6(e.Mobile)); 
      }

      public TrainGump6(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(96, 19, 95, @"Its always sumthin aint it? ");
          this.AddLabel(21, 46, 95, @"The smiths just telled me that we are runnin low of the");
          this.AddLabel(15, 72, 95, @"materials we need to forge new weapons and our shipment");
          this.AddLabel(34, 99, 95, @"aint due for 5 full days now. Hmm, I know.  You can");
          this.AddLabel(13, 123, 95, @"get more for us! Those Rock Eater and Mad rulers carry ");
          this.AddLabel(19, 147, 95, @"round the same ingots we use.  Bring me back 10 of em");
          this.AddLabel(15, 172, 95, @"and ill make sure afore you leave to have you a shiny new");
          this.AddLabel(91, 196, 95, @"weapon that will do me proud! ");
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
                      from.SendMessage("Youve only just begun, wuss!");
                      from.CloseGump(typeof(TrainGump6));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump6));
                      from.SendMessage("Aye, ye make an old war horse happy.  Thank ye.");
                      break;
                  }

         }
      }
   }
}