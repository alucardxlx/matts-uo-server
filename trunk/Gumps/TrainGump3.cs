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
   public class TrainGump3 : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("TrainGump3", AccessLevel.GameMaster, new CommandEventHandler(TrainGump3_OnCommand)); 
      }

      private static void TrainGump3_OnCommand(CommandEventArgs e) 
      {
          e.Mobile.SendGump(new TrainGump3(e.Mobile)); 
      }

      public TrainGump3(Mobile owner) : base(50, 50) 
      {
          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          this.AddBackground(0, 0, 383, 378, 9200);
          this.AddLabel(10, 20, 95, @"Back so soon? Wow, ima hafta make it a bit more hard huh");
          this.AddLabel(26, 44, 95, @"Just got word from one of our scouts.  Far to the east");
          this.AddLabel(12, 72, 95, @"It seems they are mountin a new assault. They have Vorpal");
          this.AddLabel(17, 99, 95, @"liches, Enraged Mashers and Bone strikers tryin to gain");
          this.AddLabel(37, 121, 95, @"ground.  I need for you to help hold em off til I can");
          this.AddLabel(3, 145, 95, @"get more troops over there.  While yer killin em, keep a look");
          this.AddLabel(15, 170, 95, @"out for bottles of medicine they carry. it cures a virus ");
          this.AddLabel(25, 196, 95, @"thats been makin me boys sick.  Bring 10 bottles back");
          this.AddLabel(38, 219, 95, @"with ye and ill be sure you get a commendation!");
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
                      from.SendMessage("Wow, quittin already huh?");
                      from.CloseGump(typeof(TrainGump3));
                      break;
                  }
              case 1:
                  {
                      from.CloseGump(typeof(TrainGump3));
                      from.SendMessage("Times a wastin! Get to movin!");
                      break;
                  }

         }
      }
   }
}