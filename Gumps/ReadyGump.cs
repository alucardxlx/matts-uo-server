// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest   Gump
using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class ReadyGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ReadyGump", AccessLevel.GameMaster, new CommandEventHandler( ReadyGump_OnCommand ) ); 
      } 

      private static void ReadyGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ReadyGump( e.Mobile ) ); 
      }

      public ReadyGump(Mobile owner) : base(150, 150) 
      {
          {
              this.Closable = true;
              this.Disposable = true;
              this.Dragable = true;
              this.Resizable = false;
              this.AddPage(0);
              this.AddBackground(0, 0, 333, 197, 9270);
              this.AddLabel(76, 101, 32, @"Are you sure you are ready?");
              this.AddLabel(43, 76, 32, @"Have you got all your stuff together?");
              this.AddLabel(45, 125, 32, @"Once you leave, you canno come back");
              this.AddButton(62, 150, 247, 248, 1, GumpButtonType.Reply, 1);
              this.AddButton(201, 150, 242, 241, 0, GumpButtonType.Reply, 0);
              this.AddImage(74, 18, 10452, 1846);

          }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        from.SendMessage("Best hurry, dont wanna keep em waitin to long!.");
                        from.CloseGump(typeof(ReadyGump));
                        break;
                    }
                             
                    
                case 1:
                    
                    if (!ReadyGateExists())
                    {
                        from.SendMessage("Fare Thee well adventurer!");
                        from.CloseGump(typeof(ReadyGump));

                        ReadyGate g = new ReadyGate();
                        g.MoveToWorld(new Point3D( 5155, 1433, 0 ), Map.Trammel); //this is where the gate opens from.  Change this to have the gate open where you want it to.
                    }
                    else
                    {
                        from.SendMessage("That is already in use.");
                    }
                    break;
                    }
            }
        

        private bool ReadyGateExists()
        {
            foreach (Item item in World.Items.Values)
            {
                if (item is ReadyGate)
                    return true;
            }
            return false;
        }

    }
}
    
