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
   public class TrainGump4 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump4", AccessLevel.GameMaster, new CommandEventHandler(TrainGump4_OnCommand)); 
      }

      private static void TrainGump4_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump4(e.Mobile)); 
      }

      public TrainGump4(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(19, 20, 95, @"Good work!  This medicine will get em back on their feet");
          this.AddLabel(26, 44, 95, @"in no time! The mages bring bad word tho. The barrier");
          this.AddLabel(12, 72, 95, @"that protects this cove is failin. They need some special");
          this.AddLabel(13, 98, 95, @"crystal to power it back up.  Said its them Mad scientists ");
          this.AddLabel(24, 123, 95, @"and the orcish trainees that carry em. Be needin ya to");
          this.AddLabel(16, 146, 95, @"collect 10 of em and bring em back.  Gonna need em fast");
          this.AddLabel(15, 171, 95, @"afore it fails completely. Id hate to lose our strong hold");
          this.AddLabel(14, 195, 95, @"here to the dag nabbin monsters! When yer skills get to be");
          this.AddLabel(30, 220, 95, @"about 80, trade me yer trainin wep fer a new one");
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
                      from.CloseGump(typeof(TrainGump4));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump4));
                      from.SendMessage("Keep up the good work");
                      break;
                  }

         }
      }
   }
}