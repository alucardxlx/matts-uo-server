// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items 
{ 
   public class SpecialLeather : Item 
   { 
      [Constructable] 
      public SpecialLeather() : this( 1 ) 
      { 
      } 

      [Constructable] 
      public SpecialLeather( int amount ) : base( 0x1081 ) 
      {
	    Name = "Special Leather";
	    Stackable = true;
	     Hue = 45;
         Weight = 0.1; 
         Amount = amount; 
      }

      public SpecialLeather(Serial serial) : base(serial) 
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
      } 
   } 
}