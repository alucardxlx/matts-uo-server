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
   public class TrainGump2 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump2", AccessLevel.GameMaster, new CommandEventHandler(TrainGump2_OnCommand)); 
      }

      private static void TrainGump2_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump2(e.Mobile)); 
      }

      public TrainGump2(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(25, 21, 95, @"Thats the spirit!  I told em you would get the job done!");
          this.AddLabel(26, 44, 95, @"Great work, even got em to back away from the tunnel.");
          this.AddLabel(50, 69, 95, @"How ya feelin?  Need a break?  No? Excellent!");
          this.AddLabel(26, 93, 95, @"Seems our boys are gettin pressed pretty bad from the ");
          this.AddLabel(27, 118, 95, @"other side.  Which is ok cause their bones have great");
          this.AddLabel(38, 143, 95, @"structure which makes great handles on weapons.");
          this.AddLabel(26, 169, 95, @"Your task?  Kill the Fanged Devil's, the Phantom Imp's");
          this.AddLabel(34, 192, 95, @"and them Celestial Wraith's.  Collect 10 dark bones and");
          this.AddLabel(33, 215, 95, @"bring em back.  I might even be able to make ya a new");
          this.AddLabel(82, 240, 95, @"weapong with some. if ya get enuf!");
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
                      from.SendMessage("Sendin me 'nother sissy lala?");
                      from.CloseGump(typeof(TrainGump2));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump2));
                      from.SendMessage("Times a wastin! Get to movin!");
                      break;
                  }

         }
      }
   }
}