// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
    public class SpecialIngot : Item
    {
        [Constructable] 
        public SpecialIngot() : this(1)
        {
        }

        [Constructable] 
        public SpecialIngot(int amount) : base(0x1BF2)
        {
            Name = "Special Ingot";
            Stackable = true;
            Amount = amount;
            Hue = 28;
            Weight = 0.1;

        }

        public SpecialIngot(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
