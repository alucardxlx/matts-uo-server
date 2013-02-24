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
   public class TrainGump5 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump5", AccessLevel.GameMaster, new CommandEventHandler(TrainGump5_OnCommand)); 
      }

      private static void TrainGump5_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump5(e.Mobile)); 
      }

      public TrainGump5(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(19, 20, 95, @"That should keep everyone safe for now and let us get");
          this.AddLabel(26, 44, 95, @"to work. Feelin worn out yet? Need to keep up yer ");
          this.AddLabel(15, 72, 95, @"training. Its almost time to send you out inta the world.");
          this.AddLabel(30, 99, 95, @"Oh wow, calm down lad. Still more work to do first!");
          this.AddLabel(17, 123, 95, @"Cant put my seal of approval on ye just yet. We be needin");
          this.AddLabel(15, 147, 95, @"ye to collect some of the special leathers for our armor.");
          this.AddLabel(15, 172, 95, @"The Hook Rats, Beholder's and Lost torturers carry em.");
          this.AddLabel(20, 199, 95, @"Bring 10 back with ye and ill be sure you get armor too.");
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
                      from.SendMessage("No time for wussin out?");
                      from.CloseGump(typeof(TrainGump5));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump5));
                      from.SendMessage("Keep up the good work");
                      break;
                  }

         }
      }
   }
}