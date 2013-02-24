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
   public class TrainGump1 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump1", AccessLevel.GameMaster, new CommandEventHandler(TrainGump1_OnCommand)); 
      }

      private static void TrainGump1_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump1(e.Mobile)); 
      }

      public TrainGump1(Mobile owner) : base(50, 50) 
      {

          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 493, 473, 9200);
          this.AddLabel(28, 34, 95, @"Good work gettin those supplies back.  And ya helped move em back a bit.");
          this.AddLabel(7, 61, 95, @"We've a new problem now tho. Seems the mages are runnin low on mage stuff.");
          this.AddLabel(45, 88, 95, @"Much as I hate to admit it, they've been quite useful.  I need ya to");
          this.AddLabel(69, 113, 95, @"head east outta the cove here and find them some more.");
          this.AddLabel(16, 135, 95, @"The mage trainer says that what they be needin can be found on 3 monster ");
          this.AddLabel(44, 159, 95, @"types. The huge spiders and em stinkin cobra plants.");
          this.AddLabel(18, 187, 95, @"Again we be needin ya to bring back 15 of em.  With all speed, move out!");
          this.AddButton(85, 396, 247, 248, 1, GumpButtonType.Reply, 1);
          this.AddButton(332, 395, 242, 241, 0, GumpButtonType.Reply, 0);
          this.AddImage(160, 163, 990);
      }

      public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
      {
          Mobile from = state.Mobile;

          switch (info.ButtonID)
          {
              case 0:
                  {
                      from.SendMessage("Had ye pegged as the Git er dun type.");
                      from.CloseGump(typeof(TrainGump1));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump1));
                      from.SendMessage("Hurry back, we've only just begun.");
                      break;
                  }

         }
      }
   }
}