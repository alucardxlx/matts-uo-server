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
    public class TrainSupplies : Item
    {
        [Constructable]
        public TrainSupplies() : this(1)
        {
        }

        [Constructable]
        public TrainSupplies(int amount) : base(0x3192)
        {
            Name = "Supplies";
            Stackable = true;
            Amount = amount;
            Hue = 1109;
        }
        public override void OnDoubleClick(Mobile m)
        {
            m.SendMessage("Supplies for the recruits, you decide not to open them.");
        }
        public TrainSupplies(Serial serial) : base(serial)
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
