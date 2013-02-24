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
   public class TrainGump7 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump7", AccessLevel.GameMaster, new CommandEventHandler(TrainGump7_OnCommand)); 
      }

      private static void TrainGump7_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump7(e.Mobile)); 
      }

      public TrainGump7(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(40, 19, 95, @"Excellent work!  Afore you leave here, ill have ye");
          this.AddLabel(12, 45, 95, @"a new weapon thatll make ya shiver! We're about done with");
          this.AddLabel(15, 72, 95, @"yer trainin, but not quite. A few more tasks to complete");
          this.AddLabel(34, 99, 95, @"still. We be runnin low on food down here and with");
          this.AddLabel(13, 123, 95, @"supply cart out 4 days yet, its gonna be a long one. You");
          this.AddLabel(10, 149, 95, @"can help tho.  Them dead turkey's Swamp Thief and Snaring");
          this.AddLabel(15, 172, 95, @"dirge carry a tasty bit o food.  Well tasty as I can get");
          this.AddLabel(23, 199, 95, @"'ere I spose.  Bring back 10 of em and be quick bout it.");
          this.AddLabel(60, 225, 95, @"Me tummies rumblin thinkin bout it now.");
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
                      from.SendMessage("Ha! Thought you were cut out fer this!");
                      from.CloseGump(typeof(TrainGump7));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump7));
                      from.SendMessage("Just a bit more training and ye can go.");
                      break;
                  }

         }
      }
   }
}