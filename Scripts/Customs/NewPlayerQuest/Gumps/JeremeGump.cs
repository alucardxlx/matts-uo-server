// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class JeremeGump : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("JeremeGump", AccessLevel.GameMaster, new CommandEventHandler(JeremeGump_OnCommand)); 
      } 

      private static void JeremeGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new JeremeGump( e.Mobile ) ); 
      }

      public JeremeGump(Mobile owner) : base(50, 50) 
      {

          this.Closable = true;
          this.Disposable = true;
          this.Dragable = true;
          this.Resizable = false;
          this.AddPage(0);
          
          this.AddBackground(0, 0, 259, 217, 9200);
          this.AddLabel(21, 33, 95, @"Recruit, I need yer documents so ");
          this.AddLabel(46, 58, 95, @"we can start yer trainin.");

          this.AddButton(92, 108, 247, 248, 0, GumpButtonType.Reply, 0);

      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            {
               from.CloseGump(typeof(JeremeGump));
               from.SendMessage( "Find your documents and return.  Hurry, times a wastin." );
               break; 
            } 

         }
      }
   }
}